using System.Linq;

namespace BridgeHandKata
{
    public class SuitScorer
    {
        private CardScorer cardScorer;

        public SuitScorer(CardScorer cardScorer)
        {
            this.cardScorer = cardScorer;
        }

        public int CalculateFromString(string line)
        {
            string lineWithoutSuit = line.Substring(1, line.Length - 1);
            return lineWithoutSuit.Sum(card => cardScorer.CalculateFromString(card));
        }
    }
}