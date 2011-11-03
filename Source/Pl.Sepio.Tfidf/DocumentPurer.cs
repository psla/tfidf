using System.Collections.Generic;

namespace Pl.Sepio.Tfidf
{
    /// <summary>
    /// Pures document to leave only words, that are defined as a term
    /// </summary>
    public class DocumentPurer : IDocumentPurer
    {
        private readonly TermsCollection _termsCollection;

        public DocumentPurer(TermsCollection termsCollection)
        {
            _termsCollection = termsCollection;
        }

        public Document PureDocument(Document document)
        {
            var words = new List<string>();
            foreach (var word in document.Words)
            {
                if(_termsCollection.ContainsTerm(word))
                    words.Add(word);
            }
            return new Document(words);
        }
    }
}