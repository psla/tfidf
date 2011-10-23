using NUnit.Framework;

namespace Pl.Sepio.Tfidf.Tests
{
    public class TfTests
    {
        [Test]
        public void GivenBagOfWordsTfIsCorrect()
        {
            var bagOfWords = new BagOfWords(new Document(new[]
                                                             {
                                                                 "fly", 
                                                                 "fly", 
                                                                 "fly", 
                                                                 "fruit", 
                                                             }));
            var tf = new Tf(bagOfWords);
            Assert.AreEqual(0.33333333, tf.WordWeight("fruit"), 0.00001);
            Assert.AreEqual(1d, tf.WordWeight("fly"), 0.00001);
            Assert.That(tf.WordWeight("nonexisting"), Is.EqualTo(0));
        }
    }
}