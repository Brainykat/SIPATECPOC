using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSipatech.Models
{
  public class CustomNode
  {
    public string Name { get; set; }
    public List<Property> Properties { get; set; }
    public string DataTemplate { get; set; }
  }
  public class Property
  {
    public string key { get; set; }
    public string value {get;set;}
    public string type {get;set;}
  }
}
