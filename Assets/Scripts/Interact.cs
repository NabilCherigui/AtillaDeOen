using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    [SerializeField] private int _distance;
    [SerializeField] private Text _alertInteraction;
    [SerializeField] private string _tagOfObject;
    [SerializeField] private Image _letter;

    private RaycastHit _hit;
    private Ray _readingRay;

	void Start () {
	    _alertInteraction = _alertInteraction.GetComponent<Text>();
	    _letter = _letter.GetComponent<Image>();
	    _alertInteraction.enabled = false;
	    _letter.enabled = false;
	}
	
	void Update () {
		_readingRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

	    if (Physics.Raycast(_readingRay, out _hit, _distance))
	    {
	        if (_hit.collider.CompareTag(_tagOfObject))
	        {
	            _alertInteraction.enabled = true;
				if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown("joystick button 2"))
	            {
	                _letter.enabled = !_letter.enabled;
	                Time.timeScale = Time.timeScale == 1 ? 0 : 1;
	            }
	        }
	    }
	    else
	    {
	        _alertInteraction.enabled = false;
	    }
	}
}
