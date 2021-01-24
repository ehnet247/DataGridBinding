using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Demo {

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow: Window
    {
        private Dictionnary dictionnary;


        public MainWindow() {
      InitializeComponent();

            //create business data
            dictionnary = new Dictionnary();
            // Initialize cultures list
            dictionnary.CultureList = new System.Collections.ObjectModel.ObservableCollection<string>();
            dictionnary.CultureList.Add("Fr");
            dictionnary.CultureList.Add("En");
            dictionnary.CultureList.Add("De");
            dictionnary.CultureList.Add("Es");

            // Initialize a few strings
            dictionnary.Expressions = new System.Collections.ObjectModel.ObservableCollection<Dictionary<string, string>>();
            Dictionary<string, string> expression = new Dictionary<string, string>();
            expression.Add("Fr", "Phrase");
            expression.Add("En", "Sentence");
            expression.Add("De", "Formulierung");
            expression.Add("Es", "fraseo");
            dictionnary.Expressions.Add(expression);
            expression = new Dictionary<string, string>();
            expression.Add("Fr", "Réussite");
            expression.Add("En", "Success");
            expression.Add("De", "Erfolg");
            expression.Add("Es", "Éxito");
            dictionnary.Expressions.Add(expression);

      
            BuildDataGrid();
            //BindDataGrid();
    }

        private void BuildDataGrid()
        {

            //link business data to CollectionViewSource
            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(FindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = dictionnary.CultureList;
            MainWindowDataGrid.DataContext = itemCollectionViewSource;
            MainWindowDataGrid.ItemsSource = dictionnary.Expressions;
            foreach (string culture in dictionnary.CultureList)
            {
                //DataGridTextColumn textColumn = new DataGridTextColumn();
                //textColumn.Header = culture;
                var textColumn = new DataGridTextColumn();
                textColumn.Header = culture;
                // Attempt to bind the column 
                //textColumn.Binding = new BindingBase();
                textColumn.Binding.BindingGroupName = culture;

                MainWindowDataGrid.Columns.Add(textColumn);
            }
        }

        private void BindDataGrid()
        {
        }

        private void ButtonBind_Click(object sender, RoutedEventArgs e)
        {
            BindDataGrid();
        }
    }
}
