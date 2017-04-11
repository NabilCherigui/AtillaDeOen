
using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
	
	[AddComponentMenu("camera_Axes")]
	public enum RotationAxes { JoyXy = 0, JoyX = 1, JoyY = 2 }
	public RotationAxes Axes = RotationAxes.JoyXy;
	public float SensitivityX = 15F;
	public float SensitivityY = 15F;

	private readonly float _minimumY = -60F;
	private readonly float _maximumY = 60F;

	private float _rotationY;

	private Rigidbody _rb;

	private void Update ()
	{
		switch (Axes)
		{
		case RotationAxes.JoyXy:
			var rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * SensitivityX;

			_rotationY += Input.GetAxis("Mouse Y") * SensitivityY;
			_rotationY = Mathf.Clamp (_rotationY, _minimumY, _maximumY);

			transform.localEulerAngles = new Vector3(-_rotationY, rotationX, 0);
			break;
		case RotationAxes.JoyX:
			transform.Rotate(0, Input.GetAxis("Mouse X") * SensitivityX, 0);
			break;
		case RotationAxes.JoyY:
		    _rotationY += Input.GetAxis("Mouse Y") * SensitivityY;
		    _rotationY = Mathf.Clamp (_rotationY, _minimumY, _maximumY);

		    transform.localEulerAngles = new Vector3(-_rotationY, transform.localEulerAngles.y, 0);
			break;
		    default:
		        throw new ArgumentOutOfRangeException();
		}
	}

	private void Start ()
	{
		_rb = GetComponent<Rigidbody>();
		if (_rb)
			_rb.freezeRotation = true;
	}
}

