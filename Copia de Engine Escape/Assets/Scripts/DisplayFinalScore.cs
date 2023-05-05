using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayFinalScore : MonoBehaviour
{

    public TextMeshProUGUI finalScoreText; // referencia al componente de texto TextMeshPro en la UI
    public ScoreManager scoreManager; // referencia al administrador de puntuación


    void Start()
    {
        int finalScore = scoreManager.GetScore();
        finalScoreText.text = "Final Score: " + finalScore.ToString();
    }

}
