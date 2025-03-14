using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var otherLapManager = other.GetComponent<otherLapManager>();
        if(otherLapManager)
    }
}
