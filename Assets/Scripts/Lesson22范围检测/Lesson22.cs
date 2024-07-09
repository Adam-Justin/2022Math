using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Lesson22 : MonoBehaviour
{

    void Start()
    {
        // ֪ʶ�ع� -- ����ϵͳ�е���ײ���
        // ��ײ�����ı�Ҫ����: �������嶼Ҫ����ײ��(Ҳ�������), ����һ��Ҫ�и���Ҳ��������)

        // ��ײ�ʹ���
        // ��ײ�����ʵ�ʵ�����Ч��--λ�� ��ת��
        // �������������������ײ,���ǿ���ͨ����������������ײ�¼�

        // ��ײ�����Ҫ����ʵ������֮���������Ч��ʱ��ʹ��

        // ��Χ���
        // ʲô�Ƿ�Χ���
        // ��Ϸ��һ��˲ʱ������Χ�ж�һ���ʹ�÷�Χ���
        // e.g. �����ǰ��5m���ͷ�һ���ش�ħ��,�ڷ�Χ�ڵĶ��󶼻��ܵ��ش̵��˺�
        // e.g. ��ҹ���--��Χ����,�ڷ�Բ1m��Χ�ڵĶ����յ��˺��ȵ�
        // ��������û��ʵ������(����/��Ч/�Ӿ�Ч��ţ�Ƶ�) ֻ������ָ����Χ���÷�Χ�ڵĶ������˵�ʱ��,�Ϳ���ʹ�÷�Χ���
        // ˵�˻�: ��ָ����Χ�� ���� ��Χ�ж� �õ���Χ�ڵĶ���  ���д���==> ����/��Ѫ/��Ч��

        // ���ʹ�ù��ܷ�Χ���

        // �ر�����: ��Ҫ����Χ��⵽�Ķ��� ����Ҫ����ײ��
        // ע��
        // 1. ��Χ���API ֻ�е�ִ�иþ�����ʱ�� �Ż����һ�η�Χ���  ��˲ʱ�� ����־ü��
        // 2. ��Χ���API ���������һ����ײ��  ֻ�Ǽ���һ����ײ�ж�

        // ��Χ���API��ʹ��
        // �����ǵ���ײ��һ��,��box��Χ���/���η�Χ���/�����巶Χ���/
        // box ��Χ���
        // ����һ: ���ĵ� ������:�����3���ߵĳ��ȵ�һ�� ������:������ĽǶ� ������: ���㼶(��Ҫ����Щ��ļ��,��Щ��Ĳ����)
        // ������: �Ƿ���������� UseGlobal-ʹ��ȫ������ Collide-��ⴥ���� Ignore-���Դ�����  ����дʹ��UseGlobal
        // ����ֵ: �ڸ÷�Χ�ڵĴ�����(�õ��˶��󴥷����Ϳ��Եõ������ϵ�������Ϣ)

        // Box�ķ�Χ���
        OverlapBox();
        OverlapBoxNonAlloc();

        // Sphere�ķ�Χ���
        OverlapSphere();
        OverlapSphereNonAlloc();

        //Capsule�ķ�Χ���
        OverlapCapsule();
        OverlapCapsuleNonAlloc();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    // box�����ַ���
    private void OverlapBox()
    {
        Collider[] colliders = Physics.OverlapBox(Vector3.zero,
            new Vector3(1, 1, 1),
            Quaternion.AngleAxis(45, Vector3.up),
            1 << LayerMask.NameToLayer("UI") | 1 << LayerMask.NameToLayer("Default"),
            QueryTriggerInteraction.UseGlobal);

        for (int i = 0; i < colliders.Length; i++)
        {
            print(colliders[i].name);
        }
    }

    private int OverlapBoxNonAlloc()
    {
        Collider[] colliders = new Collider[128];
        int result = Physics.OverlapBoxNonAlloc(Vector3.zero,
            Vector3.one,
            colliders,
            Quaternion.AngleAxis(0, Vector3.up),
            1 << LayerMask.NameToLayer("UI") | 1 << LayerMask.NameToLayer("Default"),
            QueryTriggerInteraction.UseGlobal);

        if (result > 0)
        {
            for (int i = 0; i < result; i++)
            {
                if (colliders[i] != null)
                {
                    print(colliders[i].transform.position);
                }
            }
        }
        return result;
    }

    // sphere�����ַ���
    private void OverlapSphere()
    {
        Collider[] colliders = Physics.OverlapSphere(Vector3.zero,
            5.0f, 1 << LayerMask.NameToLayer("Default"),
            QueryTriggerInteraction.UseGlobal);
    }

    private int OverlapSphereNonAlloc()
    {
        Collider[] colliders = new Collider[128];
        int resultSphereCount = Physics.OverlapSphereNonAlloc(Vector3.zero, 2.0f, colliders, LayerMask.NameToLayer("Default"));
        if (resultSphereCount > 0)
        {
            for (int i = 0; i < resultSphereCount; i++)
            {
                if (colliders[i] != null)
                {
                    print(colliders[i].transform.position);
                }
            }
        }
        return resultSphereCount;
    }

    // ����������ַ���
    private void OverlapCapsule()
    {
        Collider[] colliders = Physics.OverlapCapsule(Vector3.zero,
               Vector3.forward,
               2.0f,
               LayerMask.NameToLayer("Default"));
        for (int i = 0; i < colliders.Length; i++)
        {
            print(colliders[i].name);
        }
    }

    private int OverlapCapsuleNonAlloc()
    {
        Collider[] colliders = new Collider[128];
        

        // ȷ��������鲻Ϊ��
        if (colliders == null || colliders.Length == 0)
        {
            Debug.LogError("OverlapCapsuleNonAlloc: Results array is null or empty.");
            return 0;
        }

        // �����������е�����Ԫ��
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i] = null;
        }

        // ʹ��Physics.OverlapCapsule����ȡ�ص�����ײ��
        int resultCapsuleCount = Physics.OverlapCapsuleNonAlloc(Vector3.zero, Vector3.forward, 2.0f, colliders, LayerMask.NameToLayer("Default"));

        // �����ص�����ײ������
        return resultCapsuleCount;

    }


}
