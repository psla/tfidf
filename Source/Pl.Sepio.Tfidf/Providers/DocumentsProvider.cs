using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pl.Sepio.Tfidf.Providers
{
    public class DocumentsProvider
    {
        private readonly IStemmerInterface _stemmer;

        public DocumentsProvider(IStemmerInterface stemmer)
        {
            _stemmer = stemmer;
        }

        public IEnumerable<ExtendedDocument> Read(string documentsPath)
        {
            if (!File.Exists(documentsPath))
                throw new ArgumentException("documentsPath");

            string[] lines = File.ReadAllLines(documentsPath);

            var documents = new List<List<string>>();

            var document = new List<string>();
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    document.Add(line);
                }
                else
                {
                    documents.Add(document);
                    document = new List<string>();
                }
            }
            if (document.Count > 0)
            {
                documents.Add(document);
            }

            return
                documents.Select(
                    x =>
                    new ExtendedDocument(x[0], string.Join(" ", x.Skip(1)),
                                         DocumentStemmer.StemDocument(
                                             PlainDocumentsExtractor.Extract(string.Join(" ", x).ToLowerInvariant()),
                                             _stemmer)));
        }
    }
}