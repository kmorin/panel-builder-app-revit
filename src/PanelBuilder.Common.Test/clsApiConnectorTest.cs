using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using PanelBuilder.Common.Models;

namespace PanelBuilder.Common.Test
{
  [TestFixture]
  public class clsApiConnectorTest
  {
    private clsApiConnector _apiConnector;

    public clsApiConnectorTest()
    {
      _apiConnector = new clsApiConnector();
    }

    [Test]
    public async Task TestFetchAllPanels()
    {
      List<IPanel> result = await _apiConnector.FetchPanelsIndex();

      Assert.NotNull(result);
    }
  }
}
