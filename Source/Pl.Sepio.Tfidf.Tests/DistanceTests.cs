using Moq;
using NUnit.Framework;

namespace Pl.Sepio.Tfidf.Tests
{
    public class DistanceTests
    {
        [Test]
        public void DistanceCalculation()
        {
            var termWeightRepresentation = new Mock<ITermWeightRepresentation>();
            termWeightRepresentation.Setup(x => x.TermWeight(It.Is<string>(y => y == "bee"))).Returns(0.91629);
            termWeightRepresentation.Setup(x => x.TermWeight(It.Is<string>(y => y == "wasp"))).Returns(0.91629);
            termWeightRepresentation.Setup(x => x.TermWeight(It.Is<string>(y => y == "fly"))).Returns(0.22314);
            var termsCollection = new TermsCollection(new[] {"bee", "wasp", "fly", "fruit", "like"});

            var distanceCalculator = new DistanceCalculator();
            double actualDistance = distanceCalculator.CalculateDistance(termWeightRepresentation.Object,
                                                                         termsCollection);

            Assert.AreEqual(1.314903211, actualDistance, 0.0001);
        }
    }
}