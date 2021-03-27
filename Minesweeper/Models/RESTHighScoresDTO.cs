/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/
using MineSweeperClassLibrary;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Minesweeper.Models
{
    [DataContract]
    public class RESTHighScoresDTO
    {
        [DataMember]
        // Error reporting variable
        public bool Error { get; set; }

        [DataMember]
        // Messages
        public string Message { get; set; }

        [DataMember]
        //variable that stors a List of  scores
        public List<PlayerStats> Scores { get; set; }
    }
}