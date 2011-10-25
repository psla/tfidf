using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Pl.Sepio.Tfidf.Tests
{
    public class TfIdfIntegration
    {
        [Test]
        public void CorrectResults()
        {
            var document1 = new Document(new[] {"fly", "fly", "fruit", "like", "like"});
            var document2 = new Document(new[] {"bee", "wasp", "like"});
            var document3 = new Document(new[] {"fly", "fruit"});
            var document4 = new Document(new[] {"bee", "wasp", "fly"});
            var document5 = new Document(new[] {"fly", "fly", "fly", "fruit"});
            var tfIdf = new TfIdfIndexer(new[] {document1, document2, document3, document4, document5});

            List<SearchResult> result = tfIdf.Search(new Document(new[] {"fly", "fruit"})).ToList();

            Assert.That(result[0].Document, Is.EqualTo(document3));
            Assert.That(result[1].Document, Is.EqualTo(document5));
            Assert.That(result[2].Document, Is.EqualTo(document1));
            Assert.That(result[3].Document, Is.EqualTo(document4));
            Assert.That(result[4].Document, Is.EqualTo(document2));

            Assert.AreEqual(1.00d, result[0].Probability, 0.001d);
            Assert.AreEqual(0.874, result[1].Probability, 0.001d);
            Assert.AreEqual(0.331, result[2].Probability, 0.001d);
            Assert.AreEqual(0.068, result[3].Probability, 0.001d);
            Assert.AreEqual(0.00d, result[4].Probability, 0.001d);
        }
    }
}