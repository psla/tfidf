using System;
using System.Windows;
using Microsoft.Win32;

namespace Pl.Sepio.SearchEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SearchViewModel m_vm;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            m_vm = new SearchViewModel();
            DataContext = m_vm;
        }

        private void SelectKeywordsFile(object sender, RoutedEventArgs e)
        {
            var fd = new OpenFileDialog();
            fd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            bool? showDialogResult = fd.ShowDialog();
            if (showDialogResult.HasValue && showDialogResult.Value)
            {
                m_vm.KeywordsFilePath = fd.FileName;
            }
        }

        private void SelectDocumentsFile(object sender, RoutedEventArgs e)
        {
            var fd = new OpenFileDialog();
            fd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            bool? showDialogResult = fd.ShowDialog();
            if (showDialogResult.HasValue && showDialogResult.Value)
            {
                m_vm.DocumentsFilePath = fd.FileName;
            }
        }
    }
}