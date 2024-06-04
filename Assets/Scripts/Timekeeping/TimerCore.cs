using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCore : MonoBehaviour
{
    [SerializeField] private TimerSO timer;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        timer.Active = false;
        timer.ElapsedTime = 0;
    }

}
