using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CarControler : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    private float _speed, _accelerationLerpInterpolator, _rotationInput, _currentSpeedMax;
    [SerializeField]
    private float _speedMax = 3, _accelerationFactor, _rotationSpeed = 0.5f;
    private bool _isAccelerating;

    [SerializeField]
    private AnimationCurve _accelerationCurve;

    void Start()
    {

    }

    void Update()
    {

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //transform.eulerAngles += Vector3.down * _rotationSpeed * Time.deltaTime;
        //}
        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //transform.eulerAngles += Vector3.up * _rotationSpeed * Time.deltaTime;
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isAccelerating = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isAccelerating = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            boost();
        }

        _rotationInput = Input.GetAxis("Horizontal");

        //var xAngle = transform.eulerAngles.x;
        //if (xAngle>180)
        //{
        //    xAngle = Mathf.Clamp(transform.eulerAngles.x, 0, 40);
        //    xAngle -= 360;
        //}

        //var yAngle = transform.eulerAngles.y;
        //var zAngle = 0;
        //transform.eulerAngles = new Vector3(xAngle,yAngle,zAngle);
    }

    private void FixedUpdate()
    {

        if (_isAccelerating)
        {
            _accelerationLerpInterpolator += _accelerationFactor;
           
        }
        else
        {
            _accelerationLerpInterpolator -= _accelerationFactor * 2;
        }

        _accelerationLerpInterpolator = Mathf.Clamp01(_accelerationLerpInterpolator);

        

        _speed = _accelerationCurve.Evaluate(_accelerationLerpInterpolator) * _speedMax;

        transform.eulerAngles += Vector3.up * _rotationSpeed * Time.deltaTime * _rotationInput;
        _rb.MovePosition(transform.position + transform.forward * _speed * Time.fixedDeltaTime);
    }

    void boost()
    {
        StartCoroutine(turbo());

    }

    IEnumerator turbo()
    {
        _speedMax += 10;
       // _speed += 5;
        yield return new WaitForSeconds(0.75f);
        _speedMax -= 10;
       // _speed -= 5;
    }
}
