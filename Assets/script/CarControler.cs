using System.Collections;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class CarControler : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    private float _speed, _accelerationLerpInterpolator, _rotationInput;
    [SerializeField]
    private float _speedMax = 3, _accelerationFactor, _rotationSpeed = 0.5f;
    private bool _isAccelerating;

    private bool _isBoosting = false; 

    private bool _firstInput=true;

    
    private bool _isMovingBack;


    [SerializeField]
    private string _DirectionInputName = "Horizontal", _accelerateInputName = "Accelerate", _reverseInputName = "Reverse";





    [SerializeField]
    private AnimationCurve _accelerationCurve;

    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    public GameObject inkSprite;



    private float _terrainSpeedVariator;

    void Start()
    {

    }

    void Update()
    {


        if (Input.GetButtonDown(_accelerateInputName))
        {
            _isAccelerating = true;
            if (_firstInput)
            {
                boostStart();
                _firstInput = false;
            }
        }
        if (Input.GetButtonUp(_accelerateInputName))
        {
            _isAccelerating = false;
        }

        if (Input.GetButtonDown(_reverseInputName))
        {
            _isMovingBack = true;
           
        }
       
        if (Input.GetButtonUp(_reverseInputName))
        {
          _isMovingBack= false;
        }
       


        _rotationInput = Input.GetAxis(_DirectionInputName);

        if (_isMovingBack)
        {
            _rb.velocity = transform.forward * -10;
        }

        
       
   

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

        if (other.CompareTag("shell"))
        {

                
            StartCoroutine(stunned());

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

    public void inkScreen()
    {
        StartCoroutine(inked());
    }

    IEnumerator turbo()
    {
        _speedMax += 10;

        _isBoosting = true;
       
        yield return new WaitForSeconds(0.75f);
        _speedMax -= 10;
        _isBoosting = false;

    }

    public void boostStart()
    {
        StartCoroutine(turboStart());

    }

    IEnumerator turboStart()
    {
        _speedMax += 30;

        _isBoosting = true;
      
        yield return new WaitForSeconds(0.75f);
        _speedMax -= 30;
        _isBoosting = false;
     
    }

    IEnumerator stunned()
    {
        
 
        _speedMax = 0;

    yield return new WaitForSeconds(0.75f);
 
        _speedMax = 20;
    }


    public void featherJump()
    {
       
        _rb.AddForce(transform.up * 350);

  

    }

    IEnumerator inked()
    {

        inkSprite.SetActive(true);
        yield return new WaitForSeconds(3f);
        inkSprite.SetActive(false);

    }

}
