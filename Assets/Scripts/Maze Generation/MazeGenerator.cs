using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private MazeCell _mazeCellPrefab;
    [SerializeField] private int _mazeWidth;
    [SerializeField] private int _mazeHeight;

    private MazeCell[,] _mazeGrid;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        _mazeGrid = new MazeCell[_mazeWidth, _mazeHeight];

        for (int x = 0; x < _mazeWidth; x++)
        {
            for (int y = 0; y < _mazeHeight; y++)
            {
                _mazeGrid[x,y] = Instantiate(_mazeCellPrefab, new Vector3(x, y, 0), Quaternion.identity);
            }
        }

        yield return GenerateMaze(null, _mazeGrid[0, 0]);
    }

    private IEnumerator GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);

        //yield return new WaitForSeconds(0.05f);

        MazeCell nextCell;

        do
        {
            nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                yield return GenerateMaze(currentCell, nextCell);
            }

        } while (nextCell != null);
    }

    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if (previousCell == null)
        {
            return;
        }

        if (previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }

        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }

        if (previousCell.transform.position.y < currentCell.transform.position.y)
        {
            previousCell.ClearTopWall();
            currentCell.ClearBottomWall();
            return;
        }

        if (previousCell.transform.position.y > currentCell.transform.position.y)
        {
            previousCell.ClearBottomWall();
            currentCell.ClearTopWall();
            return;
        }
    }

    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    private IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        int x = (int)currentCell.transform.position.x;
        int y = (int)currentCell.transform.position.y;

        // Right
        if (x + 1 < _mazeWidth) 
        {
            var cellToRight = _mazeGrid[x + 1, y];
            if (!cellToRight.IsVisited)
            {
                yield return cellToRight;
            }
        }

        // Left
        if (x - 1 >= 0)
        {
            var cellToLeft = _mazeGrid[x - 1, y];
            if (!cellToLeft.IsVisited)
            {
                yield return cellToLeft;
            }
        }

        // Top
        if (y + 1 < _mazeHeight)
        {
            var cellToTop = _mazeGrid[x, y + 1];
            if (!cellToTop.IsVisited)
            {
                yield return cellToTop;
            }
        }

        // Bottom
        if (y - 1 >= 0)
        {
            var cellToBottom = _mazeGrid[x, y - 1];
            if (!cellToBottom.IsVisited)
            {
                yield return cellToBottom;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
