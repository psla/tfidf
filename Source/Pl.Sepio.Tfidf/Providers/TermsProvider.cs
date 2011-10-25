using System;
using System.IO;

namespace Pl.Sepio.Tfidf.Providers
{
    public class TermsProvider
    {
        private readonly IStemmerInterface _stemmerInterface;

        public TermsProvider(IStemmerInterface stemmerInterface)
        {
            _stemmerInterface = stemmerInterface;
        }

        /// <summary>
        /// Reads file. Assumes, each word is in separate file
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public TermsCollection LoadFile(string filepath)
        {
            if (!File.Exists(filepath))
                throw new ArgumentException("filename");

            // each word in separate line
            string[] words = File.ReadAllLines(filepath);
            var document = new Document(words);
            Document stemmedDocument = DocumentStemmer.StemDocument(document, _stemmerInterface);
            return new TermsCollection(stemmedDocument.Words);
        }
    }
}