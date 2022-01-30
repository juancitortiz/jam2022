using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Manager manager;
    [SerializeField]
    public Text score1;
    [SerializeField]
    public Text score2;

    public delegate void EndGame(int player);
    public event EndGame OnEndGame;

    private void Awake()
    {
        manager.OnChangeScore += UpdateScore;
        score1.text = "0";
        score2.text = "0";
    }

    private void UpdateScore(int value, int value2)
    {
        score1.text = value.ToString();
        score2.text = value2.ToString();
        if (score1.text.Equals("5") || score2.text.Equals("5"))
            OnEndGame?.Invoke(score1.text.Equals("5") ? 1 : 2);

    }

    private void OnDisable()
    {
        manager.OnChangeScore -= UpdateScore;
    }
}
