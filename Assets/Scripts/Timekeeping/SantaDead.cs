using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaDead : MonoBehaviour
{
    [SerializeField] TimerSO timerSO;

    void OnDestroy()
    {
        timerSO.Active = false;
    }
}
