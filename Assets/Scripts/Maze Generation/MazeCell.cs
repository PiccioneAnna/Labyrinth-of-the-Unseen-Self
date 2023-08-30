using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField] GameObject _leftWall;
    [SerializeField] GameObject _rightWall;
    [SerializeField] GameObject _topWall;
    [SerializeField] GameObject _bottomWall;

    [SerializeField] GameObject _unvisitedTile;

    public bool IsVisited { get; private set; }

    public void Visit()
    {
        IsVisited = true;
        _unvisitedTile.SetActive(false);
    }

    public void ClearLeftWall()
    {
        _leftWall.SetActive(false);
    }

    public void ClearRightWall() 
    {
        _rightWall.SetActive(false);
    }

    public void ClearTopWall() 
    { 
        _topWall.SetActive(false);
    }

    public void ClearBottomWall() 
    {
        _bottomWall.SetActive(false);
    }
}
