using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson10 : MonoBehaviour
{
    public Transform transformA;
    public Transform transformB;
    public Transform transformTarget;
    public GameObject go;

    [Header("LookRotation")]
    public Transform lookA;
    public Transform lookB;

    // ���ٱ仯
    Quaternion startRotation;
    float time = 0.0f;
    void Start()
    {
        startRotation = transformB.rotation;
        go = Instantiate(go, Vector3.zero, Quaternion.identity);

       Quaternion q = Quaternion.LookRotation(lookA.position - lookB.position);
        lookB.rotation = q;
        
    }

    // Update is called once per frame
    void Update()
    {
        // �ȿ���� -- ���޽ӽ�
        transformA.rotation = Quaternion.Slerp(transformA.rotation, transformTarget.rotation, Time.deltaTime);

        // ������ת
        time += Time.deltaTime;
        transformB.rotation = Quaternion.Slerp(startRotation, transformTarget.rotation, time);

        Quaternion q = Quaternion.LookRotation(lookA.position - lookB.position);
        lookB.rotation = q;
    }
}
