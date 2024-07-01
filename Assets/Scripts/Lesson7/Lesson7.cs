using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7 : MonoBehaviour
{
    public Transform targetTransA;
    public Transform targetTransB;
    Vector3 crossResult;
    // Update is called once per frame
    void Update()
    {
        crossResult = Vector3.Cross(targetTransA.forward, targetTransB.position);
        if (crossResult.y > 0)
        {
            Debug.Log(" y > 0 Target 在玩家的右边");
        }
        if (crossResult.y < 0)
        {
            Debug.Log(" y < 0 Target 在玩家的左边");
        }
    }
}
