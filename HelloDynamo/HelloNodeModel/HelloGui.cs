using System;
using System.Collections.Generic;
using Dynamo.Graph.Nodes;
using HelloDynamo.Hello;
using ProtoCore.AST.AssociativeAST;

namespace HelloDynamo.HelloNodeModel
{
  /// <summary>
  /// Sample NodeModel with custom Gui
  /// </summary>
  [NodeName("HelloGui")]
  [NodeDescription("Example Node Model, multiplies A x the value of the slider")]
  [NodeCategory("HelloDynamo")]
  [InPortNames("A")]
  [InPortTypes("double")]
  [InPortDescriptions("Number A")]
  [OutPortNames("C")]
  [OutPortTypes("double")]
  [OutPortDescriptions("Product of AxSlider")]
  [IsDesignScriptCompatible]
  public class HelloGui : NodeModel
  {
    private double _sliderValue;


    public double SliderValue
    {
      get { return _sliderValue; }
      set
      {
        _sliderValue = value; 
        RaisePropertyChanged("SliderValue");
        OnNodeModified(false);
      }
    }

    public HelloGui()
    {
      RegisterAllPorts();
    }

    public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
    {
      if (!HasConnectedInput(0))
      {
        return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), AstFactory.BuildNullNode()) };
      }
      var sliderValue = AstFactory.BuildDoubleNode(SliderValue);
      var functionCall =
        AstFactory.BuildFunctionCall(
          new Func<double, double, double>(SampleFunctions.MultiplyTwoNumbers),
          new List<AssociativeNode> { inputAstNodes[0], sliderValue });

      return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), functionCall) };
    }
  }
}
