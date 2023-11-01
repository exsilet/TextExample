using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _firstLanePosition;
    [SerializeField] private float _laneDistance;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private GameStart _start;

    private int _vectorGravity = 3;
    private int _lineNumber = 1;
    private int _lineCounter = 2;

    private Rigidbody _rigidbody;
    private CapsuleCollider _collider;
    private bool _didChangeLastFrame;
    private bool _canPlay = true;
    private bool _wanaJump;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();

        SwapMover.SwipeEvent += CheckInput;
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void Update()
    {
        if (!_start.IsGameStarted)
            return;

        Move();
    }

    public void StopMove() =>
        _canPlay = false;

    public void PlayMove() =>
        _canPlay = true;

    private void Move()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Lerp(newPosition.x, _firstLanePosition + (_lineNumber * _laneDistance),
            Time.deltaTime * _sideSpeed);
        transform.position = newPosition;
    }

    private void CheckInput(SwapMover.SwipeType type)
    {
        if (IsGrounded() && _canPlay)
        {
            if (type == SwapMover.SwipeType.Up)
                _wanaJump = true;
        }

        int sign = 0;

        if (!_canPlay)
            return;

        if (type == SwapMover.SwipeType.Left)
            sign = 1;
        else if (type == SwapMover.SwipeType.Right)
            sign = -1;
        else
            return;

        _lineNumber += sign;
        _lineNumber = Mathf.Clamp(_lineNumber, 0, _lineCounter);
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector3(0, Physics.gravity.y * 4, 0), ForceMode.Acceleration);

        if (_wanaJump && IsGrounded())
        {
            _rigidbody.AddForce(new Vector3(0, _jumpSpeed, 0), ForceMode.Impulse);
            _wanaJump = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.05f);
    }
}