using SipatecSync.Lib;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    //public object SymbolSource { get; set; }
    public MainWindow()
    {
      InitializeComponent();
      //MyStencil();
    }
    public void MyStencil()
    {
      Stencil stencil = new Stencil()
      {
        ExpandMode = ExpandMode.All,
        BorderThickness = new Thickness(0, 0, 1, 0),
        BorderBrush = new SolidColorBrush(Colors.Black)
      };
      //Define the SymbolSource with SymbolCollection.
      stencil.SymbolSource = new SymbolCollection();

      //Initialize the diagram element.
      NodeViewModel node = new NodeViewModel()
      {
        UnitHeight = 70,
        UnitWidth = 100,
        OffsetX = 100,
        OffsetY = 100,
        Shape = App.Current.MainWindow.Resources["Rectangle"],
      };

      ConnectorViewModel cvm = new ConnectorViewModel()
      {
        SourcePoint = new Point(100, 100),
        TargetPoint = new Point(200, 200),
      };

      GroupViewModel grp = new GroupViewModel()
      {
        Nodes = new NodeCollection()
    {
       new NodeViewModel()
       {
         ID="srcnode",
         UnitHeight=70,
         UnitWidth=100,
         OffsetX=0,
         OffsetY=300,
         Shape=App.Current.Resources["Rectangle"]
        },
       new NodeViewModel()
       {
        ID="tarnode",
        UnitHeight=70,
        UnitWidth=100,
        OffsetX=100,
        OffsetY=500,
        Shape=App.Current.Resources["Rectangle"]
        }
    },
        Connectors = new ConnectorCollection()
    {
      new ConnectorViewModel()
      {
        SourceNodeID="srcnode",
        TargetNodeID="tarnode"
      }
    }
      };
      //Adding an element to the collection.
      (stencil.SymbolSource as SymbolCollection).Add(node);
      (stencil.SymbolSource as SymbolCollection).Add(cvm);
      (stencil.SymbolSource as SymbolCollection).Add(grp);
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
  public class SymbolCollection : ObservableCollection<object>
  {
  }
}
