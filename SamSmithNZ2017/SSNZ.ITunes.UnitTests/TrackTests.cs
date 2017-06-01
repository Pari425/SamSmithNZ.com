﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSNZ.ITunes.Data;
using SSNZ.ITunes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSNZ.ITunes.UnitTests
{
    [TestClass]
    public class TrackTests
    {
        [TestMethod]
        public async Task TrackTest()
        {
            //Arrange
            TrackDataAccess da = new TrackDataAccess();
            int playlistCode = 1;
            bool showJustSummary = true;

            //Act
            List<Track> items = await da.GetListAsync(playlistCode, showJustSummary);

            //Assert
            Assert.IsTrue(items != null);
            Assert.IsTrue(items.Count > 0);
            Assert.IsTrue(items[0].ArtistName == "Frank Black");
            Assert.IsTrue(items[0].AlbumName == "Honeycomb");
            Assert.IsTrue(items[0].TrackName == "Song Of The Shrimp");
            Assert.IsTrue(items[0].PlayCount == 36);
            Assert.IsTrue(items[0].IsNewEntry == false);
            Assert.IsTrue(items[0].PlaylistCode == 1);
            Assert.IsTrue(items[0].PreviousPlayCount == 0);
            Assert.IsTrue(items[0].PreviousRanking == 1);
            Assert.IsTrue(items[0].Ranking == 1);
            Assert.IsTrue(items[0].Rating == 100);
            Assert.IsTrue(items[0].RecordId != null);
        }
    }
}
