﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SamSmithNZ.Service.DataAccess.Steam;
using SamSmithNZ.Service.DataAccess.Steam.Interfaces;
using SamSmithNZ.Service.Models.Steam;

namespace SamSmithNZ.Service.Controllers.Steam
{
    [Route("api/Steam/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private IRedisService _redisService;

        public FriendsController(IRedisService redisService)
        {
            _redisService = redisService;
        }

        // GET
        [HttpGet("GetFriends")]
        public async Task<List<Friend>> GetFriends(string steamId, bool useCache = true)
        {
            if (string.IsNullOrEmpty(steamId) == false)
            {
                FriendsDA da = new FriendsDA();
                return await da.GetDataAsync(_redisService, steamId, useCache);
            }
            else
            {
                return null;
            }
        }

        //// GET
        //[HttpGet("GetFriendsWithSameGame")]
        //public async Task<List<Friend>> GetFriendsWithSameGame(string steamId, string appId, bool useCache = true)
        //{
        //    FriendsDA da = new FriendsDA();
        //    return await da.GetFriendsWithSameGame(_redisService, steamId, appId, useCache);
        //}
    }
}
