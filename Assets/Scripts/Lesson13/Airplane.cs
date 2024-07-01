using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_FireType
{
    One,
    Two,
    Three,
    Round
}
public class Airplane : MonoBehaviour
{

    private E_FireType nowType = E_FireType.One;
    private GameObject bulletObj; // �ӵ�Ԥ����
    [Header("���η����ӵ�����")]
    public int roundNubmber = 4; // ���η����ӵ�����
    private float roundAngle = 0.0f;// ����Ƕ�
    // Start is called before the first frame update
    void Start()
    {
        bulletObj = Resources.Load<GameObject>("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        // �������
        SwitchFireType(ref nowType);
        Fire(nowType);
        

    }


    private void Fire(E_FireType nowType)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullet(nowType);
        }

    }
    /// <summary>
    /// ���ɲ������ӵ�
    /// </summary>
    /// <param name="nowType"></param>
    private void SpawnBullet(E_FireType nowType)
    {
        switch (nowType)
        {
            case E_FireType.One:
                // ʵ����һö�ӵ�
                Instantiate(bulletObj, this.transform.position, this.transform.rotation);
                break;
            case E_FireType.Two:
                // ����λ��--�����
                Instantiate(bulletObj, this.transform.position - this.transform.right * 0.5f * this.transform.localScale.x, this.transform.rotation);
                Instantiate(bulletObj, this.transform.position + this.transform.right * 0.5f * this.transform.localScale.x, this.transform.rotation);
                break;
            case E_FireType.Three:
                // ��45��һ�� ��45��һ�� �м�һ��
                // ����ƫ�ƽǶ�
                Quaternion q0 = Quaternion.AngleAxis(0, Vector3.up);
                Quaternion q1 = Quaternion.AngleAxis(22.5f, Vector3.up);
                Quaternion q2 = Quaternion.AngleAxis(-22.5f, Vector3.up);
                Instantiate(bulletObj, this.transform.position, this.transform.rotation * q0);
                Instantiate(bulletObj, this.transform.position, this.transform.rotation * q1);
                Instantiate(bulletObj, this.transform.position, this.transform.rotation * q2);
                break;
            case E_FireType.Round:

                roundAngle = 360 / 2 / roundNubmber;
                for (int i = 0; i < roundNubmber; i++)
                {
                    Instantiate(bulletObj, this.transform.position, this.transform.rotation * Quaternion.AngleAxis(roundAngle * i,Vector3.up));
                }
                
                break;
        }
    }
    
    /// <summary>
    /// �������
    /// </summary>
    /// <param name="nowType"> ���봫��ȫ�ֿ���ö������</param>
    private void SwitchFireType(ref E_FireType nowType)
    { 
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            nowType = E_FireType.One;
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            nowType = E_FireType.Two;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            nowType = E_FireType.Three;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            nowType = E_FireType.Round;
        }
    }
}
