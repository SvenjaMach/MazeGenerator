using MazeGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace MazeGenerator.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly MazeContext _context;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, MazeContext context)
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    public MazePositions Get()
    {
      MazePositions cont = new MazePositions();
      MazeGenerator gen = new MazeGenerator();
      cont.maze = gen.generateMaze();
      foreach(BlockPosition block in cont.maze)
      {
        _context.BlockPositions.Add(block);
      }
      _context.SaveChanges();

      return cont;
    }

    [HttpPost]
    public MazePositions POST(BoolHelper newMaze)
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

