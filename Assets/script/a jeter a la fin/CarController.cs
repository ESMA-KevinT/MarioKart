using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    private float _speed;
    [SerializeField]
    private float _maxSpeed = 5, _accelerationFactor, _rotation = 0.2f;

    private bool _isAccelerating;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isAccelerating = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isAccelerating = false;
        }



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles -= Vector3.up * _rotation*Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles += Vector3.up*_rotation * Time.deltaTime;
        }



       // var xAngle = Mathf.Clamp(transform.eulerAngles.x, -40, -40);
        //var yAngle = transform.eulerAngles.y;
        //var zAngle = transform.eulerAngles.z;
        //transform.eulerAngles = new Vector3(xAngle, yAngle, zAngle); 
    }

    private void FixedUpdate()
    {

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    _rb.velocity = transform.forward * _speed * Time.fixedDeltaTime;
         // _rb.MovePosition(transform.position + transform.forward*_speed*Time.fixedDeltaTime);
       // }

        

        if (_isAccelerating)
        {
            _speed = Mathf.Clamp(_speed + _accelerationFactor, 0, _maxSpeed);
        }
        else
        {
            _speed = Mathf.Clamp(_speed - _accelerationFactor, 0, _maxSpeed);
        }

        _rb.MovePosition(transform.position + transform.forward * _speed * Time.fixedDeltaTime);



    }
}
