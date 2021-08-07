using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SamSmithnNZ.Tests;
using SamSmithNZ.Service.Controllers.GuitarTab;
using SamSmithNZ.Service.DataAccess.GuitarTab;
using SamSmithNZ.Service.DataAccess.GuitarTab.Interfaces;
using SamSmithNZ.Service.Models.GuitarTab;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SamSmithNZ.Tests.GuitarTab
{
    [TestClass]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class AlbumDataAccessTest : BaseIntegrationTest
    {

        [TestMethod()]
        public async Task AlbumsExistTest()
        {
            //arrange
            Mock<IAlbumDataAccess> mock = new();
            mock.Setup(repo => repo.GetList(It.IsAny<bool>())).Returns(Task.FromResult(GetAlbumsTestData()));
            AlbumController controller = new(mock.Object);

            //act
            List<Album> results = await controller.GetAlbums(true);

            //assert
            Assert.IsTrue(results != null);
            Assert.IsTrue(results.Count > 0);
        }

        [TestMethod()]
        public async Task AlbumsFirstItemTest()
        {
            //arrange
            AlbumController controller = new(new AlbumDataAccess(base.Configuration));
            int albumCode = 14; //The Colour And The Shape

            //act
            Album results = await controller.GetAlbum(albumCode, true);

            //assert
            TestTCATS(results);
        }

        [TestMethod()]
        public async Task AlbumsTCATSListTest()
        {
            //arrange
            AlbumController controller = new(new AlbumDataAccess(base.Configuration));
            int albumCode = 14; //The Colour And The Shape

            //act
            List<Album> results = await controller.GetAlbums(true);

            //assert
            bool foundTCATS = false;
            foreach (Album result in results)
            {
                if (result.AlbumCode == albumCode)
                {
                    TestTCATS(result);
                    foundTCATS = true;
                    break;
                }
            }
            Assert.IsTrue(foundTCATS == true);
        }

        private static void TestTCATS(Album results)
        {
            Assert.IsTrue(results != null);
            Assert.IsTrue(results.AlbumCode == 14);
            Assert.IsTrue(results.AlbumName == "The Colour And The Shape");
            Assert.IsTrue(results.AlbumYear == 1997);
            Assert.IsTrue(results.ArtistName == "Foo Fighters");
            Assert.IsTrue(results.ArtistNameTrimed == "FooFighters");
            Assert.IsTrue(results.AverageRating == 5);
            Assert.IsTrue(results.IncludeInIndex == true);
            Assert.IsTrue(results.IncludeOnWebsite == true);
            Assert.IsTrue(results.IsBassTab == false);
            Assert.IsTrue(results.IsMiscCollectionAlbum == false);
            Assert.IsTrue(results.IsNewAlbum == false);
            Assert.IsTrue(results.IsLeadArtist == false);
            Assert.IsTrue(results.BassAlbumCode == 102);
        }

        [TestMethod()]
        public async Task AlbumsSaveTest()
        {
            //arrange
            AlbumController controller = new(new AlbumDataAccess(base.Configuration));
            int albumCode = 242;

            //act
            Album item = await controller.GetAlbum(albumCode, true);

            //update
            string albumName;
            string artistName;
            if (item.AlbumName == "Test Album1")
            {
                albumName = "Test Album2";
                artistName = "Test Artist2";
            }
            else
            {
                albumName = "Test Album1";
                artistName = "Test Artist1";
            }
            item.AlbumName = albumName;
            item.ArtistName = artistName;
            item.IsBassTab = item.IsBassTab;
            item.IsLeadArtist = item.IsLeadArtist;
            //item.AverageRating = 2;
            await controller.SaveAlbum(item);

            //reload
            item = await controller.GetAlbum(albumCode, true);

            //assert
            Assert.IsTrue(item != null);
            Assert.IsTrue(item.AlbumCode == 242);
            Assert.IsTrue(item.AlbumName == albumName);
            Assert.IsTrue(item.AlbumYear == 2014);
            Assert.IsTrue(item.ArtistName == artistName);
            Assert.IsTrue(item.ArtistNameTrimed == artistName.Replace(" ", ""));
            Assert.IsTrue(item.AverageRating == 0);
            Assert.IsTrue(item.IncludeInIndex == false);
            Assert.IsTrue(item.IncludeOnWebsite == false);
            Assert.IsTrue(item.IsBassTab == false);
            Assert.IsTrue(item.IsMiscCollectionAlbum == false);
            Assert.IsTrue(item.IsNewAlbum == false);
        }

        private List<Album> GetAlbumsTestData()
        {
            return new List<Album>() {
            new Album{
                AlbumCode = 14,
                AlbumName = "The Colour And The Shape",
                ArtistName = "Foo Fighters",
                ArtistNameTrimed = "FooFighters",
                AlbumYear = 1997,
                IncludeInIndex = true,
                IncludeOnWebsite = true,
                IsBassTab = false,
                IsMiscCollectionAlbum = false,
                IsNewAlbum = false,
                IsLeadArtist = false,
                AverageRating = 5M,
                BassAlbumCode = 102
            } };
        }
    }
}