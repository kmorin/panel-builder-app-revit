using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using Autodesk.Revit.UI;
using PanelBuilder.Common;

namespace PanelBuilder.Revit.Entry
{
  public class clsApp : IExternalApplication
  {
    private UIControlledApplication _uiControlledapp;

    public Result OnStartup(UIControlledApplication application)
    {
      _uiControlledapp = application;
      return Bootstrap();
    }

    public Result OnShutdown(UIControlledApplication application)
    {
      return Result.Succeeded;
    }

    /// <summary>
    ///   Perform the app bootstrap
    /// </summary>
    /// <returns></returns>
    private Result Bootstrap()
    {
      //set bindings.
      try
      {
        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(CultureInfo.InstalledUICulture.Name);

        //TODO: SetConfig();

        SetupButtons();
      }
      catch (Exception e)
      {
        clsUtil.LogEvent(nameof(Bootstrap), e);
        return Result.Failed;
      }

      return Result.Succeeded;
    }

    /// <summary>
    /// Build button(s) for toolbar
    /// </summary>
    private void SetupButtons()
    {
      string tabName = "Panel Builder App";
      string panelName = "Build Panels";

      try
      {
        _uiControlledapp.CreateRibbonTab(tabName);
      }
      catch
      {//do nothing, tab exists.
      }

      //Panel
      RibbonPanel panel = _uiControlledapp.CreateRibbonPanel(tabName, panelName);

      //Buttons
      string dllPath = Assembly.GetExecutingAssembly().Location;
      string m_namespace = typeof(clsApp).Namespace;

      PushButtonData panelBuilderPushButtonData = 
        GetPushbuttonData(dllPath,
          nameof(CmdBuildPanels),
          //Text,
          //"image16.png",
          //"image32.png,
          //tootip,
          //commandAvail)
    }

    private PushButtonData GetPushbuttonData(string dllPath,
      string className,
      string buttonText,
      string image16,
      string image32,
      string toolTip,
      string commandAvailability = ""
    )
    {
      try
      {
        // Make sure the File Exists
        if (!File.Exists(dllPath)) return null;

        PushButtonData m_pb =
          new PushButtonData(className, buttonText, dllPath, $"{typeof(clsApp).Namespace}.{className}")
          {
            Image = LoadPngImgSource(image16),
            LargeImage = LoadPngImgSource(image32),
            ToolTip = toolTip
          };

        // ActionName Availability
        if (!string.IsNullOrEmpty(commandAvailability)) m_pb.AvailabilityClassName = commandAvailability;

        return m_pb;
      }
      catch (Exception ex)
      {
        clsUtil.LogEvent(nameof(GetPushbuttonData), ex);
      }

      return null;
    }
  }
}