using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LapManager : MonoBehaviour
{
    private int _lapNumber=1;
    private List<CheckPoint> _checkpoints;
    private int _numberOfCheckpoints;
    [SerializeField]
    private TextMeshProUGUI _lap;

    [SerializeField]
    private GameObject _victory;

    [SerializeField]
    private GameObject _victoryOther;

    private void Start()
    {
        _numberOfCheckpoints = FindObjectsByType<CheckPoint>(FindObjectsSortMode.None).Length;
        _checkpoints = new List<CheckPoint>();
    }

    public void AddCheckPoint(CheckPoint checkPointToAdd)
    {
        if (checkPointToAdd.isFinishLine)
        {
            FinishLap();
        }

        if (_checkpoints.Contains(checkPointToAdd) == false)
        {
            _checkpoints.Add(checkPointToAdd);
        }
    }

    private void FinishLap()
    {
        if (_checkpoints.Count > _numberOfCheckpoints / 2)
        {
            _lapNumber++;
            _lap.text = "lap" + _lapNumber;

          
            _checkpoints.Clear();
            if (_lapNumber == 4)
            {
                _victory.SetActive(true);
                Destroy(_victoryOther); 
                
            }
        }
    }
}