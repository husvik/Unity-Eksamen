using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneLoader : MonoBehaviour {

    private GameControlScript _gameControlScript;

    void Start() {
        _gameControlScript = FindObjectOfType<GameControlScript>();
    }
    public void LoadScene() {
        SceneManager.LoadScene("Main");
    }
    public void LoadCredits() {
        SceneManager.LoadScene("Credits");
    }
    public void Resume() {
        _gameControlScript.resume();
    }
    public void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }
    public void LoadControls() {
        SceneManager.LoadScene("Controls");
    }
    public void RIP() {
        Application.Quit();
    }
}
