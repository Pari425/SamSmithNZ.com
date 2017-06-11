﻿CREATE PROCEDURE [dbo].[spIFB_GetPlayoffGameList]
	@tournament_code INT,
	@round_number INT
AS
SELECT g.game_code, g.game_number, g.game_time, 
	g.round_code, g.round_number, r.round_name,
	t1.team_code AS team_1_code, t1.team_name AS team_1_name, 
	ISNULL(g.team_1_normal_time_score,-1) AS team_1_normal_time_score, 
	ISNULL(g.team_1_extra_time_score,-1) AS team_1_extra_time_score, 
	ISNULL(g.team_1_penalties_score,-1) AS team_1_penalties_score,
	t2.team_code AS team_2_code, t2.team_name AS team_2_name, 
	ISNULL(g.team_2_normal_time_score,-1) AS team_2_normal_time_score, 
	ISNULL(g.team_2_extra_time_score,-1) AS team_2_extra_time_score, 
	ISNULL(g.team_2_penalties_score,-1) AS team_2_penalties_score,
	g.round_code, g.location, 
	t1.flag_name AS team_1_flag_name, 
	t2.flag_name AS team_2_flag_name,
	CONVERT(bit,CASE WHEN g.team_1_normal_time_score is NULL THEN
		1 ELSE 0 END) AS team_1_withdrew,
	CONVERT(bit,CASE WHEN g.team_2_normal_time_score is NULL THEN
		1 ELSE 0 END) AS team_2_withdrew
FROM wc_game g
JOIN wc_round r ON g.round_code = r.round_code
LEFT JOIN wc_team t1 ON g.team_1_code = t1.team_code
LEFT JOIN wc_team t2 ON g.team_2_code = t2.team_code
WHERE g.tournament_code = @tournament_code
and g.round_number = @round_number
and g.round_code in ('16','QF','SF','FF','3P')
ORDER BY g.game_time, g.game_number