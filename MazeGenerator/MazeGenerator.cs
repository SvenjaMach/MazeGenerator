using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazeGenerator
{

  public class MazeGenerator
  {
    readonly int Width = 17;
    readonly int Height = 9;

    public List<Models.BlockPosition> generateMaze()
    {
      var rng = new Random();
      bool[,] completeMaze = new bool[Width, Height];
      for (int i = 0; i < Width; i++)
      {
        for (int j = 0; j < Height; j++)
        {
          if (i % 2 == 0 && j % 2 == 0)
          {
            completeMaze[i, j] = true;
          }
          else
          {
            completeMaze[i, j] = false;
          }
        }
      }

      MazeCell[,] mazeCells = new MazeCell[(Width + 1) / 2, (Height + 1) / 2];
      for (int i = 0; i < (Width + 1) / 2; i++)
      {
        for (int j = 0; j < (Height + 1) / 2; j++)
        {
          mazeCells[i, j] = new MazeCell
          {
            X = i,
            Y = j,
            visited = false
          };
        }
      }

      Stack<MazeCell> visitedStack = new Stack<MazeCell>();
      MazeCell current = mazeCells[rng.Next(0, 8), rng.Next(0, 4)]; //0,3
      current.visited = true;
      visitedStack.Push(current);

      while (isUnvisitedLeft(mazeCells))
      {
        current = visitedStack.Pop();
        if (HasUnvisitedNeighbour(mazeCells, current))
        {
          visitedStack.Push(current);
          MazeCell neighbour = getUnvisitedNeighbour(mazeCells, current, rng);

          completeMaze[(current.X + neighbour.X), (current.Y + neighbour.Y)] = true;

          current = neighbour;
          current.visited = true;
          visitedStack.Push(current);
        }
      }

      return generateList(completeMaze);
    }

    private List<Models.BlockPosition> generateList(bool[,] completeMaze)
    {
      List<Models.BlockPosition> maze = new List<Models.BlockPosition>();
      for (int i = 0; i < Width; i++)
      {
        for (int j = 0; j < Height; j++)
        {
          if (completeMaze[i, j] == false)
          {
            maze.Add(new Models.BlockPosition { X = i * 3, Y = j * 3 });
            maze.Add(new Models.BlockPosition { X = i * 3, Y = j * 3 + 1 });
            maze.Add(new Models.BlockPosition { X = i * 3, Y = j * 3 + 2 });

            maze.Add(new Models.BlockPosition { X = i * 3 + 1, Y = j * 3 });
            maze.Add(new Models.BlockPosition { X = i * 3 + 1, Y = j * 3 + 1 });
            maze.Add(new Models.BlockPosition { X = i * 3 + 1, Y = j * 3 + 2 });

            maze.Add(new Models.BlockPosition { X = i * 3 + 2, Y = j * 3 });
            maze.Add(new Models.BlockPosition { X = i * 3 + 2, Y = j * 3 + 1 });
            maze.Add(new Models.BlockPosition { X = i * 3 + 2, Y = j * 3 + 2 });
          }
        }
      }
      return maze;

    }

    bool isUnvisitedLeft(MazeCell[,] mazeCells)
    {
      foreach (MazeCell cell in mazeCells)
      {
        if (cell.visited == false)
        {
          return true;
        }
      }
      return false;
    }

    MazeCell getUnvisitedNeighbour(MazeCell[,] maze, MazeCell current, Random rng)
    {
      List<MazeCell> unvisitedNeighbours = new List<MazeCell>();
      if (current.X > 0)
      {
        if (maze[current.X - 1, current.Y].visited == false)
        {
          unvisitedNeighbours.Add(maze[current.X - 1, current.Y]);
        }
      }

      if (current.X < (Width - 1) / 2)
      {
        if (maze[current.X + 1, current.Y].visited == false)
        {
          unvisitedNeighbours.Add(maze[current.X + 1, current.Y]);
        }
      }

      if (current.Y > 0)
      {
        if (maze[current.X, current.Y - 1].visited == false)
        {
          unvisitedNeighbours.Add(maze[current.X, current.Y - 1]);
        }
      }

      if (current.Y < (Height - 1) / 2)
      {
        if (maze[current.X, current.Y + 1].visited == false)
        {
          unvisitedNeighbours.Add(maze[current.X, current.Y + 1]);
        }
      }
      int rand = rng.Next(0, unvisitedNeighbours.Count - 1);
      return unvisitedNeighbours.ElementAt(rand);
    }

    bool HasUnvisitedNeighbour(MazeCell[,] maze, MazeCell current)
    {
      if (current.X > 0)
      {
        if (maze[current.X - 1, current.Y].visited == false)
        {
          return true;
        }
      }

      if (current.X < (Width - 1) / 2)
      {
        if (maze[current.X + 1, current.Y].visited == false)
        {
          return true;
        }
      }

      if (current.Y > 0)
      {
        if (maze[current.X, current.Y - 1].visited == false)
        {
          return true;
        }
      }

      if (current.Y < (Height - 1) / 2)
      {
        if (maze[current.X, current.Y + 1].visited == false)
        {
          return true;
        }
      }

      return false;
    }
  }
}
