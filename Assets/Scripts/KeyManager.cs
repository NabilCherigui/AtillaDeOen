using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour {

	[SerializeField] GameObject _key1;
	[SerializeField] GameObject _key2;
	[SerializeField] GameObject _empty;

	private int _keyAmount;

	public int _KeyAmount {
		get { 
			return _keyAmount;
		}
	}

	void Update(){
		if (_key1 == null) {
			_keyAmount++;
			_key1 = _empty;
		}
		if (_key2 == null) {
			_keyAmount++;
			_key2 = _empty;
		}
	}

}
