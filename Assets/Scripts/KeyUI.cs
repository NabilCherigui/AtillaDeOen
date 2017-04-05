using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour {

	[SerializeField] private KeyManager _keyManager;
	private Text _text;
	private float _alphaControl;
	private int _keyCompare;

	void Start () {
		_text = GetComponent<Text> ();
		_keyManager = _keyManager.GetComponent<KeyManager> ();
		_text.color = new Color (_text.color.r, _text.color.g, _text.color.b, 0);
		_keyCompare = _keyManager._KeyAmount;
		_alphaControl = 1f;
	}

	void Update(){
		_text.text = _keyManager._KeyAmount.ToString();
		if (_keyManager._KeyAmount > _keyCompare) {
			_alphaControl -= 0.005f;
			_text.color = new Color (_text.color.r, _text.color.g, _text.color.b, _alphaControl);
			if (_alphaControl <= 0) {
				_alphaControl = 1f;
				_keyCompare = _keyManager._KeyAmount;
			}
		}
	}


}
