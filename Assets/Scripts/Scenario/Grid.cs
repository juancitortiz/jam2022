using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;

    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        this.gridArray = new int[width, height];

        SetDebugLines();
    }
    private void SetDebugLines()
    {
        int x = 0;
        int y = 0;
        for (x = 0; x < gridArray.GetLength(0); x++)
        {
            for (y = 0; y < gridArray.GetLength(1); y++)
            {
                Debug.DrawLine(GetWorldPositionTopY(x, y), GetWorldPositionTopY(x, y + 1), Color.red, 1000f);
                Debug.DrawLine(GetWorldPositionTopY(x, y), GetWorldPositionTopY(x + 1, y), Color.red, 1000f);
            }
            Debug.DrawLine(GetWorldPositionTopY(x, y), GetWorldPositionTopY(x + 1, y), Color.red, 1000f);
        }
        Debug.DrawLine(GetWorldPositionTopY(width, 0), GetWorldPositionTopY(width, height), Color.red, 1000f);
    }

    public Vector3 GetWorldPosition(int x, int y, int z)
    {
        return new Vector3(x, y, z) * this.cellSize + this.originPosition;
    }
    public Vector3 GetWorldPositionTopY(int x, int y)
    {
        return new Vector3(x, 0, y) * this.cellSize + this.originPosition;
    }
    public int GetCellValue(int x, int y)
    {
        if (IndexesAreInRange(x, y))
        {
            Debug.Log($"GetValue [{x}, {y}] = {gridArray[x, y]}");
            return gridArray[x, y];
        }
        else
        {
            Debug.Log($"GetValue [{x}, {y}] = 0. Invalid indexes.");
            return 0;
        }
    }

    public void GetCellValue(Vector3 worldPosition)
    {
        int x, y;
        GetXZ(worldPosition, out x, out y);
        GetCellValue(x, y);
    }
    private void GetXZ(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - this.originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - this.originPosition).z / cellSize);
    }
    private bool IndexesAreInRange(int x, int y)
    {
        return (x >= 0 && x < width && y >= 0 && y < height);
    }
}
