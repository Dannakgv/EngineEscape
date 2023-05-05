using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    public void ContinueToNextLevel()
    {
        // Cambiar al siguiente nivel (Asumiendo que tu escena de nivel 2 se llama "Level2")
        SceneManager.LoadScene("SolveRisks");
    }
}
