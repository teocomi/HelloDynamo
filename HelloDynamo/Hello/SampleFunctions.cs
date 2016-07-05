using Autodesk.DesignScript.Runtime;

namespace HelloDynamo.Hello
{
  /// <summary>
  /// In order to be executed by the NodeModel AstFactory.BuildFunctionCall 
  /// these methods have to be in a separate assembly and be loaded by Dynamo separately
  /// File pkg.json defines which dll are loaded
  /// </summary>
  [IsVisibleInDynamoLibrary(false)]
  public class SampleFunctions
  {
    public static double MultiplyTwoNumbers(double a, double b)
    {
      return a * b;
    }
  }
}
