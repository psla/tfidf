using NUnit.Framework;

namespace Pl.Sepio.Tfidf.Tests
{
    public class DocumentStemmerTests
    {
        [Test]
        public void DocumentStemmingStemsAllWords()
        {
            var document = new Document(new[] {"ala", "ma", "kota"});
            Document stemmedDocument = DocumentStemmer.StemDocument(document, new FakeStemmer());
            CollectionAssert.AreEqual(new[] {"3", "2", "4"}, stemmedDocument.Words);
        }

        #region Nested type: FakeStemmer

        private class FakeStemmer : IStemmerInterface
        {
            #region IStemmerInterface Members

            public string StemTerm(string s)
            {
                return s.Length.ToString();
            }

            #endregion
        }

        #endregion
    }
}