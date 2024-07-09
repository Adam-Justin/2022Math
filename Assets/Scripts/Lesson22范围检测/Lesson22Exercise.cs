using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lesson22Exercise : MonoBehaviour
{
    // WS控制前后移动, AD控制旋转
    // j 在立方体前面1m的位置进行立方体范围检测
    // k 在立方体前面5m的位置进行胶囊体范围检测
    // l 在立方体脚下为原点,半径为10m的范围内进行球形范围检测

    float moveSpeed = 5.0f;
    float rotateSpeed = 45.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 移动和旋转
        PlayerMoveForward(moveSpeed);
        PlayerTurnRight(rotateSpeed);

        // 技能123
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

    // 技能
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
