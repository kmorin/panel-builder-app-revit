using System.Collections.Generic;
using System.Text.Json;
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
    public async Task TestDeserialize()
    {
      var res =
        "[{\"name\":\"Panel1\",\"description\":\"Panel Desc\",\"id\":1,\"distSystemName\":\"120/208v\",\"aicRating\":\"10000\",\"busRating\":400,\"mains\":\"400\",\"circuitLoadClassification\":\"Lighting\",\"filePath\":\"c\",\"circuits\":null,\"mcbRating\":400,\"mounting\":\"Surface\",\"createdAt\":\"2020-05-12T11:41:10.0234\",\"updatedAt\":null,\"deletedAt\":null},{\"name\":\"PanelCircs2\",\"description\":\"Panel Desc\",\"id\":3,\"distSystemName\":\"120/208v\",\"aicRating\":\"10000\",\"busRating\":400,\"mains\":\"400\",\"circuitLoadClassification\":\"Lighting\",\"filePath\":\"c\",\"circuits\":null,\"mcbRating\":400,\"mounting\":\"Surface\",\"createdAt\":\"2020-05-12T11:42:58.66806\",\"updatedAt\":null,\"deletedAt\":null}]";

      var des = JsonSerializer.Deserialize<List<clsPanel>>(res);
      Assert.NotNull(des);
      Assert.IsAssignableFrom(typeof(clsPanel), des);
    }

    [Test]
    public async Task TestFetchAllPanels()
    {
      List<clsPanel> result = await _apiConnector.FetchPanelsIndex();

      Assert.NotNull(result);
    }
  }
}
