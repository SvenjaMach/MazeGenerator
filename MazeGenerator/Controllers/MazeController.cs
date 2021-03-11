using MazeGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace MazeGenerator.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MazeGeneratorController : ControllerBase
  {
    private readonly ILogger<MazeGeneratorController> _logger;
    private readonly MazeContext _context;

    public MazeGeneratorController(ILogger<MazeGeneratorController> logger, MazeContext context)
    {
      _logger = logger;
      _context = context;
    }

    [HttpPost]
    public MazePositions PostMaze(BoolHelper newMaze)
    {
      if (newMaze.isNewMaze)
      {
        _context.BlockPositions.RemoveRange(_context.BlockPositions);

        MazePositions cont = new MazePositions();
        MazeGenerator gen = new MazeGenerator();
        cont.maze = gen.generateMaze();
        foreach (BlockPosition block in cont.maze)
        {
          _context.BlockPositions.Add(block);
        }

        _context.SaveChanges();
        return cont;
      }
      else
      {
        MazePositions cont = new MazePositions
        {
          maze = new System.Collections.Generic.List<BlockPosition>()
        };
        cont.maze = _context.BlockPositions.ToList();

        return cont;
      }
    }
  }
}

