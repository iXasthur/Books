using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Books
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
#nullable enable
        private EditorWindow? _openedEditorWindow = null;
#nullable disable
        private readonly BookList _books = new BookList();
        
        public MainWindow()
        {
            InitializeComponent();
            BooksGrid.ItemsSource = _books.Books;
        }

        private void NewBookButton_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime date = new DateTime(1970,1,1);
            CultureInfo culture = new CultureInfo("en");
            Price price = new Price(culture, 0);
            Book book = new Book("0-000-000000", "NEW BOOK", "AUTHOR", "PUBLISHER", date, price);
            _books.Add(book);
            
            BooksGrid.Items.Refresh();
        }
        
        private void EditBookButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Book bookToEdit = (Book) BooksGrid.SelectedItem;
                EditorWindow editorWindow = new EditorWindow(bookToEdit, BooksGrid);
                _openedEditorWindow?.Close();
                _openedEditorWindow = editorWindow;
                editorWindow.Show();
            }
            catch
            {
                
            }
        }
        
        private void DeleteBookButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Book bookToDelete = (Book) BooksGrid.SelectedItem;
                if (_openedEditorWindow?.BookToEdit == bookToDelete)
                {
                    _openedEditorWindow!.Close();
                    _openedEditorWindow = null;
                }
                _books.Remove(bookToDelete);
                BooksGrid.Items.Refresh();
            }
            catch
            {
                
            }
        }

        private void MenuSortBook_OnClick(object sender, RoutedEventArgs e)
        {
            _books.SortByBook();
            BooksGrid.Items.Refresh();
        }
        
        private void MenuSortIsbn_OnClick(object sender, RoutedEventArgs e)
        {
            _books.SortByIsbn();
            BooksGrid.Items.Refresh();
        }
        
        private void MenuSortTitle_OnClick(object sender, RoutedEventArgs e)
        {
            _books.SortByTitle();
            BooksGrid.Items.Refresh();
        }

        private void MenuSortAuthor_OnClick(object sender, RoutedEventArgs e)
        {
            _books.SortByAuthor();
            BooksGrid.Items.Refresh();
        }
        
        private void MenuSortPublisher_OnClick(object sender, RoutedEventArgs e)
        {
            _books.SortByPublisher();
            BooksGrid.Items.Refresh();
        }
        
        private void MenuSortDate_OnClick(object sender, RoutedEventArgs e)
        {
            _books.SortByDate();
            BooksGrid.Items.Refresh();
        }
        
        private void MenuSortPrice_OnClick(object sender, RoutedEventArgs e)
        {
            _books.SortByPrice();
            BooksGrid.Items.Refresh();
        }
        
        protected override void OnClosed(EventArgs e)
        {
            _openedEditorWindow?.Close();
            base.OnClosed(e);
        }
    }
}