using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazeGenerator
{
  public class MazeCell
  {
    public int X { get; set; }
    public int Y { get; set; }
    public bool visited { get; set; } = false;
  }
}
