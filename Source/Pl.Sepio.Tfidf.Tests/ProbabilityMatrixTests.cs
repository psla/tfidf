using Moq;
using NUnit.Framework;

namespace Pl.Sepio.Tfidf.Tests
{
    public class ProbabilityMatrixTests
    {
        [Test]
        public void ProbabilityMatrixCalculation()
        {
            var queryRepresentation = new Mock<ITermWeightRepresentation>();
            var documentRepresentation = new Mock<ITermWeightRepresentation>();
            queryRepresentation.Setup(x => x.TermWeight(It.Is<string>(y => y == "fruit"))).Returns(0.51083);
            queryRepresentation.Setup(x => x.TermWeight(It.Is<string>(y => y == "fly"))).Returns(0.22314);
            documentRepresentation.Setup(x => x.TermWeight(It.Is<string>(y => y == "bee"))).Returns(0.91629);
            documentRepresentation.Setup(x => x.TermWeight(It.Is<string>(y => y == "wasp"))).Returns(0.91629);
            documentRepresentation.Setup(x => x.TermWeight(It.Is<string>(y => y == "fly"))).Returns(0.22314);
            var termsCollection = new TermsCollection(new[] {"bee", "wasp", "fly", "fruit", "like"});
            var distanceCalculator = new DistanceCalculator();

            var probabilityMatrix = new ProbabilityMatrixCalculator();
            double probability = probabilityMatrix.CalculateProbability(queryRepresentation.Object,
                                                                        documentRepresentation.Object, termsCollection);

            Assert.AreEqual(0.067932752, probability, 0.0001);
        }
    }
}