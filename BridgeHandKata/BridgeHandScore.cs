using System.Collections.Generic;
using System.Linq;

namespace BridgeHandKata
{
    public class BridgeHandScore
    {
        public Dictionary<char, int> Scores { get; set; }
        public int TotalScore { get { return Scores.Sum(s => s.Value); } }

        public BridgeHandScore()
        {
            Scores = new Dictionary<char, int>();
        }
    }
}