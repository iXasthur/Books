using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using Microsoft.Win32;

namespace Books
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EditorWindow _openedEditorWindow = null;
        private BookStorage _books = new BookStorage();
        
        public MainWindow()
        {
            InitializeComponent();
            BooksGrid.ItemsSource = _books.Books;
        }

        private void MenuSave_OnClick(object sender, RoutedEventArgs e)
        {
            string json = _books.CreateJson();
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON file (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, json);
                MessageBox.Show("Successfully saved to " + saveFileDialog.FileName);
            }
        }
        
        private void MenuOpen_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                
                _openedEditorWindow?.Close();
                _openedEditorWindow = null;
                
                _books = JsonSerializer.Deserialize<BookStorage>(json);

                BooksGrid.ItemsSource = _books.Books;
                BooksGrid.Items.Refresh();
            }
        }
        
        private void MenuReset_OnClick(object sender, RoutedEventArgs e)
        {
            _openedEditorWindow?.Close();
            _openedEditorWindow = null;
            _books.Reset();
            BooksGrid.Items.Refresh();
        }

        private void NewBookButton_OnClick(object sender, RoutedEventArgs e)
        {
            _books.Add(new Book());
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
                MessageBox.Show("Error opening editor!");
            }
        }
        
        private void DeleteBookButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Book bookToDelete = (Book) BooksGrid.SelectedItem;
                if (_openedEditorWindow != null && _openedEditorWindow.BookToEdit == bookToDelete)
                {
                    _openedEditorWindow.Close();
                    _openedEditorWindow = null;
                }
                _books.Remove(bookToDelete);
                BooksGrid.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("Error deleting book!");
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
            _openedEditorWindow = null;
            base.OnClosed(e);
        }
    }
}