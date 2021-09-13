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
        Content = "Name"
      };
      DiagramMenuItem menu1 = new DiagramMenuItem()
      {
        Content = "Value"
      };
      DiagramMenuItem menu2 = new DiagramMenuItem()
      {
        Content = "Unit",
      };
      (diagram.Info as IGraphInfo).MenuItemClickedEvent += MainPage_MenuItemClickedEvent;
      diagram.Menu.MenuItems.Add(menu);
      diagram.Menu.MenuItems.Add(menu1);
      diagram.Menu.MenuItems.Add(menu2);
      
    }
    void MainPage_MenuItemClickedEvent(object sender, MenuItemClickedEventArgs args)
    {
      //Source – in which object Event get fired
      //Item - MenuItem
    }
  }
  
}
