/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/
using Minesweeper.Services.Data;
using MineSweeperClassLibrary;
using MinesweeperRestService.Models;
using System;
using System.Collections.Generic;

namespace Minesweeper
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ScoreService : IScoreService
    {
        //Get service for accessing high scores in the database
        private HighScoreDAO service = new HighScoreDAO();

        /// <summary>
        /// Method for getting a DTO consisting of the player scores by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RestDTO GetScoresById(string id)
        {
            RestDTO response = new RestDTO
            {
                Error = false,
                Message = ""
            };

            try
            {
                List<PlayerStats> scores = service.GetScoresForUser(int.Parse(id));
                if (scores.Count > 0)
                {
                    response.Scores = scores;
                }
                else
                {
                    response.Error = true;
                    response.Message = "No scores found";
                }
            }
            catch (Exception e)
            {
                response.Error = true;
                response.Message = e.Message;
            }

            return response;
        }

        /// <summary>
        /// Method for getting a DTO consisting of player scores by username
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RestDTO GetScoresByUsername(string id)
        {
            RestDTO response = new RestDTO
            {
                Error = false,
                Message = ""
            };

            try
            {
                //Gets the list of players scores by the username
                List<PlayerStats> scores = service.GetScoresByUsername(id);
                if (scores.Count > 0)
                {
                    response.Scores = scores;
                }
                else
                {
                    response.Error = true;
                    response.Message = "No scores found";
                }
            }
            catch (Exception e)
            {
                response.Error = true;
                response.Message = e.Message;
            }

            return response;
        }

        /// <summary>
        /// Method for returning a DTO with top ten scores from database by board size and difficulty
        /// </summary>
        /// <param name="boardSize"></param>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        public RestDTO GetTopTenScores(string boardSize, string difficulty)
        {
            RestDTO response = new RestDTO
            {
                Error = false,
                Message = ""
            };

            try
            {
                //gets the users high scores by username 
                List<PlayerStats> scores = service.GetTopTenScores(int.Parse(boardSize), int.Parse(difficulty));
                if (scores.Count > 0)
                {
                    response.Scores = scores;
                }
                else
                {
                    response.Error = true;
                    response.Message = "No scores found";
                }
            }
            catch (Exception e)
            {
                response.Error = true;
                response.Message = e.Message;
            }

            return response;
        }
    }
}