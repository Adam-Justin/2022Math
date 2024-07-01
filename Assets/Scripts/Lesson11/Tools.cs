using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class Tools
{
    /// <summary>
    /// ʵ������obj����target
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="target"></param>
    public static void MyLookAt(this Transform obj, Transform target)
    {
        // ��չ��
        Vector3 dir = target.position - obj.position;
        obj.rotation = Quaternion.LookRotation(dir);

    }

}
