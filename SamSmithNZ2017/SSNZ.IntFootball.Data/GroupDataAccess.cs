﻿using Dapper;
using SSNZ.IntFootball.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SSNZ.IntFootball.Data
{
    public class GroupDataAccess :  GenericDataAccess<Group>
    {

        public async Task<List<Group>> GetListAsync(int tournamentCode, int roundNumber)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@tournament_code", tournamentCode, DbType.Int32);
            parameters.Add("@round_number", roundNumber, DbType.Int32);

            return await base.GetListAsync("spIFB_GetGroupList", parameters);
        }     
        
    }
}
