using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Pl.Sepio.Tfidf
{
    public sealed class PlainDocumentsExtractor
    {
        public static Document Extract(string text)
        {
            var words = new List<string>();
            if(text==null)
                return new Document(words);

            var splitted = Regex.Split(text, @"\W+");
            return new Document(splitted);
        }
    }
}