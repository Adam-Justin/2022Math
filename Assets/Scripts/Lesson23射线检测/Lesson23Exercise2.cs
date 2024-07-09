using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson23Exercise2 : MonoBehaviour
{
    // 实现鼠标左键选中游戏对象
    // 拖动游戏对象位置
    // 右键松开游戏对象

    Transform targetTransform;
    bool isSelected = false;
    Ray ray;
    float rayDistance = 1000.0f;
    RaycastHit hitInfo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SelectedGameObject();
        UnselectedGameObject();
        MoveGameObject();
    }

    /// <summary>
    /// 左键选中物体
    /// </summary>
    void SelectedGameObject()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // 屏幕发挥发出一条射线
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                out hitInfo, rayDistance,
                1 << LayerMask.NameToLayer("Player"),
                QueryTriggerInteraction.UseGlobal))
            {
                targetTransform = hitInfo.transform;
                isSelected = true;
                print("左键选中物体" + hitInfo.collider.name);
            }        
        }
    }

    /// <summary>
    /// 右键取消选中物体
    /// </summary>
    void UnselectedGameObject()
    {
        if (Input.GetMouseButtonDown(1))
        {
            targetTransform = null;
            isSelected = false;
            print("右键取消选择");

        }
    }

    void MoveGameObject()
    {
        if (Input.GetMouseButton(0) && targetTransform != null)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                out hitInfo, rayDistance,
                1 << LayerMask.NameToLayer("Floor")))
            {
                targetTransform.position = hitInfo.point + targetTransform.up * 0.5f;                
            }
        }
    }
}
