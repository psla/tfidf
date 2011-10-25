using System;

namespace Pl.Sepio.Tfidf
{
    public class DistanceCalculator
    {
        public double CalculateDistance(ITermWeightRepresentation termWeightRepresentation,
                                        TermsCollection termsCollection)
        {
            double sum = 0;
            foreach (string term in termsCollection.Terms)
            {
                sum += Math.Pow(termWeightRepresentation.TermWeight(term), 2);
            }
            return Math.Sqrt(sum);
        }
    }
}