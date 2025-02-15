﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamSmithNZ.Service.DataAccess.Steam;
using SamSmithNZ.Service.Models.Steam;
using System.Threading.Tasks;
using SamSmithNZ.Service.Controllers.Steam;
using StackExchange.Redis;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Collections.Generic;

namespace SamSmithNZ.Tests.Steam
{
    [TestClass]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class FriendsControllerTest
    {
        [ClassInitialize]
        public static void InitTestSuite(TestContext testContext)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
        
        [TestCategory("RegressionTest")]
        [TestMethod]
        public async Task FriendsSamFirstTest()
        {
            //Arrange
            FriendsController controller = new();
            string steamId = "76561197971691578";

            //Act
            List<Friend> results = await controller.GetFriends(steamId);

            //Assert
            Assert.IsTrue(results != null);
            Assert.IsTrue(results.Count >= 0);
            Friend result = null;
            foreach (Friend item in results)
            {
                if (item.SteamId == "76561198034342716")
                {
                    result = item;
                    break;
                }
            }
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.SteamId == "76561198034342716");
            Assert.IsTrue(result.Name == "Alex");
            Assert.IsTrue(result.Avatar != "");
            Assert.IsTrue(result.AvatarFull != "");
            Assert.IsTrue(result.AvatarMedium != "");
            Assert.IsTrue(result.FriendSince >= 0);
            Assert.IsTrue(result.LastLogoff >= 0);
            Assert.IsTrue(result.ProfileURL != "");
            Assert.IsTrue(result.TimeCreated >= 0);
        }
        
        [TestCategory("RegressionTest")]
        [TestMethod]
        public async Task FriendsSamFirstWithoutCacheTest()
        {
            //Arrange
            FriendsController controller = new();
            string steamId = "76561197971691578";

            //Act
            List<Friend> results = await controller.GetFriends(steamId);

            //Assert
            Assert.IsTrue(results != null);
            Assert.IsTrue(results.Count >= 0);
            Friend result = null;
            foreach (Friend item in results)
            {
                if (item.SteamId == "76561198034342716")
                {
                    result = item;
                    break;
                }
            }
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.SteamId == "76561198034342716");
            Assert.IsTrue(result.Name == "Alex");
            Assert.IsTrue(result.Avatar != "");
            Assert.IsTrue(result.AvatarFull != "");
            Assert.IsTrue(result.AvatarMedium != "");
            Assert.IsTrue(result.FriendSince >= 0);
            Assert.IsTrue(result.LastLogoff >= 0);
            Assert.IsTrue(result.ProfileURL != "");
            Assert.IsTrue(result.TimeCreated >= 0);
        }

        [TestCategory("RegressionTest")]
        [TestMethod]
        public async Task FriendsAlexTest()
        {
            //Arrange
            FriendsController controller = new();
            string steamId = "76561198034342716";

            //Act
            List<Friend> results = await controller.GetFriends(steamId);

            //Assert
            Assert.IsTrue(results != null);
            Assert.IsTrue(results.Count >= 0);
            //Friend result = null;
            //foreach (Friend item in results)
            //{
            //    if (item.SteamId == "76561197971691578") //Sam
            //    {
            //        result = item;
            //        break;
            //    }
            //}
            //Assert.IsTrue(result != null);
            //Assert.IsTrue(result.SteamId == "76561197971691578");
            //Assert.IsTrue(result.Name == "Sam");
        }

        [TestCategory("RegressionTest")]
        [TestMethod]
        public async Task FriendsRandomTest()
        {
            //Arrange
            FriendsController controller = new();
            string steamId = "76561198154034472";

            //Act
            List<Friend> results = await controller.GetFriends(steamId);

            //Assert
            Assert.IsTrue(results != null);
            Assert.IsTrue(results.Count >= 0);
        }

        [TestCategory("RegressionTest")]
        [TestMethod]
        public async Task FriendsRandomWithMoreThan100FriendsTest()
        {
            //Arrange
            FriendsController controller = new();
            string steamId = "76561198129345768";

            //Act
            List<Friend> results = await controller.GetFriends(steamId);

            //Assert
            Assert.IsTrue(results != null);
            Assert.IsTrue(results.Count > 100);
        }

        [TestCategory("RegressionTest")]
        [TestMethod]
        public async Task FriendsRandomWithExactly99FriendsTest()
        {
            //Arrange
            FriendsController controller = new();
            string steamId = "76561198140300853";

            //Act
            List<Friend> results = await controller.GetFriends(steamId);

            //Assert
            Assert.IsTrue(results != null);
            Assert.IsTrue(results.Count >= 0);
        }

        //[TestCategory("RegressionTest")]
        //[TestMethod]
        //public async Task FriendsSameGameSamXcomTest()
        //{
        //    //Arrange
        //    FriendsController controller = new();
        //    string steamId = "76561197971691578";
        //    string appId = "200510"; //Xcom

        //    //Act
        //    List<Friend> results = await controller.GetFriendsWithSameGame(steamId, appId);

        //    //Assert
        //    Assert.IsTrue(results != null);
        //    Assert.IsTrue(results.Count >= 0);
        //    Friend result = null;
        //    foreach (Friend item in results)
        //    {
        //        if (item.SteamId == "76561197990013217") //Stew
        //        {
        //            result = item;
        //            break;
        //        }
        //    }
        //    Assert.IsTrue(result != null);
        //    Assert.IsTrue(result.SteamId == "76561197990013217");
        //    Assert.IsTrue(result.Name == "Captain Datsun");

        //}

        //[TestCategory("RegressionTest")]
        //[TestMethod]
        //public async Task FriendsSameGameSamCiv6Test()
        //{
        //    //Arrange
        //    FriendsController controller = new();
        //    string steamId = "76561197971691578";
        //    string appId = "289070"; //Civ 6

        //    //Act
        //    List<Friend> results = await controller.GetFriendsWithSameGame(steamId, appId);

        //    //Assert
        //    Assert.IsTrue(results != null);
        //    Assert.IsTrue(results.Count >= 1);
        //    Friend result = null;
        //    foreach (Friend item in results)
        //    {
        //        if (item.SteamId == "76561198030842184") //Coleman
        //        {
        //            result = item;
        //        }
        //        //else if (item.SteamId == "76561198034342716") //Alex
        //        //{
        //        //    Assert.IsTrue(false); //This should never happen, Alex has a private profile
        //        //}
        //    }
        //    Assert.IsTrue(result != null);
        //    Assert.IsTrue(result.SteamId == "76561198030842184");
        //    Assert.IsTrue(result.Name == "coleman.yeaw");

        //}

        //[TestCategory("RegressionTest")]
        //[TestMethod]
        //public async Task FriendsSameGameStewXcomTest()
        //{
        //    //Arrange
        //    FriendsController controller = new();
        //    string steamId = "76561197990013217";
        //    string appId = "200510"; //Xcom

        //    //Act
        //    List<Friend> results = await controller.GetFriendsWithSameGame(steamId, appId);

        //    //Assert
        //    Assert.IsTrue(results != null);
        //    Assert.IsTrue(results.Count >= 0);
        //    Friend result = null;
        //    foreach (Friend item in results)
        //    {
        //        if (item.SteamId == "76561197971691578") //Sam
        //        {
        //            result = item;
        //            break;
        //        }
        //    }
        //    Assert.IsTrue(result != null);
        //    Assert.IsTrue(result.SteamId == "76561197971691578");
        //    Assert.IsTrue(result.Name == "Sam");
        //}


    }
}
