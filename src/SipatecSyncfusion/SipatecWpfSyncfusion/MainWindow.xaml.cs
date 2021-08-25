using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Stencil;

namespace SIPATEC_POC
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    public MainWindow()
    {
      InitializeComponent();
      DefineStencil();
    }
    public void DefineStencil()
    {
      Stencil stencil = new Stencil()
      {
        ExpandMode = ExpandMode.All,
        BorderThickness = new Thickness(0, 0, 1, 0),
        BorderBrush = new SolidColorBrush(Colors.Black)
      };
    }
  }
}
