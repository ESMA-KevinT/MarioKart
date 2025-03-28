using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
  public bool isFinishLine;

  private void OnTriggerEnter(Collider other)
  {
        Debug.Log("check");
      var otherLapManager = other.GetComponent<LapManager>();
      if (otherLapManager != null)
      {
          otherLapManager.AddCheckPoint(this);
          Debug.Log("checkpoint");
      }
  }
}
