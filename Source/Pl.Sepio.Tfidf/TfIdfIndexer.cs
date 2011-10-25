using System.Collections.Generic;
using System.Linq;

namespace Pl.Sepio.Tfidf
{
    public class TfIdfIndexer
    {
        private readonly IEnumerable<Document> _documents;
        private readonly Idf _idf;
        private readonly ProbabilityMatrixCalculator _probabilityMatrixCalculator = new ProbabilityMatrixCalculator();
        private readonly TermsCollection _termsCollection;
        private readonly IEnumerable<TfIdfWithDocument> _tfIdfWithDocuments;

        public TfIdfIndexer(IEnumerable<Document> documents)
        {
            _documents = documents;
            _idf = new Idf(documents.Select(x => new BagOfWords(x)));
            _tfIdfWithDocuments =
                documents.Select(x => new TfIdfWithDocument(new TfIdf(new Tf(new BagOfWords(x)), _idf), x));

            _termsCollection = new TermsCollection();
            foreach (Document document in documents)
            {
                _termsCollection.AddDocument(document);
            }
        }

        public IEnumerable<SearchResult> Search(Document query)
        {
            var queryTfIdf = new TfIdf(new Tf(new BagOfWords(query)), _idf);

            var results = new List<SearchResult>();
            foreach (TfIdfWithDocument tfIdfWithDocument in _tfIdfWithDocuments)
            {
                double probability = _probabilityMatrixCalculator.CalculateProbability(queryTfIdf,
                                                                                       tfIdfWithDocument.TfIdf,
                                                                                       _termsCollection);
                results.Add(new SearchResult(tfIdfWithDocument.Document, probability));
            }

            return results.OrderByDescending(x => x.Probability);
        }

        #region Nested type: TfIdfWithDocument

        /// <summary>
        /// TfIdf representation of the document
        /// </summary>
        private class TfIdfWithDocument
        {
            public TfIdfWithDocument(TfIdf tfIdf, Document document)
            {
                TfIdf = tfIdf;
                Document = document;
            }

            public TfIdf TfIdf { get; private set; }
            public Document Document { get; private set; }
        }

        #endregion
    }
}