using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson21Exercises : MonoBehaviour
{
    private LineRenderer line2;
    // Start is called before the first frame update
    void Start()
    {
        #region ��ϰ��һ ��дһ������������һ�����ĵ㣬����һ���뾶����LineRender��һ��Բ����
        DrawLineRenderer(Vector3.zero, 5, 360);
        #endregion

        #region ��ϰ��� ��Game���ڳ��������LineRenderer��������ƶ��Ĺ켣
        //line2 = this.gameObject.AddComponent<LineRenderer>();
        //line2.loop = false;
        //line2.startWidth = 0.5f;
        //line2.endWidth = 0.5f;

        //line2.positionCount = 0;
        #endregion
    }

    private Vector3 nowPos;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = new GameObject();
            line2 = obj.AddComponent<LineRenderer>();
            line2.loop = false;
            line2.startWidth = 0.2f;
            line2.endWidth = 0.2f;

            line2.positionCount = 0;
        }

        if (Input.GetMouseButton(0))
        {
            line2.positionCount += 1;
            //��εõ����ת��������� ��Ӧ�� 
            //֪ʶ��
            //1.��εõ����λ��
            //Input.mousePosition
            //2.��ô����� ת��������
            //Camera.main.ScreenToWorldPoint(Input.mousePosition);

            nowPos = Input.mousePosition;
            nowPos.z = 20;
            line2.SetPosition(line2.positionCount - 1, Camera.main.ScreenToWorldPoint(nowPos));
        }
    }

    public void DrawLineRenderer(Vector3 centerPos, float r, int pointNum)
    {
        //��̬���� ���߶���
        GameObject obj = new GameObject();
        obj.name = "R";
        LineRenderer line = obj.AddComponent<LineRenderer>();
        line.loop = false;
        //�����ж��ٸ���
        line.positionCount = pointNum;
        //������β����
        line.loop = true;

        //�õ�ÿ����֮�� ����Ķ���
        float angle = 360f / pointNum;

        //׼���õ�ÿһ����
        for (int i = 0; i < pointNum; i++)
        {
            //֪ʶ��
            //1.������� �൱��ƽ�Ƶ�
            //2.��Ԫ�� * ���� �൱���� ��ת����
            line.SetPosition(i, centerPos + Quaternion.AngleAxis(angle * i, Vector3.up) * Vector3.forward * r);
        }
    }
}
