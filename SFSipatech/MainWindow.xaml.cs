using Newtonsoft.Json;
using SFSipatech.Models;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
      //DiagramMenuItem menu = new DiagramMenuItem()
      //{
      //  Content = "Properties"
      //};
      //(diagram.Info as IGraphInfo).MenuItemClickedEvent += MainPage_MenuItemClickedEvent;
      //diagram.Menu.MenuItems.Add(menu);
      AddStensil();
      
    }
    void MainPage_MenuItemClickedEvent(object sender, MenuItemClickedEventArgs args)
    {
      //Source – in which object Event get fired
      //Item - MenuItem
    }
    public void AddStensil()
    {
      try
      {
        stencil.SymbolSource = new SymbolCollection();
        //var path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "\\CustomNodes.json");
        string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"CustomNodes.json");
        List<CustomNode> nodes = JsonConvert.DeserializeObject<List<CustomNode>>(File.ReadAllText(path));
        foreach (var nd in nodes)
        {
          SymbolViewModel mynode = new SymbolViewModel()
          {
            Symbol = nd.Name,
            Key = Guid.NewGuid(),
            Name = nd.Name,
            //Menu = new MenuItem { Name }
            SymbolTemplate = this.Resources["symboltemplate"] as DataTemplate
          };
          (stencil.SymbolSource as SymbolCollection).Add(mynode);
        }
      }
      catch (Exception ex)
      {
        var er = ex;
      }
    }
  }
  public class SymbolCollection : ObservableCollection<Object>
  {
  }

}
