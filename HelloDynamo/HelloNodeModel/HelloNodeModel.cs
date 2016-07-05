using System;
using System.Collections.Generic;
using Dynamo.Graph.Nodes;
using HelloDynamo.Hello;
using ProtoCore.AST.AssociativeAST;

namespace HelloDynamo.HelloNodeModel
{
  /// <summary>
  /// Sample NodeModel 
  /// In order to execute AstFactory.BuildFunctionCall 
  /// the methods have to be in a separate assembly and be loaded by Dynamo separately
  /// File pkg.json defines which dll are loaded
  /// </summary>
  [NodeName("HelloNodeModel")]
  [NodeDescription("Example Node Model, multiplies AxB")]
  [NodeCategory("HelloDynamo")]
  [InPortNames("A", "B")]
  [InPortTypes("double", "double")]
  [InPortDescriptions("Number A", "Numnber B")]
  [OutPortNames("C")]
  [OutPortTypes("double")]
  [OutPortDescriptions("Product of AxB")]
  [IsDesignScriptCompatible]
  public class HelloNodeModel : NodeModel
  {
    public HelloNodeModel()
    {
      RegisterAllPorts();
    }

    public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
    {
      if (!HasConnectedInput(0) || !HasConnectedInput(1))
      {
        return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), AstFactory.BuildNullNode()) };
      }

      var functionCall =
        AstFactory.BuildFunctionCall(
          new Func<double, double, double>(SampleFunctions.MultiplyTwoNumbers),
          new List<AssociativeNode> { inputAstNodes[0], inputAstNodes[1] });

      return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), functionCall) };
    }
  }
}
