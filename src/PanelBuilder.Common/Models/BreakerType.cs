using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanelBuilder.Common.Models
{
  public static class BreakerType
  {
    public static string None => "NONE";
    public static string OnePole120 => "1 Pole 120 Breaker";
    public static string OnePole277 => "1 Pole 277 Breaker";
    public static string TwoPole208 => "2 Pole 208 Breaker";    
    public static string TwoPole480 => "2 Pole 480 Breaker";    
    public static string ThreePole208 =>"3 Pole 208 Breaker"; 
    public static string ThreePole480 => "3 Pole 480 Breaker";
  }
}
