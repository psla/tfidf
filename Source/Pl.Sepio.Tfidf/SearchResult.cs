namespace Pl.Sepio.Tfidf
{
    public class SearchResult
    {
        /// <summary>
        /// Document which is search result
        /// </summary>
        public Document Document { get; private set; }

        /// <summary>
        /// Chance that document matches query
        /// </summary>
        public double Probability { get; private set; }

        public SearchResult(Document document, double probability)
        {
            Document = document;
            Probability = probability;
        }
    }
}