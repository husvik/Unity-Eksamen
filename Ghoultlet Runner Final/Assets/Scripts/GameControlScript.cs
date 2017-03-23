using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour {
    public float ScrollSpeed = 25f; // Number of units we scroll each second.
    public float TimeExtension = 1.5f; // Time-extension (in seconds) for a pickup.
    public MoveGroundScript MoveGroundScript;
    private ScoreKeeperScript _scoreKeeperScript;
    public Text TimeLeft;
    public Text _totalTime;
    public float _shieldTime = 3;
    public GameObject _heartBeat;
    public GameObject _pause;
    public GameObject _powerupAlert;
    public GameObject _sound;

    public float _timeRemaining = 10;
    private float _totalTimeElapsed;
    private bool _isPause = false;
    public int _totTime;
    private GameObject _shield;
    private float _counter = 0;
    private int _timeLeft;
    private Color _startColor = new Color(0, 255, 0);

    void Start() {
        //On start
        _scoreKeeperScript = FindObjectOfType<ScoreKeeperScript>();
        _shield = GameObject.FindGameObjectWithTag("Shield");
        InitilizeVariables();
        _sound = GameObject.Find("Sound");
        _sound.GetComponent<AudioSource>().enabled = false;
    }

    private void InitilizeVariables() {
        //Time.timeScale = 1f;
        RestoreWorldSpeed();
        _totTime = 0;
    }
    
    public void PowerupCollected() {
        _timeRemaining += TimeExtension;
        _powerupAlert.SetActive(true);
        Invoke("PowerupAlertOff", 0.55f);
    }

    private void PowerupAlertOff() {
        _powerupAlert.SetActive(false);
    }

    public void SlowWorldDown() {
        CancelInvoke("RestoreWorldSpeed"); // Cancel any cued commands to restore world speed.
        Invoke("RestoreWorldSpeed", 1); // Speed the world up again after this duration.
        Time.timeScale = 0.5f;   
    }

    void RestoreWorldSpeed() {
        Time.timeScale = 1f;
    }

    public void DieCollide() {
        _timeRemaining = 0;
    }

    public bool ShieldCollide() {
        _counter = _shieldTime;
         return true;
    }

    public void resume() {
        _isPause = false;
        RestoreWorldSpeed();
    }

    void Update() {

        //Gameover
        if (_timeRemaining <= 0) {
            _scoreKeeperScript._totalScore = _totTime;
            SceneManager.LoadScene("EndScene");
        }

        //Pasue/Game control
        if (Input.GetKeyDown(KeyCode.P)) {
            _isPause = true;
        }
        if (_isPause) {
            _pause.SetActive(true);
            Time.timeScale = 0f;
        } else {
            _pause.SetActive(false);
            _totalTimeElapsed += Time.deltaTime;
            _timeRemaining -= Time.unscaledDeltaTime; // This one is not affected by timeScale.
            _totTime = (int)_totalTimeElapsed;
            _totalTime.text = "Total Time: " + _totTime.ToString();
            _timeLeft = (int)_timeRemaining;
            TimeLeft.text = "Time Left: " + _timeLeft.ToString();
            _counter -= Time.deltaTime;
        }

        //Shield control
        if (_counter <= 0) {
            _shield.SetActive(false);
        } else if (_counter > 0) {
            _shield.SetActive(true);
        }

        //UI effects
        if (_timeRemaining <= 5) {
            TimeLeft.color = new Color(255, 0, 0);
            _heartBeat.SetActive(true);
        } else {
            TimeLeft.color = _startColor;
            _heartBeat.SetActive(false);
        }
    }
}