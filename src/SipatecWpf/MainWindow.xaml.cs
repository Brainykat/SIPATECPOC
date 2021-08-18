using MindFusion.Diagramming.Wpf;
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

namespace SipatecWpf
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
    private void diagram_NodeDeactivated(object sender, NodeEventArgs e) {}
    private void diagram_LinkClicked(object sender, LinkEventArgs e) { }
    private void diagram_NodeClicked(object sender, NodeEventArgs e) { }
    private void diagram_NodeActivated(object sender, NodeEventArgs e) { }
    private void diagram_DragOver(object sender, DragEventArgs e) { }
    private void diagram_Drop(object sender, DragEventArgs e) { }
  }
}
