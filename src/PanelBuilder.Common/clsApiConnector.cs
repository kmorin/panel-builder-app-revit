using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using PanelBuilder.Common.Models;

namespace PanelBuilder.Common
{
  public class clsApiConnector : IApiConnector
  {
    private static string _baseApiUrl = "http://mustafar.local:5001";
    private static string _apiPrefix = "/api";

    public async Task<List<clsPanel>> FetchPanelsIndex()
    {
      Stream results = await RestResponseGet("/panels");
      List<clsPanel> panels = await JsonSerializer.DeserializeAsync<List<clsPanel>>(results);

      return panels;

    }

    public async Task<clsPanel> FetchPanelById(int id)
    {
      Stream result = await RestResponseGet($"/panels/{id}");
      clsPanel panel = await JsonSerializer.DeserializeAsync<clsPanel>(result);
      return panel;
    }

    #region Private Methods

    /// <summary>
    /// Method to grab any response from a resource endpoint.
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    private static async Task<Stream> RestResponseGet(string resource)
    {
      HttpClient client = new HttpClient();
      SetSecurityProtocols();
      client.BaseAddress = new Uri(_baseApiUrl);
      Stream streamTask = await client.GetStreamAsync( _apiPrefix + resource);
      return streamTask;
    }

    private static void SetSecurityProtocols()
    {
      ServicePointManager.SecurityProtocol =
        SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
    }
    #endregion
  }
}
