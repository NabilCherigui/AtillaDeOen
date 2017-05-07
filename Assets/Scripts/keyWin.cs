using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class keyWin : MonoBehaviour {
	[SerializeField] KeyManager key;
	private void OnTriggerEnter(Collider hit)
	{
		print ("hit");
		if (hit.CompareTag ("Door") && key.KeyAmount >= 2) 
		{
			SceneManager.LoadScene ("Main");
		}
	}
}
