namespace Pl.Sepio.Tfidf.Providers
{
    /// <summary>
    /// does nothing (doesnt remove anything)
    /// </summary>
    public class NullDocumentPurer : IDocumentPurer
    {
        public Document PureDocument(Document document)
        {
            return document;
        }
    }
}