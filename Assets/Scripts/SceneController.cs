using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public static SceneController Instance; 

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public string CurrentScene() {
        Scene currentScene = SceneManager.GetActiveScene();
        return currentScene.name ;
    }

    public void StartGame() {
        SceneManager.LoadScene("Level1");
    }
    public void Instructions() {
        SceneManager.LoadScene("Instructions");
    }
    public void Credits() {
        SceneManager.LoadScene("Credits");
    }
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel() {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
