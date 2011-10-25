using System.Collections.Generic;

namespace Pl.Sepio.Tfidf
{
    public interface IDocument
    {
        IEnumerable<string> Words { get; }
    }
}