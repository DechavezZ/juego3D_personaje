using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;

    private int score = 0;

    void Start()
    {
        score = PlayerPrefs.GetInt("HighScore", 0);
        ActualizarTexto();
    }

    public void SumarPunto()
    {
        score++;

        PlayerPrefs.SetInt("HighScore", score);

        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        scoreText.text = "Score: " + score;
    }
}