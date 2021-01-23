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
        private StockItem item;


        public MainWindow() {
      InitializeComponent();

            //create business data
            item = new StockItem();
            item.CultureList = new System.Collections.ObjectModel.ObservableCollection<string>();
      //      item.CultureList.Add(new StockItem {Name= "Many items",      Quantity="100", IsObsolete="false"});
      //      item.CultureList.Add(new StockItem {Name= "Enough items",    Quantity="10",  IsObsolete="false"});
      //itemList.Add(new StockItem {Name= "Shortage item",   Quantity="1",   IsObsolete="false"});
      //      item.CultureList.Add(new StockItem {Name= "Item with error", Quantity="-1",  IsObsolete="false"});
      //itemList.Add(new StockItem {Name= "Obsolete item",   Quantity="200", IsObsolete="true" });

      
            BuildDataGrid();
            BindDataGrid();
    }

        private void BuildDataGrid()
        {
            foreach (string culture in item.CultureList)
            {
                DataGridTextColumn textColumn = new DataGridTextColumn();
                textColumn.Header = culture;
                MainWindowDataGrid.Columns.Add(textColumn);
            }
        }

        private void BindDataGrid()
        {
            //link business data to CollectionViewSource
            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(FindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = item.CultureList;
        }


    }
}
