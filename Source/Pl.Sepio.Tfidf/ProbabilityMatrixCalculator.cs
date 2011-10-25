namespace Pl.Sepio.Tfidf
{
    public class ProbabilityMatrixCalculator
    {
        private readonly DistanceCalculator _distanceCalculator = new DistanceCalculator();

        public double CalculateProbability(ITermWeightRepresentation queryRepresentation,
                                           ITermWeightRepresentation documentRepresentation,
                                           TermsCollection termsCollection)
        {
            double queryDistance = _distanceCalculator.CalculateDistance(queryRepresentation, termsCollection);
            double documentDistance = _distanceCalculator.CalculateDistance(documentRepresentation, termsCollection);

            double sum = 0;
            foreach (string term in termsCollection.Terms)
            {
                sum += queryRepresentation.TermWeight(term)*documentRepresentation.TermWeight(term);
            }
            return sum/(queryDistance*documentDistance);
        }
    }
}