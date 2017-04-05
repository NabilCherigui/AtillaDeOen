using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	[SerializeField] private GameObject _player;

	void Update(){
	}

	void OnTriggerEnter(Collider _player) {
		Destroy (gameObject);
	}

	/*void OnTriggerStay(Collider other) {
		print ("being touched.");
	}

	void OnTriggerExit(Collider other) {
		print ("Touch end.");
	}*/

}
