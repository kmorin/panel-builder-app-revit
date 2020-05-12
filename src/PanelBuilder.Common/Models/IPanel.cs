using System.Collections.Generic;

namespace PanelBuilder.Common.Models
{
  public interface IPanel
  {
    string Name { get; set; }
    string DistSystemName { get; set; }
    string AicRating { get; set; }
    double BusRating { get; set; }
    string Mains { get; set; }
    string CircuitLoadClassification { get; set; }
    string FilePath { get; set; }
    List<ICircuit> Circuits { get; set; }
    double McbRating { get; set; }
    string Mounting { get; set; }
  }
}