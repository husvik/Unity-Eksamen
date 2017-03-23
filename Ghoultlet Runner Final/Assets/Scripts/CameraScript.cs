using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Camera MainCamera;
	public Camera FPSCamera;

	// MainCamera as the start Camera for our game.
	void Start() {
		MainCamera.GetComponent<Camera>().enabled = true;
		FPSCamera.GetComponent<Camera>().enabled = false;
	}

	// If e is pressed, it will switch the camera state.
	void Update() {
		if (Input.GetKeyDown("e"))
		{
			MainCamera.enabled = !MainCamera.enabled;
			FPSCamera.enabled = !FPSCamera.enabled;
		}
	}
}