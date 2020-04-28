using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
using PanelBuilder.Common;

namespace PanelBuilder.Revit.Entry
{
  public class clsApp : IExternalApplication
  {
    private UIControlledApplication _uiControlledApp;

    public Result OnStartup(UIControlledApplication application)
    {
      _uiControlledApp = application;
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
        _uiControlledApp.CreateRibbonTab(tabName);
      }
      catch
      {//do nothing, tab exists.
      }

      //Panel
      RibbonPanel panel = _uiControlledApp.CreateRibbonPanel(tabName, panelName);

      //Buttons
      string dllPath = Assembly.GetExecutingAssembly().Location;
      string m_namespace = typeof(clsApp).Namespace;

      PushButtonData panelBuilderPushButtonData =
        GetPushButtonData(dllPath,
          nameof(CmdBuildPanels),
          "BuildPanels",
          "save_16.png",
          "save_32.png",
          "access the panel builder",
          $"{m_namespace}.{nameof(CmdAvail)}"
        );

      // Add the buttons to the panel
      panel.AddItem(panelBuilderPushButtonData);
    }

    private PushButtonData GetPushButtonData(string dllPath,
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
        clsUtil.LogEvent(nameof(GetPushButtonData), ex);
      }

      return null;
    }

    /// <summary>
    /// Loads the icons
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private ImageSource LoadPngImgSource(string name)
    {
      name = $"PanelBuilder.Revit.img.{name}";
      try
      {
        Assembly m_assembly = Assembly.GetExecutingAssembly();
        Stream m_icon = m_assembly.GetManifestResourceStream(name);
        if (m_icon != null)
        {
          PngBitmapDecoder m_decoder = new PngBitmapDecoder(
            m_icon,
            BitmapCreateOptions.PreservePixelFormat,
            BitmapCacheOption.Default);
          return m_decoder.Frames[0];
        }
      }
      catch (Exception ex)
      {
        clsUtil.LogEvent(nameof(LoadPngImgSource), ex);
      }

      return null;
    }
  }
}