using NUnit.Framework;

namespace Pl.Sepio.Tfidf.Tests
{
    public class DocumentPurerTests
    {
        [Test]
        public void VerifyRemovesInvalidTerms()
        {
            var termsCollection = new TermsCollection(new[] {"accepted"});
            var document = new Document(new[] {"accepted", "nonaccepted", "accepted"});

            var documentPurer = new DocumentPurer(termsCollection);
            Document puredDocument = documentPurer.PureDocument(document);

            CollectionAssert.AreEqual(new[] {"accepted", "accepted"}, puredDocument.Words);
        }
    }
}