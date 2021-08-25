using SipatecSync.Lib;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
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

namespace SipatecSync
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }
    private void MainWindow_ItemAdded(object sender, ItemAddedEventArgs args)
    {
      if (args.Item is CustomNode && args.ItemSource == ItemSource.Stencil)
      {
        CustomNode node = args.Item as CustomNode;
        //node.ID = Guid.NewGuid();
        //node.Datatype = PropertyDatatype.Integer;
        //node.SIUnit = "Liters";
        node.ContentTemplate = App.Current.MainWindow.Resources[node.CustomTemplate] as DataTemplate;
        node.Annotations = null;
      }
    }
  }
}
