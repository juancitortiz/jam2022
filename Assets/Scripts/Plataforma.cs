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
    [SerializeField]
    private GameObject gato;
    public bool player1;

    private void Start()
    {
        int xCoso = Random.Range(0, gridWidth);
        int yCoso = Random.Range(0, gridHeight);
        grid = new Grid(gridWidth, gridHeight, cellSize, this.transform.position);
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                GameObject nuevoCubo = Instantiate(cubo, grid.GetWorldPositionTopY(i, j), Quaternion.identity);
                nuevoCubo.transform.SetParent(this.transform, true);

                if(i == xCoso && j == yCoso)
                {
                    GameObject nuevoGato = Instantiate(gato, grid.GetWorldPosition(i, (int)transform.position.y + 2, j), Quaternion.identity);
                    nuevoGato.GetComponent<Gato>().player1 = player1;
                }
            }
        }
    }

}
