using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazeGenerator.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public MazePositions Get()
    {
      var rng = new Random();

      MazePositions cont = new MazePositions();
      cont.maze = new List<BlockPosition>();

      cont.maze.Add(
        new BlockPosition
        {
          X=-3,
          Y=-4
        });

      cont.maze.Add(
      new BlockPosition
      {
        X = -4,
        Y = -4
      });

      return cont;
    }
  }
}

