using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson23 : MonoBehaviour
{
    // LinerRender���
    private LineRenderer lineRenderer = null;

    // ���߼��
    // ��Щ�ط�Ӧ��ʹ������:FPSû��ʵ���ӵ�,û�й켣���ӵ�
    // ��������,VR�е�Զ��ץȡ
    // ���������������

    // ����һ������ : ���߲�������ʼ�� + ���ߵķ���.
    private Ray ray1 = new Ray(Vector3.zero, Vector3.forward);
    // ���߾���
    private float rayDistance = 100.0f;
    // �������Ƿ���ײ��������
    // bool result = Physics.Raycast(���, �������� ���߳���, ���㼶, �Ƿ�����ײ��);
    // bool result = Physics.Raycast(���߶���, ���߳���, ���㼶, �Ƿ�����ײ��);

    // ���е��ж����
    bool hitResult = false;
    // ���߻��е�����
    private RaycastHit hitInfo;

    void Start()
    {
        // ��������������
        lineRenderer = this.gameObject.AddComponent<LineRenderer>();
        AddLineRender(lineRenderer);

        // �������ߵ����ͷ���
        ray1.origin = this.transform.position;
        ray1.direction = this.transform.forward;

        bool result1 = Physics.Raycast(Vector3.zero + new Vector3(0,0,10), Vector3.forward, 1000.0f, 1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.UseGlobal);
        if (result1)
        {
            Debug.Log("���߻�������");
        }
/*        bool result2 = Physics.Raycast(ray1, 1000.0f, 1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.UseGlobal);
        if (result2)
        {
            Debug.Log("���߻�������");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        // �����������ߵ�λ��
        ray1.origin = this.transform.position;
        ray1.direction = this.transform.forward;

        // ��ת��Ϸ���� -- ÿ����ת60��
        Quaternion quaternion = Quaternion.AngleAxis(60f * Time.deltaTime, this.transform.up);
        this.transform.rotation *= quaternion;        

        // �жϻ��е�����
        hitResult =  Physics.Raycast(ray1, out hitInfo, rayDistance, 1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.UseGlobal);
        if (hitResult == true)
        {
            print(hitInfo.collider.name);
        }
        // ��ʾ����
        UpdateLineRendererByRay(lineRenderer, ray1, hitResult,hitInfo, rayDistance);
    }

    /// <summary>
    /// ���������Ⱦ���
    /// </summary>
    void AddLineRender(LineRenderer lineRenderer)
    {
        // lineRenderer = this.gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.green;
    }

    /// <summary>
    /// ���߿ɿ��ӻ�
    /// </summary>
    /// <param name="lineRenderer">LineRenderer���</param>
    /// <param name="ray">����</param>
    /// <param name="rayDistance">���߾���</param>
    void ShowRayByLineRenderer( LineRenderer lineRenderer,Ray ray, float rayDistance)
    {
        if (lineRenderer == null || lineRenderer.positionCount < 2)
        {
            Debug.Log("LineRender���������ʹ��");
            return;
        }

        // �������λ��
        lineRenderer.SetPosition(0, ray.origin);
        lineRenderer.SetPosition(1, ray.GetPoint(rayDistance));
    }

    /// <summary>
    /// ���������ʱ���޸����ߵĳ���
    /// </summary>
    /// <param name="lineRenderer"></param>
    /// <param name="ray"></param>
    /// <param name="hitResult"></param>
    /// <param name="hitInfo"></param>
    /// <param name="rayDistance"></param>
    void UpdateLineRendererByRay(LineRenderer lineRenderer,Ray ray, bool hitResult, RaycastHit hitInfo, float rayDistance)
    {
        if (lineRenderer == null || lineRenderer.positionCount < 2)
        {
            Debug.Log("LineRender���������ʹ��");
            return;
        }

        // �޸����λ��
        lineRenderer.SetPosition(0, ray.origin);
        // �޸��յ�λ��
        if (hitResult == true)
        {
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else 
        {
            lineRenderer.SetPosition(1, ray.GetPoint(rayDistance));
        }

        
    }
}
