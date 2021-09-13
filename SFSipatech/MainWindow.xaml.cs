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
      (diagram.Info as IGraphInfo).ItemDropEvent += MainWindow_ItemDropEvent;
      (diagram.Info as IGraphInfo).ItemAdded += MainWindow_ItemAdded;
    }
    void MainPage_MenuItemClickedEvent(object sender, MenuItemClickedEventArgs args)
    {
      //Source – in which object Event get fired
      //Item - MenuItem
    }
    private void MainWindow_ItemDropEvent(object sender, ItemDropEventArgs args)
    {
      //UNDONE: Set Node properties
      //To cancel item drop if symbols are basic shapes.
      if (args.ItemSource == Cause.Stencil && args.Source is INode && (args.Source as INode).Key.ToString() == "Basic Shapes")
      {
        args.Cancel = true;
      }
    }
    private void MainWindow_ItemAdded(object sender, ItemAddedEventArgs args)
    {
      if (args.Item is CustomNode)
      {
        CustomNode node = args.Item as CustomNode;
        //content and contenttemplate returns null, so we have used the CustomContent and CustomContentTemplate properties to restore its values. 
        //node.Content = node.CustomContent;
        //node.ContentTemplate = App.Current.MainWindow.Resources[node.CustomContentTemplate] as DataTemplate;
      }
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
          var dttemplate = this.Resources["viewtemplate"] as DataTemplate;
          dttemplate.Resources["Content"] = "/Images/fan.png";
          //var menus = new ObservableCollection<DiagramMenuItem>();
          var obj = new List<CustomProperties>();
          foreach (var p in nd.Properties)
          {
            obj.Add(new CustomProperties { Key = p.key, Value = p.value });
            //menus.Add(new DiagramMenuItem { Content = p.key });
          }
          
          SymbolViewModel mynode = new SymbolViewModel()
          {
            Symbol = obj,
            Key = Guid.NewGuid(),
            Name = nd.Name,
            //Content = "/Images/fan.png",
            //Menu = new DiagramMenu { MenuItems = menus},
            //ContentTemplate = this.Resources["viewtemplate"] as DataTemplate
            SymbolTemplate = dttemplate // this.Resources["viewtemplate"] as DataTemplate
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
  public class CustomProperties
  {
    public string Key { get; set; }
    public string Value { get; set; }
  }
}
