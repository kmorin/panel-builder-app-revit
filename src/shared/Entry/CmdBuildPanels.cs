using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace PanelBuilder.Revit.Entry
{
  public class CmdBuildPanels : IExternalCommand
  {
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
      UIDocument uiDoc= commandData.Application.ActiveUIDocument;
      Document doc = uiDoc.Document;

      //TODO:externalize load calc multiplier
      double loadMultiplier = 0.0929;

      return Result.Succeeded;
    }
  }
}
