using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {
    [SerializeField]
    GameObject objectToFollow;
    private Vector3 distance;
    void Start()
    {
        distance = this.transform.position - objectToFollow.transform.position;
    }
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = distance + objectToFollow.transform.position;
	}
}
