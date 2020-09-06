using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using Books.BookStorage;
using Microsoft.Win32;

namespace Books
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private BookStorage.BookStorage _bookStorage = new BookStorage.BookStorage();
        private EditorWindow _openedEditorWindow;

        public MainWindow()
        {
            InitializeComponent();
            BooksGrid.ItemsSource = _bookStorage.Books;
        }

        private void MenuSave_OnClick(object sender, RoutedEventArgs e)
        {
            var json = _bookStorage.CreateJson();

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON file (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, json);
                MessageBox.Show("Successfully saved to " + saveFileDialog.FileName);
            }
        }

        private void MenuOpen_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var json = File.ReadAllText(openFileDialog.FileName);

                try
                {
                    _bookStorage = JsonSerializer.Deserialize<BookStorage.BookStorage>(json);
                }
                catch
                {
                    MessageBox.Show("Invalid file format");
                    return;
                }

                _openedEditorWindow?.Close();
                _openedEditorWindow = null;

                BooksGrid.ItemsSource = _bookStorage.Books;
                BooksGrid.Items.Refresh();
            }
        }

        private void MenuReset_OnClick(object sender, RoutedEventArgs e)
        {
            _openedEditorWindow?.Close();
            _openedEditorWindow = null;
            _bookStorage.Reset();
            BooksGrid.Items.Refresh();
        }

        private void NewBookButton_OnClick(object sender, RoutedEventArgs e)
        {
            _bookStorage.Add(new Book());
            BooksGrid.Items.Refresh();
        }

        private void EditBookButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var bookToEdit = (Book) BooksGrid.SelectedItem;
                var editorWindow = new EditorWindow(bookToEdit, BooksGrid);
                _openedEditorWindow?.Close();
                _openedEditorWindow = editorWindow;
                editorWindow.Show();
            }
            catch
            {
                MessageBox.Show("Error opening editor!");
            }
        }

        private void DeleteBookButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var bookToDelete = (Book) BooksGrid.SelectedItem;
                if (_openedEditorWindow != null && _openedEditorWindow.BookToEdit == bookToDelete)
                {
                    _openedEditorWindow.Close();
                    _openedEditorWindow = null;
                }

                _bookStorage.Remove(bookToDelete);
                BooksGrid.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("Error deleting book!");
            }
        }

        private void MenuSortBook_OnClick(object sender, RoutedEventArgs e)
        {
            _bookStorage.SortByBook();
            BooksGrid.Items.Refresh();
        }

        private void MenuSortIsbn_OnClick(object sender, RoutedEventArgs e)
        {
            _bookStorage.SortByIsbn();
            BooksGrid.Items.Refresh();
        }

        private void MenuSortTitle_OnClick(object sender, RoutedEventArgs e)
        {
            _bookStorage.SortByTitle();
            BooksGrid.Items.Refresh();
        }

        private void MenuSortPages_OnClick(object sender, RoutedEventArgs e)
        {
            _bookStorage.SortByPages();
            BooksGrid.Items.Refresh();
        }

        private void MenuSortAuthor_OnClick(object sender, RoutedEventArgs e)
        {
            _bookStorage.SortByAuthor();
            BooksGrid.Items.Refresh();
        }

        private void MenuSortPublisher_OnClick(object sender, RoutedEventArgs e)
        {
            _bookStorage.SortByPublisher();
            BooksGrid.Items.Refresh();
        }

        private void MenuSortDate_OnClick(object sender, RoutedEventArgs e)
        {
            _bookStorage.SortByDate();
            BooksGrid.Items.Refresh();
        }

        private void MenuSortPrice_OnClick(object sender, RoutedEventArgs e)
        {
            _bookStorage.SortByPrice();
            BooksGrid.Items.Refresh();
        }

        protected override void OnClosed(EventArgs e)
        {
            _openedEditorWindow?.Close();
            _openedEditorWindow = null;
            base.OnClosed(e);
        }
    }
}