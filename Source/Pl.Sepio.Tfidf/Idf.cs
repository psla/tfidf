using System;
using System.Collections.Generic;
using System.Linq;

namespace Pl.Sepio.Tfidf
{
    public class Idf : IIdf
    {
        private readonly List<BagOfWords> _documents;

        public Idf(IEnumerable<BagOfWords> documents)
        {
            _documents = new List<BagOfWords>(documents);
        }

        public double Value(string term)
        {
            if (term == null) throw new ArgumentNullException("term");
            var documentsMatching = _documents.Where(x => x.Count(term) > 0).Count();
            return Math.Log(_documents.Count/(double)documentsMatching);
        }
    }
}