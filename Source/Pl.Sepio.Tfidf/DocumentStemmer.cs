using System;
using System.Collections.Generic;

namespace Pl.Sepio.Tfidf
{
    public class DocumentStemmer
    {
        /// <summary>
        /// Stems document, creating new document, which is stemmed
        /// </summary>
        /// <param name="document">document to stem</param>
        /// <param name="stemmerInterface">stemmer interface to use</param>
        /// <returns>document, with all words stemmed.</returns>
        public static Document StemDocument(Document document, IStemmerInterface stemmerInterface)
        {
            if (document == null) throw new ArgumentNullException("document");

            var words= new List<string>();
            foreach (var word in document.Words)
            {
                words.Add(stemmerInterface.StemTerm(word));
            }

            return new Document(words);
        }
    }
}