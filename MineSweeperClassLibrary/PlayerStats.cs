/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/
using System;
using System.Runtime.Serialization;

namespace MineSweeperClassLibrary
{
    [DataContract]
    public class PlayerStats : IComparable<PlayerStats>
    {
        //Variables to store the players scores
        [DataMember]
        public string PlayerInitials { get; set; }

        [DataMember]
        public double DifficultyLevel { get; set; }

        [DataMember]
        public int BoardSize { get; set; }

        [DataMember]
        public string TimeSpanString { get; set; }

        [DataMember]
        public long TimeAsTicks { get; set; }

        public PlayerStats()
        {
        }

        public PlayerStats(string playerInitials, long time, double difficultyLevel, int boardSize)
        {
            this.PlayerInitials = playerInitials;
            this.TimeAsTicks = time;
            this.DifficultyLevel = difficultyLevel;
            this.BoardSize = boardSize;
        }

        // Override the ToString to output for all the information for the save file
        public override string ToString()
        {
            return this.PlayerInitials + ", " + this.TimeAsTicks;
        }

        // Implement ICompareable. Sort by time and then initials/PlayerName
        public int CompareTo(PlayerStats obj)
        {
            TimeSpan timeSpan1 = TimeSpan.Parse(TimeSpanString);
            TimeSpan timeSpan2 = TimeSpan.Parse(obj.TimeSpanString);

            if (timeSpan1 == timeSpan2)
            {
                return this.PlayerInitials.CompareTo(obj.PlayerInitials);
            }

            return timeSpan1.CompareTo(timeSpan2);
        }
    }
}