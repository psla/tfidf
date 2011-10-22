using NUnit.Framework;

namespace Pl.Sepio.Tfidf.Tests
{
    public class PlainDocumentExtractorTests
    {
        [Test] public void ExtractsPlainText()
        {
            var text = @"sample text with words with-dashes as well as queries? and 'simple' and ""double"" quotes.";
            var document = PlainDocumentsExtractor.Extract(text);
            CollectionAssert.AreEqual(document.Words,
                                      new[]
                                          {
                                              "sample",
                                              "text",
                                              "with",
                                              "words",
                                              "with",
                                              "dashes",
                                              "as",
                                              "well",
                                              "as",
                                              "queries",
                                              "and",
                                              "simple",
                                              "and",
                                              "double",
                                              "quotes"
                                          });
        }
    }
}