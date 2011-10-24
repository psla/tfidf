using System.Collections.Generic;

namespace Pl.Sepio.Tfidf
{
    public class TermsCollection
    {
        private readonly HashSet<string> _words = new HashSet<string>();

        /// <summary>
        /// Returns all terms that exists in documents collection
        /// </summary>
        public IEnumerable<string> Terms
        {
            get { return _words; }
        }

        public void AddDocument(Document document)
        {
            foreach (string word in document.Words)
            {
                _words.Add(word);
            }
        }

        /// <summary>
        /// Returns true, if terms collection contains defined term
        /// </summary>
        /// <param name="term">term to verify</param>
        /// <returns></returns>
        public bool ContainsTerm(string term)
        {
            return _words.Contains(term);
        }
    }
}