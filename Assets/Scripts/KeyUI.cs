using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour {

	[SerializeField] private KeyManager _keyManager;
	[SerializeField] private Text _text;
	private float _alphaControl;

	void Start () {
		_keyManager = _keyManager.GetComponent<KeyManager> ();
		_text.gameObject.SetActive (false);
		_alphaControl = 1f;
	}

	void Update(){
		_text.text = _keyManager.KeyAmount.ToString();
		var temp = _text.color;
		temp.a = _alphaControl -= 0.001f;
		_text.gameObject.SetActive (true);
	}


}
