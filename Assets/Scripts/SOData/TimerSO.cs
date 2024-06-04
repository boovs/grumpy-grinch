using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TimerSO : ScriptableObject
{
    [SerializeField] private float _elapsedTime;
    [SerializeField] private bool _active;

    public float ElapsedTime
    {
        get { return _elapsedTime; }
        set { _elapsedTime = value; }
    }

    public bool Active
    {
        get { return _active; }
        set { _active = value; }
    }
}
