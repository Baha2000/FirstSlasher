using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private bool _isSpaceAttackStarted;
    private bool _isSpaceAttackCenter;
    private Vector3 _startPos;
    private float _speed;
    private float _shiftSpeed;
    public Camera camera;

    void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody>();
        _speed = 20f;
        _shiftSpeed = 15f;
    }

    private void FixedUpdate()
    {
        RotationLogic();
        MovementLogic();

        if (_isSpaceAttackStarted)
        {
            float xSum = Mathf.Abs(_startPos.x - transform.localPosition.x);
            float zSum = Mathf.Abs(_startPos.z - transform.localPosition.z);
            if (!_isSpaceAttackCenter)
            {
                _rigidBody.AddRelativeForce(0, 0, 50f, ForceMode.Impulse);

                if (Mathf.Abs(xSum + zSum) > 15f)
                {
                    Vector3 reverse = transform.localRotation.eulerAngles;

                    transform.localRotation = Quaternion.Euler(reverse.x, reverse.y + 180f, reverse.z);
                    _isSpaceAttackCenter = true;
                }
            }

            if (_isSpaceAttackCenter)
            {
                _rigidBody.AddRelativeForce(0, 0, 50f, ForceMode.Impulse);

                if (Mathf.Abs(xSum + zSum) < 1f)
                {
                    Vector3 reverse = transform.localRotation.eulerAngles;

                    transform.localRotation = Quaternion.Euler(reverse.x, reverse.y - 180f, reverse.z);

                    _isSpaceAttackCenter = false;
                    _isSpaceAttackStarted = false;
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _isSpaceAttackStarted = true;
            _startPos = transform.localPosition;
        }
    }

    private void RotationLogic()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;

            Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 100);
            transform.LookAt(hit.point);
        }
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _rigidBody.velocity = movement * (_speed + _shiftSpeed);
        }
        else
        {
            _rigidBody.velocity = movement * _speed;
        }
    }
}