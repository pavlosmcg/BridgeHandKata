using System.Collections.Generic;

namespace BridgeHandKata
{
    public class CardScorer
    {
        private readonly Dictionary<char,int> scores = new Dictionary<char, int>
            {
                {'A', 4},
                {'K', 3},
                {'Q', 2},
                {'J', 1},
                {'?', 0},
            }; 
        
        public int CalculateFromString(char card)
        {
            return scores[card];
        }

        
    }
}