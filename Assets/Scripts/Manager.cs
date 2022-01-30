using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private int[] score = new int[2];
    [SerializeField]
    private Plataforma[] platforms;
    [SerializeField]
    private Sea sea;
    [SerializeField]
    private UIManager UI;

    public delegate void ChangeScore(int value, int value2);
    public event ChangeScore OnChangeScore;

    private void Awake()
    {
        platforms = GetComponentsInChildren<Plataforma>();
        sea = GetComponentInChildren<Sea>();
        sea.OnCatFall += EndGame;
        if (UI != null)
            UI.OnEndGame += EndMatch;
    }

    private void EndGame(Gato gato)
    {
        if (gato.player1)
            score[1]++;
        else
            score[0]++;
        OnChangeScore?.Invoke(score[0], score[1]);
        foreach (Plataforma platform in platforms)
        {
            platform.DeleteAll();
            platform.Generate();
        }
    }

    private void EndMatch(int player)
    {
        if(player == 1)
        {

        }
        else
        {

        }
        SceneManager.LoadScene("MainScene");
    }

    private void OnDisable()
    {
        sea.OnCatFall -= EndGame;
        UI.OnEndGame -= EndMatch;
    }
}
