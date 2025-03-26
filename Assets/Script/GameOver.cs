using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject restartButton; // Assign in Inspector

    void Start()
    {
        restartButton.SetActive(false); // Hide button at start
    }

    public void ShowRestartButton()
    {
        restartButton.SetActive(true); // Show button when Jammo dies
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload scene
    }
}
