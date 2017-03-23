using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeperScript : MonoBehaviour {
    

    public int _totalScore; //Stores the score for end scene

    void Start () {
        DontDestroyOnLoad(this);

    }
}
