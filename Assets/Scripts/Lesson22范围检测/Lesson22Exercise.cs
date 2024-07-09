using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lesson22Exercise : MonoBehaviour
{
    // WS����ǰ���ƶ�, AD������ת
    // j ��������ǰ��1m��λ�ý��������巶Χ���
    // k ��������ǰ��5m��λ�ý��н����巶Χ���
    // l �����������Ϊԭ��,�뾶Ϊ10m�ķ�Χ�ڽ������η�Χ���

    float moveSpeed = 5.0f;
    float rotateSpeed = 45.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �ƶ�����ת
        PlayerMoveForward(moveSpeed);
        PlayerTurnRight(rotateSpeed);

        // ����123
        Skill1();
        Skill2();
        Skill3();

    }

    void PlayerMoveForward(float moveSpeed)
    {
        this.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
    }
    void PlayerTurnRight(float rotateSpeed)
    {
        this.transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
    }

    // ����
    void Skill1()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Collider[] colliders = Physics.OverlapBox(this.transform.position + this.transform.forward,
                Vector3.one,
                Quaternion.identity,
                1 << LayerMask.NameToLayer("Monster")
                );
            for (int i = 0; i < colliders.Length; i++)
            {
                print(colliders[i].name);
            }
        }
    }

    void Skill2()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Collider[] colliders = Physics.OverlapCapsule(this.transform.position, 
                this.transform.position + this.transform.forward * 5,
                0.5f,
                1 << LayerMask.NameToLayer("Monster")
                );

            for (int i = 0; i < colliders.Length; i++)
            {
                print(colliders[i].name);
            }
        }
    }

    void Skill3()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {

            Collider[] colliders = Physics.OverlapSphere(this.transform.position,
                10.0f,
                1 << LayerMask.NameToLayer("Monster")
                );

            for (int i = 0; i < colliders.Length; i++)
            {
                print(colliders[i].name);
            }
        }
    }
}
