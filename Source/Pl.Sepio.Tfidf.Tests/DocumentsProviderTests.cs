using System;
using System.IO;
using NUnit.Framework;
using Pl.Sepio.Tfidf.Providers;
using System.Linq;

namespace Pl.Sepio.Tfidf.Tests
{
    public class DocumentsProviderTests
    {
        [Test]
        public void RetrievesAllDocuments()
        {
            var documentsProvider = new DocumentsProvider(new NullStemmer());
            var documents = documentsProvider.Read(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"res\Documents.txt")).ToList();

            Assert.That(documents.Count, Is.EqualTo(3));
        }

        [Test]
        public void SetsUpProperTitlesOfDocuments()
        {
            var documentsProvider = new DocumentsProvider(new NullStemmer());
            var documents = documentsProvider.Read(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"res\Documents.txt")).ToList();

            Assert.That(documents[0].Title, Is.EqualTo("This is a title"));
            Assert.That(documents[1].Title, Is.EqualTo("This is second document"));
            Assert.That(documents[2].Title, Is.EqualTo("This is document without content"));
        }

        [Test]
        public void SetsUpProperContent()
        {
            var documentsProvider = new DocumentsProvider(new NullStemmer());
            var documents = documentsProvider.Read(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"res\Documents.txt")).ToList();

            Assert.That(documents[0].Content, Is.EqualTo("This is content of the document"));
            Assert.That(documents[1].Content, Is.EqualTo("Short Content"));
            Assert.That(documents[2].Content, Is.EqualTo(string.Empty));
        }

        [Test]
        public void WordsTakesIntoAccountTitleAsWell()
        {
            var documentsProvider = new DocumentsProvider(new NullStemmer());
            var documents = documentsProvider.Read(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"res\Documents.txt")).ToList();

            CollectionAssert.Contains(documents[0].Words, "title");
            CollectionAssert.Contains(documents[0].Words, "content");
        }
    }
}