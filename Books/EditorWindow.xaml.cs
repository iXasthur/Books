using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Books
{
    public partial class EditorWindow : Window
    {

        private readonly Book _bookToEdit;
        private readonly DataGrid _booksGrid;

        public EditorWindow(Book bookToEdit, DataGrid booksGrid)
        {
            InitializeComponent();

            _bookToEdit = bookToEdit;
            _booksGrid = booksGrid;

            CultureComboBox.Text = "Unknown";
            CultureComboBox.ItemsSource = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
            CultureComboBox.SelectedItem = _bookToEdit.Price.Culture;

            IsbnTextBox.Text = _bookToEdit.Isbn;
            TitleTextBox.Text = _bookToEdit.Title;
            AuthorTextBox.Text = _bookToEdit.Author;
            PublisherTextBox.Text = _bookToEdit.Publisher;
            DateDatePicker.SelectedDate = _bookToEdit.Date;
            PriceTextBox.Text = _bookToEdit.Price.Value.ToString();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _bookToEdit.Isbn = IsbnTextBox.Text;
            _bookToEdit.Title = TitleTextBox.Text;
            _bookToEdit.Author = AuthorTextBox.Text;
            _bookToEdit.Publisher = PublisherTextBox.Text;
            _bookToEdit.Date = DateDatePicker.SelectedDate;
            
            try
            {
                _bookToEdit.Price.Value = Double.Parse(PriceTextBox.Text);
            }
            catch
            {
                _bookToEdit.Price.Value = 0;
            }
            try
            {
                _bookToEdit.Price.Culture = (CultureInfo)CultureComboBox.SelectedItem;
                if (_bookToEdit.Price.Culture?.Name == "")
                {
                    _bookToEdit.Price.Culture = null;
                }
            }
            catch
            {
                _bookToEdit.Price.Culture = null;
            }

            _booksGrid.Items.Refresh();
            Close();
        }
        
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}