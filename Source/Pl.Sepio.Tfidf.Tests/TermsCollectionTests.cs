using NUnit.Framework;

namespace Pl.Sepio.Tfidf.Tests
{
    public class TermsCollectionTests
    {
        [Test]
        public void AddsAllTermsFromDocumentsToTermsCollection()
        {
            var document1 = new Document(new[] {"first", "word"});
            var document2 = new Document(new[] {"word", "second"});

            var termsCollection = new TermsCollection();
            termsCollection.AddDocument(document1);
            termsCollection.AddDocument(document2);
            
            Assert.That(termsCollection.ContainsTerm("first"), Is.True);
            Assert.That(termsCollection.ContainsTerm("word"), Is.True);
            Assert.That(termsCollection.ContainsTerm("second"), Is.True);
        }

        [Test]
        public void DoesNotAddInexistingTermToTermsCollection()
        {
            var document1 = new Document(new[] { "first", "word" });
            var document2 = new Document(new[] { "word", "second" });

            var termsCollection = new TermsCollection();
            termsCollection.AddDocument(document1);
            termsCollection.AddDocument(document2);

            Assert.That(termsCollection.ContainsTerm("nonexisting"), Is.False);
        }

        [Test]
        public void ContainsAllWordsInPublicCollection()
        {
            var document1 = new Document(new[] { "first", "word" });
            var document2 = new Document(new[] { "word", "second" });

            var termsCollection = new TermsCollection();
            termsCollection.AddDocument(document1);
            termsCollection.AddDocument(document2);
            
            CollectionAssert.AreEqual(new[] { "first", "word", "second"}, termsCollection.Terms);
        }

    }
}