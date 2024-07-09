using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson9 : MonoBehaviour
{
    GameObject go;
    // 四元数旋转物体
    // 四元数Q = [cos(β/2), sin(β/2)x,sin(β/2)y,sin(β/2)z]

    // 轴,角度 沿着x轴旋转30°
    Quaternion q1 = new Quaternion(Mathf.Sin(30 * Mathf.Deg2Rad) * 1, 0, 0, Mathf.Cos(30 * Mathf.Deg2Rad));
    void Start()
    {
        go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // go.transform.rotation = q1;
        // go.transform.rotation  rotation就是四元素, 和面板的rotation不同

        // 上面的复杂写法可以被Unity封装好的方法写 -- 角度+轴
        Quaternion q2 = Quaternion.AngleAxis(60, Vector3.right);
        // go.transform.rotation = q2;

        // 欧拉角转四元数
        Quaternion q3 = Quaternion.Euler(60, 0, 0);
        Debug.Log(q3);

        // 四元素转欧拉角
        Debug.Log(q3.eulerAngles);
    }
    private void Update()
    {
        go.transform.rotation *= Quaternion.AngleAxis(1, Vector3.up);
    }


}
