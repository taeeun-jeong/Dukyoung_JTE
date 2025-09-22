using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private TimingManager theTimingManager;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            theTimingManager.CheckTiming();
        }
    }
}
