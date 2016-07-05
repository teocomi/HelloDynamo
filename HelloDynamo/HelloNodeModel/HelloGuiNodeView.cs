using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamo.Controls;
using Dynamo.Wpf;

namespace HelloDynamo.HelloNodeModel
{
  public class HelloGuiNodeView : INodeViewCustomization<HelloGui>
  {
    public void CustomizeView(HelloGui model, NodeView nodeView)
    {
     var slider = new Slider();
      nodeView.inputGrid.Children.Add(slider);
      slider.DataContext = model;
    }

    public void Dispose()
    {
    }
  }
}
