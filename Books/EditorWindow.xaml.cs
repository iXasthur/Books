using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Books
{
    public partial class EditorWindow : Window
    {

        private Book _bookToEdit;
        private DataGrid _booksGrid;

        public EditorWindow(Book bookToEdit, DataGrid booksGrid)
        {
            InitializeComponent();

            _bookToEdit = bookToEdit;
            _booksGrid = booksGrid;

            IsbnTextBox.Text = _bookToEdit.Isbn;
            TitleTextBox.Text = _bookToEdit.Title;
            AuthorTextBox.Text = _bookToEdit.Author;
            PublisherTextBox.Text = _bookToEdit.Publisher;
            DateDatePicker.SelectedDate = _bookToEdit.Date;
            PriceTextBox.Text = _bookToEdit.Price.Value.ToString();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _booksGrid.Items.Refresh();
            Close();
        }
        
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}