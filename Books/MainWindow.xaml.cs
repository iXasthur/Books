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
            BooksGrid.Items.SortDescriptions.Clear();
            foreach (var column in BooksGrid.Columns)
            {
                column.SortDirection = null;
            }
            
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
    }
}