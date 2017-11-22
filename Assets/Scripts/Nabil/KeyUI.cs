using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour {

	[SerializeField] private KeyManager _keyManager;
	[SerializeField] private Text _text;
	[SerializeField] private int _sizeDecrease;
	[SerializeField] [Range(0,1)] private float _alphaDecrease;

	private int _normalSize;
	private int _keyAmount;
	private float _normalAlpha;
	private float _alpha;



	void Start () {
		_keyManager = _keyManager.GetComponent<KeyManager> ();
		_normalAlpha = _text.color.a;
		_alpha = _text.color.a;
		_normalSize = _text.fontSize;
		_keyAmount = _keyManager.KeyAmount;
		_text.text = "";
	}

	void Update(){
		if (_keyManager.KeyAmount > _keyAmount)
		{
			if (_text.fontSize < 0)
			{
				_text.fontSize = _normalSize;
				_keyAmount = _keyManager.KeyAmount;
				_text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _normalAlpha);
				_text.text = "";
			}
			else
			{
				_text.fontSize -= _sizeDecrease;
				_alpha -= _alphaDecrease;
				_text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _alpha);
				_text.text = _keyManager.KeyAmount.ToString();
			}
		}
	}


}
