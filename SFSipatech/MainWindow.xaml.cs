using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
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

namespace SFSipatech
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      SfSkinManager.SetTheme(this, new Theme() { ThemeName = "Office2019Colorful" });
      diagram.PageSettings.PageBorderBrush = new SolidColorBrush(Colors.Transparent);
      DiagramMenuItem menu = new DiagramMenuItem()
      {
        Content = "Properties"
      };
      (diagram.Info as IGraphInfo).MenuItemClickedEvent += MainPage_MenuItemClickedEvent;
      diagram.Menu.MenuItems.Add(menu);
      AddStensil();
      
    }
    void MainPage_MenuItemClickedEvent(object sender, MenuItemClickedEventArgs args)
    {
      //Source – in which object Event get fired
      //Item - MenuItem
    }
    public void AddStensil()
    {
      
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
  }
  public class SymbolCollection : ObservableCollection<Object>
  {
  }

}
