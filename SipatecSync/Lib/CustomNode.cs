using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Runtime.Serialization;

namespace SipatecSync.Lib
{
  public class CustomNode : NodeViewModel
  {
    public Guid Id { get; set; }
    public PropertyDatatype Datatype { get; set; }
    public string Value { get; set; }
    public string SIUnit { get; set; }
    public int Count { get; set; }

    private string _CustomContent;
    private string _CustomTemplate;

    
    [DataMember]
    public string CustomContent
    {
      get
      {
        return _CustomContent;
      }
      set
      {
        if (_CustomContent != value)
        {
          _CustomContent = value;
          Content = _CustomContent;
          OnPropertyChanged("CustomContent");
        }
      }
    }

    [DataMember]
    public string CustomTemplate
    {
      get
      {
        return _CustomTemplate;
      }
      set
      {
        if (_CustomTemplate != value)
        {
          _CustomTemplate = value;
          OnPropertyChanged("CustomTemplate");
        }
      }
    }
  }
}
