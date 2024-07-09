using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson23Exercise1 : MonoBehaviour
{
    // ����һ������
    private Ray ray;
    // ���߾���
    private float rayDistance = 100.0f;
    // �����������Ϣ
    private RaycastHit hitInfo;

    // �ӵ���Ч
    private GameObject bulletEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���������һ������
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // ʵ������Ч
            
            if (Physics.Raycast(ray, out hitInfo, rayDistance, 1 << LayerMask.NameToLayer("Wall"), QueryTriggerInteraction.UseGlobal));
            {
                Debug.Log(hitInfo.point);
                bulletEffect = Instantiate(Resources.Load<GameObject>("Effect/ArcaneEnchant"));
                bulletEffect.transform.position = hitInfo.point;
                bulletEffect.transform.rotation = Quaternion.LookRotation(hitInfo.normal);    
            }

            Destroy(bulletEffect, 0.8f);
        }
    }


}
