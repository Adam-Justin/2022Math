using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson23Exercise1 : MonoBehaviour
{
    // 构建一条射线
    private Ray ray;
    // 射线距离
    private float rayDistance = 100.0f;
    // 击中物体的信息
    private RaycastHit hitInfo;

    // 子弹特效
    private GameObject bulletEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 摄像机发出一条射线
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 实例化特效
            
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
