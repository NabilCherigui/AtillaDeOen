using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class OnVrEnabled : MonoBehaviour {

	// Use this for initialization
	void Update () {
		if (VRDevice.isPresent) {
			this.transform.rotation = Quaternion.Euler (0f, Camera.main.transform.eulerAngles.y, 0f);
		}
	}

}
