using UnityEngine;

public class Key : MonoBehaviour {

	[SerializeField] private GameObject _player;

    private void OnTriggerEnter(Collider _layer) 
	{
		if (_player.gameObject == this._player) 
		{
			Destroy (gameObject);
		}
	}

}
