using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    public void LoadLevel(string levelName) {
        SceneManager.LoadSceneAsync(levelName);
    }
    
    public void LoadNextLevel() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void ReloadLevel() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}