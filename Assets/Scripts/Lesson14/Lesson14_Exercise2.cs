using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson14_Exercise2 : MonoBehaviour
{
    // 创建10w个物体
    IEnumerator CoroutineCreateCue()
    {
        int j = 1000;
        for (int i = 0; i < 1000 * 100; i++)
        {
            // 创建立方体
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // 修改位置
            go.transform.position = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
            if (i % j == 0)
            {
                yield return null;
            }
           
        }

    }
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // CreateCube();
            // 协程创建
            StartCoroutine(CoroutineCreateCue());
        }
    }

    private static void CreateCube()
    {
        for (int i = 0; i < 1000 * 100; i++)
        {
            // 创建立方体
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // 修改位置
            go.transform.position = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
        }
    }
}
