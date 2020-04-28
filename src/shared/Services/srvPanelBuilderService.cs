using System.Collections.Generic;
using System.Threading.Tasks;
using PanelBuilder.Common;
using PanelBuilder.Common.Models;

namespace PanelBuilder.Revit.Entry
{
  public class srvPanelBuilderService
  {
    private clsApiConnector _apiConnector;

    public srvPanelBuilderService()
    {
      _apiConnector = new clsApiConnector();

    }

    public async Task<List<IPanel>> GetPanelsIndex()
    {
      var allPanelsList = new List<IPanel>();

      //TODO: Fetch the panels from web
      var result = await _apiConnector.FetchPanelsIndex();

      //TODO: Deserialize object result.
      
      return allPanelsList;
    }
  }
}