using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundScript : MonoBehaviour {
    private GameObject _sound;

	void Start () {
        _sound = GameObject.Find("Sound");
        if (_sound.GetComponent<AudioSource>().enabled == false) {
            _sound.GetComponent<AudioSource>().enabled = true;
        }
    }
	void Update () {
        
        
    }
}
