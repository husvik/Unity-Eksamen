using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {

	
	//Rotate Code
	void Update () {
		transform.Rotate(0, 3, 0, Space.World);

	}
}
