using System.Collections.Generic;
using System.Linq;

namespace Pl.Sepio.Tfidf
{
    public class Document : IDocument
    {
        public Document(IEnumerable<string> words)
        {
            Words = new List<string>(words.Where(x=>!string.IsNullOrEmpty(x))).AsReadOnly();
        }

        public IEnumerable<string> Words { get; private set; }
    }
}