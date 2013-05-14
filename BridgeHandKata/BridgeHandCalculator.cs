using System;
using System.Linq;

namespace BridgeHandKata
{
    public class BridgeHandCalculator
    {
        private SuitScorer suitScorer;

        public BridgeHandCalculator(SuitScorer suitScorer)
        {
            this.suitScorer = suitScorer;
        }

        public BridgeHandScore CalculateFromString(string inputString)
        {
            var bridgeHandScore = new BridgeHandScore();
            string cleanedInput = inputString.Trim();
            string[] lines = cleanedInput.Split('\n');

            #region "input checks"
            // input checks
            
            const int correctNumberOfLines = 4;

            if (lines.Length != correctNumberOfLines)
            {
                throw new ArgumentException("Sorry, wrong number of lines!");
            }

            int totalNumberOfCharacters = lines.Sum(l => l.Length);
            const int numberOfCards = 13;
            if (totalNumberOfCharacters != numberOfCards + correctNumberOfLines)
            {
                throw new ArgumentException("Sorry, wrong number of cards :(");
            }
            #endregion

            // calculate score for each suit
            foreach (string line in lines)
            {
                bridgeHandScore.Scores[line[0]] = suitScorer.CalculateFromString(line);
            }
            
            return bridgeHandScore;
        }
    }
}