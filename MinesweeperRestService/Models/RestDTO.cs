/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/
using MineSweeperClassLibrary;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MinesweeperRestService.Models
{
    // Data transfer object for high score REST service.
    [DataContract]
    public class RestDTO
    {
        //bool arror variable
        [DataMember]
        public bool Error { get; set; } 
        //Stores error messages
        [DataMember]
        public string Message { get; set; }
        // variable for the list of high scores
        [DataMember]
        public List<PlayerStats> Scores { get; set; } 
    }
}