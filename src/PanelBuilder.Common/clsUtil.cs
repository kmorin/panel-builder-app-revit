using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PanelBuilder.Common
{
  public class clsUtil
  {
    private const string LogFilename = "panelBuilderApp.log";

    public static void LogEvent(string message, Exception ex = null)
    {
      using (StreamWriter sw = new StreamWriter(GetLogFilename(), true))
      {
        string logString = $"{DateTime.Now}\t{message}";
        if (ex != null) logString += $"\t{ex}";

        sw.WriteLine(logString);
        sw.Close();
      }
    }

    private static string GetLogFilename()
    {
      //location
      DirectoryInfo appDir = Directory.GetParent(Assembly.GetExecutingAssembly().Location);

      return Path.Combine(appDir.FullName, LogFilename);
    }
  }

}
