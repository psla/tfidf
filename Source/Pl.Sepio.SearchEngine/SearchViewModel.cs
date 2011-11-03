using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Pl.Sepio.Tfidf;
using Pl.Sepio.Tfidf.Providers;

namespace Pl.Sepio.SearchEngine
{
    //TODO: decapitalize letters in source
    //TODO: nice design
    //TODO: select stemmer ;) (and reinitialize viewmodel :P)
    //TODO: display nicely
    public class SearchViewModel : INotifyPropertyChanged
    {
        private bool _enableStemmer;
        private TermsCollection _termsCollection;
        private TfIdfIndexer _tfIdfIndexer;

        public SearchViewModel()
        {
            KeywordsFilePath = @"res\keywords.txt";
            DocumentsFilePath = @"res\documents.txt";
            SearchResults = new ObservableCollection<SearchResult>();
            InitializeSearcherWithStemmer();
            SearchCommand = new RelayCommand(PerformSearch);
        }

        public ICommand SearchCommand { get; set; }

        public string Query { get; set; }

        private string _keywordsFilePath;
        public string KeywordsFilePath
        {
            get { return _keywordsFilePath; }
            set { _keywordsFilePath = value; InvokePropertyChanged("KeywordsFilePath"); }
        }

        private string _documentsFilePath;
        private DocumentPurer _documentPurer;

        public string DocumentsFilePath
        {
            get { return _documentsFilePath; }
            set { _documentsFilePath = value; InvokePropertyChanged("DocumentsFilePath");}
        }

        public bool EnableStemmer
        {
            get { return _enableStemmer; }
            set
            {
                _enableStemmer = value;
                InitializeSearcherWithStemmer();
                PerformSearch();
            }
        }

        public ObservableCollection<SearchResult> SearchResults { get; set; }

        private void InitializeSearcherWithStemmer()
        {

            _termsCollection =
                new TermsProvider(ProvideStemmer())
                    .LoadFile(
                        Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory,
                            KeywordsFilePath));

            _documentPurer = new DocumentPurer(_termsCollection);

            IEnumerable<ExtendedDocument> documents = new DocumentsProvider(ProvideStemmer(), _documentPurer).Read(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                DocumentsFilePath));

            _tfIdfIndexer = new TfIdfIndexer(documents, _termsCollection);
        }

        private void PerformSearch()
        {
            SearchResults.Clear();
            var query = PlainDocumentsExtractor.Extract(Query.ToLowerInvariant());
            var stemmedQuery = DocumentStemmer.StemDocument(query, ProvideStemmer());
            var puredStemmedQuery = _documentPurer.PureDocument(stemmedQuery);
            List<SearchResult> documents = _tfIdfIndexer.Search(stemmedQuery).ToList();
            foreach (SearchResult searchResult in documents)
            {
                SearchResults.Add(searchResult);
            }
        }

        private IStemmerInterface ProvideStemmer()
        {
            if (EnableStemmer)
                return new PorterStemmer();
            return new NullStemmer();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}