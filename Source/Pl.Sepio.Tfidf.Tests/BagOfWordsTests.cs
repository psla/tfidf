using NUnit.Framework;

namespace Pl.Sepio.Tfidf.Tests
{
    public class BagOfWordsTests
    {
        [Test] public void CorectlyCountsWordsInBagOfWords()
        {
            var document = new Document(new[] {"one", "two", "other", "two"});
            var bagOfWords = new BagOfWords(document);

            Assert.That(bagOfWords.Count("one"), Is.EqualTo(1));
            Assert.That(bagOfWords.Count("two"), Is.EqualTo(2));
            Assert.That(bagOfWords.Count("other"), Is.EqualTo(1));
            Assert.That(bagOfWords.Count("nonexisting"), Is.EqualTo(0));
        }
    }
}