using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using PanelBuilder.Common.Models;

namespace PanelBuilder.Common
{
  public class clsApiConnector : IApiConnector
  {
    private static string _baseApiUrl;
    private static string _apiPrefix;

    public async Task<List<IPanel>> FetchPanelsIndex()
    {
      var results = RestResponseGet("/panels");

      //TODO: deserialize response;


      return new List<IPanel>();

    }

    #region Private Methods

    /// <summary>
    /// Method to grab any response from a resource endpoint.
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    private static async Task<string> RestResponseGet(string resource)
    {
      WebRequest client = (HttpWebRequest)WebRequest.Create(_baseApiUrl + _apiPrefix + resource);
      
      //Auth'n

      byte[] bca = await GetByteContentArray(client);

      string res = $"{bca, 8}";
      return res;
    }

    private static async Task<byte[]> GetByteContentArray(WebRequest client)
    {
      var content = new MemoryStream();

      using (WebResponse response = await client.GetResponseAsync())
      {
        using (Stream responseStream = response.GetResponseStream())
        {
          await responseStream.CopyToAsync(content);
        }
      }
      return content.ToArray();
    }

    #endregion
  }
}
