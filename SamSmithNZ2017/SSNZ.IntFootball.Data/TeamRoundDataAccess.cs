﻿using Dapper;
using SSNZ.IntFootball.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SSNZ.IntFootball.Data
{
    public class TeamRoundDataAccess : GenericDataAccess<TeamRound>
    {

        public async Task<List<TeamRound>> GetListAsync(int tournamentCode, int roundNumber)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@TournamentCode", tournamentCode, DbType.Int32);
            parameters.Add("@RoundNumber", roundNumber, DbType.Int32);

            return await base.GetListAsync("spIFB_GetGroupList", parameters);
        }
             
    }
}
