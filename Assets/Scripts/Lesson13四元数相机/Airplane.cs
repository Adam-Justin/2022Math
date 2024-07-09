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
    private GameObject bulletObj; // 子弹预制体
    [Header("环形发射子弹配置")]
    public int roundNubmber = 4; // 环形发射子弹数量
    private float roundAngle = 0.0f;// 发射角度
    // Start is called before the first frame update
    void Start()
    {
        bulletObj = Resources.Load<GameObject>("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        // 按键检测
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
    /// 生成并发射子弹
    /// </summary>
    /// <param name="nowType"></param>
    private void SpawnBullet(E_FireType nowType)
    {
        switch (nowType)
        {
            case E_FireType.One:
                // 实例化一枚子弹
                Instantiate(bulletObj, this.transform.position, this.transform.rotation);
                break;
            case E_FireType.Two:
                // 计算位置--左和右
                Instantiate(bulletObj, this.transform.position - this.transform.right * 0.5f * this.transform.localScale.x, this.transform.rotation);
                Instantiate(bulletObj, this.transform.position + this.transform.right * 0.5f * this.transform.localScale.x, this.transform.rotation);
                break;
            case E_FireType.Three:
                // 左45度一个 右45度一个 中间一个
                // 构建偏移角度
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
    /// 按键检测
    /// </summary>
    /// <param name="nowType"> 传入传出全局开火枚举类型</param>
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
