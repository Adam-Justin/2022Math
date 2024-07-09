using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson13_Exercise : MonoBehaviour
{
    private int time = 0;
    void Start()
    {
        InvokeRepeating("RecordTime", 0, 1);
    }

   
    void Update()
    {
        
    }

    public void RecordTime()
    {
        time++;
        Debug.Log("time = " + time);
    }
}
