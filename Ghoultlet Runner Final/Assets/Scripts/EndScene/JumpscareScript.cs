using UnityEngine;
using System.Collections;

public class JumpscareScript : MonoBehaviour {
    //Controls the jumpscare image
    public float sec = 5f;
    private float timer;
    private GameObject _sound;

    void Start() {
        timer = 0;
        _sound = GameObject.Find("Sound");

    }
    void Update() {
        timer += Time.deltaTime;
        

        if (timer > sec) {
            gameObject.SetActive(false);
            _sound.GetComponent<AudioSource>().enabled = true;
        }

    }
   
}
