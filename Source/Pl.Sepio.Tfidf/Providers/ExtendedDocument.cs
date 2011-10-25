namespace Pl.Sepio.Tfidf.Providers
{
    public class ExtendedDocument : Document
    {
        public string Title { get; private set; }
        public string Content { get; private set; }

        public ExtendedDocument(string title, string content, IDocument baseDocument) : base(baseDocument.Words)
        {
            Title = title;
            Content = content;
        }
    }
}