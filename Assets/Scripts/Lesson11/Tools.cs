using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class Tools
{
    /// <summary>
    /// 实现物体obj看向target
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="target"></param>
    public static void MyLookAt(this Transform obj, Transform target)
    {
        // 扩展类
        Vector3 dir = target.position - obj.position;
        obj.rotation = Quaternion.LookRotation(dir);

    }

}
