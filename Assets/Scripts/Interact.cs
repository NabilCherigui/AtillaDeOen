using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    [SerializeField] private int _distance;
    [SerializeField] private Text _alertInteraction;

    private Vector3 _foreward;

	void Start () {
	    _foreward = transform.TransformDirection(Vector3.forward);
	    _alertInteraction = _alertInteraction.GetComponent<Text>();
	}
	
	void Update () {


	    if (Physics.Raycast(transform.position, _foreward, _distance))
	        print("There is something infront of me");
	}
}
