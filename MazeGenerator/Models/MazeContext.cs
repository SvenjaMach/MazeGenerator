using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MazeGenerator.Models
{
  public class MazeContext:DbContext
  {
    public MazeContext(DbContextOptions<MazeContext> options)
        : base(options)
    {
    }

    public DbSet<BlockPosition> BlockPositions { get; set; }
  }
}
