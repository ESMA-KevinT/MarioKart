using System.Collections;
using JetBrains.Annotations;
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

    private bool _isBoosting = false; 

    private bool _firstInput=true;

    [SerializeField]
    private AnimationCurve _accelerationCurve;

    [SerializeField]
    private LayerMask _layerMask;


    private float _terrainSpeedVariator;

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
        if (Input.GetKeyDown(KeyCode.W))
        {
            _isAccelerating = true;
            if (_firstInput)
            {
                boostStart();
                _firstInput = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            _isAccelerating = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isBoosting == false)
            {
                boost();
            }
        }

       // if (Input.GetKeyDown(KeyCode.Q))
       // {
       //     featherJump();
       // }
       //
       //
        _rotationInput = Input.GetAxis("Horizontal");

    

        
       
        //

        if (Physics.Raycast(transform.position, transform.up * -1, out var info, 1, _layerMask))
        {
            if (_isBoosting == false)
            {

                Ground groundBellow = info.transform.GetComponent<Ground>();
                if (groundBellow != null)
                {
                    _terrainSpeedVariator = groundBellow.groundEffect;
                }
                else
                {
                    _terrainSpeedVariator = 1;
                }
            }
            else
            {
                _terrainSpeedVariator = 1;
            }

        }
        else
        {
            _terrainSpeedVariator = 1;
        }

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

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("turboPad"))
        {
            if (_isBoosting == false)
            {
                boost();
            }
        }

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

        

        _speed = _accelerationCurve.Evaluate(_accelerationLerpInterpolator) * _speedMax * _terrainSpeedVariator;

        transform.eulerAngles += Vector3.up * _rotationSpeed * Time.deltaTime * _rotationInput;
        _rb.MovePosition(transform.position + transform.forward * _speed * Time.fixedDeltaTime);
    }

    public void boost()
    {
        StartCoroutine(turbo());

    }

    IEnumerator turbo()
    {
        _speedMax += 10;

        _isBoosting = true;
       // _speed += 5;
        yield return new WaitForSeconds(0.75f);
        _speedMax -= 10;
        _isBoosting = false;
       // _speed -= 5;
    }

    public void boostStart()
    {
        StartCoroutine(turboStart());

    }

    IEnumerator turboStart()
    {
        _speedMax += 20;

        _isBoosting = true;
        // _speed += 5;
        yield return new WaitForSeconds(0.75f);
        _speedMax -= 20;
        _isBoosting = false;
        // _speed -= 5;
    }

    public void featherJump()
    {
        Debug.Log("isJumping");
        _rb.AddForce(transform.up * 350);
    }
}
