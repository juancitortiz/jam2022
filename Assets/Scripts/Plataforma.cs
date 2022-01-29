using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private Grid grid;
    [SerializeField]
    private int gridWidth;
    [SerializeField]
    private int gridHeight;
    [SerializeField]
    private float cellSize;
    [SerializeField]
    private GameObject cubo;

    private void Start()
    {
        grid = new Grid(gridWidth, gridHeight, cellSize, Vector3.zero);
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                GameObject nuevoCubo = Instantiate(cubo, grid.GetWorldPositionTopY(i, j), Quaternion.identity);
                nuevoCubo.transform.SetParent(this.transform, true);
            }
        }
    }

}
