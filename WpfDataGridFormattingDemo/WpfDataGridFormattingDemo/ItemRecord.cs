using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Demo {
  public class StockItem {
    public string Name { get; set; }
    public string Quantity { get; set; }
    public string IsObsolete { get; set; }
    public ObservableCollection<string> CultureList;
    }
}
