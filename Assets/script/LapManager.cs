using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapManager : MonoBehaviour
{

    private int _lapnumber;
    private Lise<Checkpoint> _checkpoints;
    private int _numberOfCheckpoints;


    private void Start()
    {
        _numberOfCheckpoints = FindObjectsByType<AddCheckPoint>()
    }
    public void AddCheckPoint(Checkpoint checkPointToAdd)
    {
        if(checkPointToAdd.isFinishLine)
        {
            FinishLap();
        }

        if (_checkpoints.Contains(checkpoinToAdd) == false)
        {
            _checkpoints.Add(checkPointToAdd);
        }
    }

    private void FinishLap()
    {
        if (_checkpoints.Count > _numberOfCheckpoints/2)
        {
            _lap 
        }
    }
}
