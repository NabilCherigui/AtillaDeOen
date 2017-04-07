using UnityEngine;

public class Key : MonoBehaviour {

	[SerializeField] private GameObject _player;

    private void OnTriggerEnter(Collider _player) {
		Destroy (gameObject);
	}

}
