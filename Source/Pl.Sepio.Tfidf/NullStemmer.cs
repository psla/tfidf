using System;

namespace Pl.Sepio.Tfidf
{
    public class NullStemmer : IStemmerInterface
    {
        public string StemTerm(string s)
        {
            return s;
        }
    }
}