using System;
using System.Collections.Generic;
using System.Linq;

namespace Pl.Sepio.Tfidf
{
    public class Idf
    {
        private readonly List<BagOfWords> _documents;

        public Idf(IEnumerable<BagOfWords> documents)
        {
            _documents = new List<BagOfWords>(documents);
        }

        public double Value(string word)
        {
            if (word == null) throw new ArgumentNullException("word");
            var documentsMatching = _documents.Where(x => x.Count(word) > 0).Count();
            return Math.Log(_documents.Count/(double)documentsMatching);
        }
    }
}