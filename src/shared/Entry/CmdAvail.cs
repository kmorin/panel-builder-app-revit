using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace PanelBuilder.Revit.Entry
{
  public class CmdAvail : IExternalCommandAvailability
  {
    public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
    {
      return applicationData.ActiveUIDocument != null && !applicationData.ActiveUIDocument.Document.IsFamilyDocument;
    }
  }
}