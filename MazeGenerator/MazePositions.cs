using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazeGenerator
{
  [Serializable]
  public class MazePositions
  {
    public List<BlockPosition> maze { get; set; }
  }
}
