using System.Collections.Generic;
namespace PanelBuilder.Common.Models
{
  public class clsPanel : IPanel
  {
    public string PanelName { get ; set ; }
    public string DistSystemName { get ; set ; }
    public string AicRating { get ; set ; }
    public double BusRating { get ; set ; }
    public string Mains { get ; set ; }
    public string CircuitLoadClassification { get ; set ; }
    public string FilePath { get ; set ; }
    public List<ICircuit> Circuits { get ; set ; }
    public double McbRating { get ; set ; }
    public string Mounting { get ; set ; }
  }
}