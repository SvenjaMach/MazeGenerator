using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace MazeGenerator.Models
{
  
  [Serializable]
  public class BlockPosition
  {
    [Key]
    public long id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

  }
}
