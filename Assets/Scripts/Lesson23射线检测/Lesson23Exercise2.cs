using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson23Exercise2 : MonoBehaviour
{
    // ʵ��������ѡ����Ϸ����
    // �϶���Ϸ����λ��
    // �Ҽ��ɿ���Ϸ����

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
    /// ���ѡ������
    /// </summary>
    void SelectedGameObject()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // ��Ļ���ӷ���һ������
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                out hitInfo, rayDistance,
                1 << LayerMask.NameToLayer("Player"),
                QueryTriggerInteraction.UseGlobal))
            {
                targetTransform = hitInfo.transform;
                isSelected = true;
                print("���ѡ������" + hitInfo.collider.name);
            }        
        }
    }

    /// <summary>
    /// �Ҽ�ȡ��ѡ������
    /// </summary>
    void UnselectedGameObject()
    {
        if (Input.GetMouseButtonDown(1))
        {
            targetTransform = null;
            isSelected = false;
            print("�Ҽ�ȡ��ѡ��");

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
