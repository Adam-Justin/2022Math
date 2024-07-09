using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson21 : MonoBehaviour
{
    // linerRender��ʹ��

    private GameObject go;

    private Material material; 

    private void Start()
    {
        // ����һ��������
        go = new GameObject("LineRendeObject");
        // ���ø�����
        go.transform.parent = GameObject.Find("Go").transform;

        // ���ز���
       
        // ���LineRenderer���
        go.AddComponent<LineRenderer>();
        // ���ü�⺯��
        TestLinerRenderComponent(go.GetComponent<LineRenderer>());
    }

    /// <summary>
    /// ���ز�����Դ
    /// </summary>
    /// <param name="newMaterial"></param>
    private void MaterialLoadedCompleted(Material newMaterial)
    {
        material = newMaterial;
    }

    public void TestLinerRenderComponent(LineRenderer lineRenderer)
    {
        if (lineRenderer != null && lineRenderer.enabled)
        {
            // ���û�������ľ�����Ϣ
            // ��������
            lineRenderer.positionCount = 4;

            // ���õ��λ��
            // һȺ�������λ��
            lineRenderer.SetPositions(new Vector3[]
                {
                    new Vector3(0,0,0),
                    new Vector3(5,0,0),
                    new Vector3(5,0,5),
                    new Vector3(0,0,5)
                });
            // �����������: ����+����
            // lineRenderer.SetPosition(1, new Vector3(0,0,0));

            // �Ƿ���ѭ��--���ͼ��
            lineRenderer.loop = true;

            // ���ÿ�ʼ���
            lineRenderer.startWidth = 0.05f;
            // ���ý������
            lineRenderer.endWidth = 0.05f;

            // ���ÿ�ʼ��ɫ
            lineRenderer.startColor = Color.red;
            // ���ý�����ɫ
            lineRenderer.endColor = Color.green;

            // ���ò��� -- ���ز���
            material = Resources.Load<Material>("Material/M_LineRender");
            lineRenderer.material = material;
            // ���ù���Ӱ��
            lineRenderer.generateLightingData = true;

            // ��������ϵ
            lineRenderer.useWorldSpace = false;
        }
    }
}
