using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private int[] score = new int[2];
    [SerializeField]
    private Plataforma[] platforms;
    [SerializeField]
    private Sea sea;

    public delegate void ChangeScore(int value);
    public event ChangeScore OnChangeScore;

    private void Awake()
    {
        platforms = GetComponentsInChildren<Plataforma>();
        sea = GetComponentInChildren<Sea>();
        sea.OnCatFall += EndGame;
    }

    private void EndGame(Gato gato)
    {
        if (gato.player1)
            score[1]++;
        else
            score[0]++;
        foreach (Plataforma platform in platforms)
        {
            platform.DeleteAll();
            platform.Generate();
        }
    }

    private void OnDisable()
    {
        sea.OnCatFall -= EndGame;
    }
}
