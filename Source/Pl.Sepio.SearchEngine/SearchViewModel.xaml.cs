using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using Pl.Sepio.Tfidf;
using Pl.Sepio.Tfidf.Providers;
using System.Linq;

namespace Pl.Sepio.SearchEngine
{
    //TODO: decapitalize letters in source
    //TODO: nice design
    //TODO: select stemmer ;) (and reinitialize viewmodel :P)
    //TODO: display nicely
    public class SearchViewModel
    {
        private readonly TermsCollection _termsCollection;
        private readonly TfIdfIndexer _tfIdfIndexer;

        public SearchViewModel()
        {
            SearchResults = new ObservableCollection<SearchResult>();
            _termsCollection =
                new TermsProvider(new NullStemmer())
                    .LoadFile(
                        Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory,
                            @"res\keywords.txt"));

            _tfIdfIndexer = new TfIdfIndexer(new DocumentsProvider().Read(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"res\documents.txt")), _termsCollection);
            SearchCommand = new RelayCommand(PerformSearch);
        }

        private void PerformSearch()
        {
            SearchResults.Clear();
            var documents = _tfIdfIndexer.Search(PlainDocumentsExtractor.Extract(Query)).ToList();
            foreach (var searchResult in documents)
            {
                SearchResults.Add(searchResult);
            }
        }

        public ICommand SearchCommand { get; set; }

        public string Query { get; set; }

        public ObservableCollection<SearchResult> SearchResults { get; set; }
    }
}