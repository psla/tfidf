namespace Pl.Sepio.Tfidf
{
    public class Tf : ITermWeightRepresentation
    {
        private readonly BagOfWords _bagOfWords;
        private readonly uint _maxDivider = 1;

        public Tf(BagOfWords bagOfWords)
        {
            _bagOfWords = bagOfWords;
            foreach (string word in bagOfWords.Words)
            {
                uint wordCount = bagOfWords.Count(word);
                if (wordCount > _maxDivider)
                {
                    _maxDivider = wordCount;
                }
            }
        }

        public double TermWeight(string word)
        {
            return _bagOfWords.Count(word)/(double) _maxDivider;
        }
    }
}