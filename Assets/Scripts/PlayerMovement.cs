using UnityEngine;

[RequireComponent(typeof (CharacterController))]
[RequireComponent(typeof (AudioSource))]
[RequireComponent(typeof (Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool _isWalking;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] [Range(0f, 1f)] private float _runstepLenghten;
    [SerializeField] private float _stickToGroundForce;
    [SerializeField] private float _gravityMultiplier;
    [SerializeField] private float _stepInterval;
    [SerializeField] private AudioClip[] _footstepSounds;

    private float _yRotation;
    private Vector2 _input;
    private Vector3 _moveDir = Vector3.zero;
    private CharacterController _characterController;
    private CollisionFlags _collisionFlags;
    private float _stepCycle;
    private float _nextStep;
    private AudioSource _audioSource;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _stepCycle = 0f;
        _nextStep = _stepCycle/2f;
        _audioSource = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {
        float speed;
        GetInput(out speed);

        var desiredMove = transform.forward*_input.y + transform.right*_input.x;


        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, _characterController.radius, Vector3.down, out hitInfo,
        _characterController.height/2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
        desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

        _moveDir.x = desiredMove.x*speed;
        _moveDir.z = desiredMove.z*speed;

        if (_characterController.isGrounded)
        {
            _moveDir.y = -_stickToGroundForce;
        }
        else
        {
            _moveDir += Physics.gravity*_gravityMultiplier*Time.fixedDeltaTime;
        }
        _collisionFlags = _characterController.Move(_moveDir*Time.fixedDeltaTime);

        ProgressStepCycle(speed);
    }

    private void ProgressStepCycle(float speed)
    {
        if (_characterController.velocity.sqrMagnitude > 0 && (_input.x != 0 || _input.y != 0))
        {
            _stepCycle += (_characterController.velocity.magnitude + (speed*(_isWalking ? 1f : _runstepLenghten)))*
                           Time.fixedDeltaTime;
        }

        if (!(_stepCycle > _nextStep))
        {
            return;
        }

        _nextStep = _stepCycle + _stepInterval;

        PlayFootStepAudio();
    }


    private void PlayFootStepAudio()
    {
        if (!_characterController.isGrounded)
        {
            return;
        }

        var n = Random.Range(1, _footstepSounds.Length);
        _audioSource.clip = _footstepSounds[n];
        _audioSource.PlayOneShot(_audioSource.clip);

        _footstepSounds[n] = _footstepSounds[0];
        _footstepSounds[0] = _audioSource.clip;
    }

    private void GetInput(out float speed)
    {

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        _isWalking = !Input.GetKey(KeyCode.LeftShift);

        speed = _isWalking ? _walkSpeed : _runSpeed;
        _input = new Vector2(horizontal, vertical);

        if (_input.sqrMagnitude > 1)
        {
            _input.Normalize();
        }


    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var body = hit.collider.attachedRigidbody;

        if (_collisionFlags == CollisionFlags.Below)
        {
            return;
        }

        if (body == null || body.isKinematic)
        {
            return;
        }
        body.AddForceAtPosition(_characterController.velocity*0.1f, hit.point, ForceMode.Impulse);
    }
}