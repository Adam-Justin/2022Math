using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Lesson22 : MonoBehaviour
{

    void Start()
    {
        // 知识回顾 -- 物理系统中的碰撞检测
        // 碰撞产生的必要条件: 两个物体都要有碰撞器(也就是体积), 其中一个要有刚体也就是质量)

        // 碰撞和触发
        // 碰撞会产生实际的物理效果--位移 旋转等
        // 触发看起来不会产生碰撞,但是可以通过监听函数触发碰撞事件

        // 碰撞检测主要用于实体物体之间产生物理效果时候使用

        // 范围检测
        // 什么是范围检测
        // 游戏中一个瞬时攻击范围判断一般会使用范围检测
        // e.g. 玩家在前方5m处释放一个地刺魔法,在范围内的对象都会受到地刺的伤害
        // e.g. 玩家攻击--范围攻击,在方圆1m范围内的对象都收到伤害等等
        // 类似这种没有实体物体(技能/特效/视觉效果牛逼的) 只想检测在指定范围内让范围内的对象受伤的时候,就可以使用范围检测
        // 说人话: 在指定范围内 进行 范围判断 得到范围内的对象  进行处理==> 受伤/掉血/特效等

        // 如何使用功能范围检测

        // 必备条件: 想要被范围检测到的对象 必须要有碰撞器
        // 注意
        // 1. 范围检测API 只有当执行该句代码的时候 才会进行一次范围检测  是瞬时的 不会持久检测
        // 2. 范围检测API 并不会添加一个碰撞器  只是计算一个碰撞判断

        // 范围检测API的使用
        // 和我们的碰撞器一样,有box范围检测/球形范围检测/胶囊体范围检测/
        // box 范围检测
        // 参数一: 中心点 参数二:长宽高3条边的长度的一半 参数三:立方体的角度 参数四: 检测层级(需要与哪些层的检测,哪些层的不检测)
        // 参数五: 是否包含触发器 UseGlobal-使用全局设置 Collide-检测触发器 Ignore-忽略触发器  不填写使用UseGlobal
        // 返回值: 在该范围内的触发器(得到了对象触发器就可以得到对象上的所有信息)

        // Box的范围检测
        OverlapBox();
        OverlapBoxNonAlloc();

        // Sphere的范围检测
        OverlapSphere();
        OverlapSphereNonAlloc();

        //Capsule的范围检测
        OverlapCapsule();
        OverlapCapsuleNonAlloc();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    // box的两种方法
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

    // sphere的两种方法
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

    // 胶囊体的两种方法
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
        

        // 确保结果数组不为空
        if (colliders == null || colliders.Length == 0)
        {
            Debug.LogError("OverlapCapsuleNonAlloc: Results array is null or empty.");
            return 0;
        }

        // 清除结果数组中的所有元素
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i] = null;
        }

        // 使用Physics.OverlapCapsule来获取重叠的碰撞体
        int resultCapsuleCount = Physics.OverlapCapsuleNonAlloc(Vector3.zero, Vector3.forward, 2.0f, colliders, LayerMask.NameToLayer("Default"));

        // 返回重叠的碰撞体数量
        return resultCapsuleCount;

    }


}
