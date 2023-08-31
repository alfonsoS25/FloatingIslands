using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody _rig;

    [SerializeField] private Transform _mainCamera;

    [Header("Movement")]
    [SerializeField] private Vector2 _direction;

    [SerializeField] private float _speed;

    [SerializeField] private float _gravity;

    [SerializeField] private float _maxFallingSpeed;

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 4;

    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveCharacter();
        AddGravity();
        ClampFallingSpeed();
    }

    private void moveCharacter()
    {
        Vector3 movement = new Vector3(_direction.x * _speed , _rig.velocity.y, _direction.y * _speed );            //can add directly

        _rig.velocity = movement ;
    }

    public void GetPlayerInput(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    public void GetJumpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Jump();
        }
    }

    public void Jump()
    {
        float jumpPower = _jumpForce;                                                                     //can add directly
           _rig.velocity = new Vector3(_rig.velocity.x, jumpPower, _rig.velocity.z) ;
    }

    private void AddGravity()
    {
        _rig.AddForce(0, _gravity, 0); ;
    }

    private void ClampFallingSpeed()
    {
        if (_rig.velocity.y >= 0) return;

        if(_rig.velocity.y < _maxFallingSpeed)
        {
            _rig.velocity = new Vector3(_rig.velocity.x, _maxFallingSpeed, _rig.velocity.z);
        }
    }
}
