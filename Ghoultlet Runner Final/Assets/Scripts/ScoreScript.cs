using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    public Text Score;
    
    private ScoreKeeperScript _scoreKeeperScript;
    private int _totalTime;

	void Start () {
        _scoreKeeperScript = FindObjectOfType<ScoreKeeperScript>();
        _totalTime = _scoreKeeperScript._totalScore;

        Score.text = "Total Time: " + _totalTime.ToString(); //Displays the score from ScoreKeeperScript
    }
}
