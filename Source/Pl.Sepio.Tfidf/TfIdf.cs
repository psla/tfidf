namespace Pl.Sepio.Tfidf
{
    public class TfIdf : ITermWeightRepresentation
    {
        private readonly IIdf _idf;
        private readonly ITermWeightRepresentation _termWeightRepresentation;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termWeightRepresentation">should be instance of <see cref="Tf"/></param>
        /// <param name="idf"></param>
        public TfIdf(ITermWeightRepresentation termWeightRepresentation, IIdf idf)
        {
            _termWeightRepresentation = termWeightRepresentation;
            _idf = idf;
        }

        public double TermWeight(string term)
        {
            return _termWeightRepresentation.TermWeight(term)*_idf.Value(term);
        }
    }
}