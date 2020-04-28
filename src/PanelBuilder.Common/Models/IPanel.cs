using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanelBuilder.Common.Models
{
  interface IPanel
  {
    string PanelName { get; set; }
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