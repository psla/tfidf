using NUnit.Framework;

namespace Pl.Sepio.Tfidf.Tests
{
    public class IdfTests
    {
        [Test]
        public void IdfTest()
        {
            var document1 = new Document(new[] {"fly"});
            var document2 = new Document(new[] {"bee"});
            var document3 = new Document(new[] {"fly"});
            var document4 = new Document(new[] {"fly", "bee"});
            var document5 = new Document(new[] {"fly"});

            var idf = new Idf(new[]
                                  {
                                      new BagOfWords(document1),
                                      new BagOfWords(document2),
                                      new BagOfWords(document3),
                                      new BagOfWords(document4),
                                      new BagOfWords(document5)
                                  });

            Assert.AreEqual(0.92, idf.Value("bee"), 0.01);
            Assert.AreEqual(0.22, idf.Value("fly"), 0.01);
        }
    }
}