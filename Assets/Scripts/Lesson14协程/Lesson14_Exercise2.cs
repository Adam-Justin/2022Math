using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson14_Exercise2 : MonoBehaviour
{
    // ����10w������
    IEnumerator CoroutineCreateCue()
    {
        int j = 1000;
        for (int i = 0; i < 1000 * 100; i++)
        {
            // ����������
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // �޸�λ��
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
            // Э�̴���
            StartCoroutine(CoroutineCreateCue());
        }
    }

    private static void CreateCube()
    {
        for (int i = 0; i < 1000 * 100; i++)
        {
            // ����������
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // �޸�λ��
            go.transform.position = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
        }
    }
}
