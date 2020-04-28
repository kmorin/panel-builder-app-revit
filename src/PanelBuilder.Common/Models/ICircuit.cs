using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanelBuilder.Common.Models
{
  public interface ICircuit
  {
    string Description { get; set; }
    int Load { get; set; }
    int NumPoles { get; set; }
    int Number { get; set; }
    int Rating { get; set; }
    string CircuitType { get; set; }
  }
}
