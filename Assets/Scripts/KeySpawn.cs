using UnityEngine;

public class KeySpawn : MonoBehaviour {

	[SerializeField] private Vector3[] _keyPositions;
	[SerializeField] private GameObject _key1;
	[SerializeField] private GameObject _key2;

	private int _keyChosenPosition1;
	private int _keyChosenPosition2;

	void Start() {
		_keyChosenPosition1 = Random.Range (0, _keyPositions.Length);
		_keyChosenPosition2 = Random.Range (0, _keyPositions.Length);
		if (_keyChosenPosition1 == _keyChosenPosition2) {
			_keyChosenPosition2 = Random.Range (0, 5);
		}

		_key1.transform.position = _keyPositions [_keyChosenPosition1];
		_key2.transform.position = _keyPositions [_keyChosenPosition2];
	}

}
