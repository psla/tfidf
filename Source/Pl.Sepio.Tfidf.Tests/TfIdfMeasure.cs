using Moq;
using NUnit.Framework;

namespace Pl.Sepio.Tfidf.Tests
{
    public class TfIdfMeasure
    {
        [Test]
        public void TfIdfMeasureIsCorrectEvenIfWordsDoesNotExistInIdf()
        {
            var idf = new Mock<IIdf>();
            idf.Setup(x => x.Value(It.Is<string>(y => y == "test"))).Returns(0.23);
            idf.Setup(x => x.Value(It.Is<string>(y => y == "two"))).Returns(1d);
            var tf = new Mock<ITermWeightRepresentation>();
            tf.Setup(x => x.TermWeight(It.Is<string>(y => y == "test"))).Returns(0.78);
            tf.Setup(x => x.TermWeight(It.Is<string>(y => y == "two"))).Returns(0.5);
            tf.Setup(x => x.TermWeight(It.Is<string>(y => y == "third"))).Returns(0.5);

            var tfIdf = new TfIdf(tf.Object, idf.Object);

            Assert.AreEqual(0.1794, tfIdf.TermWeight("test"), 0.0001);
            Assert.AreEqual(0.5, tfIdf.TermWeight("two"), 0.0001);
            Assert.AreEqual(0d, tfIdf.TermWeight("third"), 0.0001);
        }
    }
}