using System.Collections.Generic;

namespace Pl.Sepio.Tfidf
{
    public class BagOfWords
    {
        private readonly IDictionary<string, uint> _wordCount = new Dictionary<string, uint>();

        /// <summary>
        /// Words, that are defined in this document
        /// </summary>
        public IEnumerable<string> Words { get { return _wordCount.Keys; } }

        public BagOfWords(Document document)
        {
            foreach (string word in document.Words)
            {
                if (_wordCount.ContainsKey(word))
                {
                    _wordCount[word]++;
                }
                else
                {
                    _wordCount[word] = 1;
                }
            }
        }

        public uint Count(string word)
        {
            uint count;
            _wordCount.TryGetValue(word, out count);
            return count;
        }
    }
}