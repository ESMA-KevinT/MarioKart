using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shellMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        _rb.velocity = transform.forward * 25;
 
    }

}
