using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour {

	[SerializeField] private KeyManager _keyManager;
	[SerializeField] private Text _text;

	[SerializeField] [Range(0,1)] private float _alphaDecrease;
	private float _alpha;

	void Start () {
		_keyManager = _keyManager.GetComponent<KeyManager> ();
		//_text.gameObject.SetActive (false);
		_alpha = _text.color.a;
	}

	void Update(){
		_text.text = _keyManager.KeyAmount.ToString();
		_alpha -= _alphaDecrease;
		_text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _alpha);
		//_text.gameObject.SetActive (true);
	}


}
