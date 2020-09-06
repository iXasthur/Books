using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Books
{
    public partial class EditorWindow
    {

        public readonly Book BookToEdit;
        public readonly DataGrid BooksGrid;

        public EditorWindow(Book bookToEdit, DataGrid booksGrid)
        {
            InitializeComponent();

            BookToEdit = bookToEdit;
            BooksGrid = booksGrid;

            CultureComboBox.Text = "Unknown";
            CultureComboBox.ItemsSource = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
            CultureComboBox.SelectedItem = BookToEdit.Price.Culture;

            IsbnTextBox.Text = BookToEdit.Isbn;
            TitleTextBox.Text = BookToEdit.Title;
            AuthorTextBox.Text = BookToEdit.Author;
            PublisherTextBox.Text = BookToEdit.Publisher;
            DateDatePicker.SelectedDate = BookToEdit.Date;
            PriceTextBox.Text = BookToEdit.Price.Value.ToString(new CultureInfo("en"));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            BookToEdit.Isbn = IsbnTextBox.Text;
            BookToEdit.Title = TitleTextBox.Text;
            BookToEdit.Author = AuthorTextBox.Text;
            BookToEdit.Publisher = PublisherTextBox.Text;
            BookToEdit.Date = DateDatePicker.SelectedDate;
            
            try
            {
                PriceTextBox.Text = PriceTextBox.Text.Replace(".", ",");
                BookToEdit.Price.Value = Double.Parse(PriceTextBox.Text);
            }
            catch
            {
                BookToEdit.Price.Value = 0;
            }
            
            try
            {
                BookToEdit.Price.Culture = (CultureInfo)CultureComboBox.SelectedItem;
            }
            catch
            {
                BookToEdit.Price.Culture = new CultureInfo("");
            }

            BooksGrid.Items.Refresh();
            Close();
        }
        
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}