using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shellMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private Collider _bc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = transform.forward * 20;
        //phasing();
        _bc.enabled = false;


    }
    //IEnumerator phasing()
    //{
    //   _bc.enabled = false;
    //    Debug.Log("disabled");
    //    yield return new WaitForSeconds(2f);
    //    Debug.Log("notdisabled");
    //    _bc.enabled = true;
    //
    //
    //}
}
