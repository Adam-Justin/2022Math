using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson14 : MonoBehaviour
{
    Coroutine c1;
    Coroutine c2;
    Coroutine c3;
    // 协程程序
    // 1. 协程的使用
    // 1.1 协程的写法
    public IEnumerator MyCoroutine(int i, string str, float t)
    {
        print(i);
        // 返回值IEumerator yield return 来分时函数,即等待多少秒后继续执行函数
        yield return new WaitForSeconds(5.0f);              // 等待5s后执行
        print(str);
        yield return new WaitForSeconds(3.0f);
        print(t);
        //yield return new WaitForEndOfFrame();               // 等待当前帧绘制完毕后执行
        //print(t);
        //yield return new WaitForFixedUpdate();              // 直到下一个固定更新周期到了执行
        //print(i);
    }
    // 2. 开启协程
    // 2.1 不同用普通的函数调用来开启协程
    // MyCoroutine(3, "不能使用普通方法调用开启/协程", 5.0f);
    // 2.2 开启方法1
    public void StartMyCoroutine1()
    {
        StartCoroutine(MyCoroutine(1, "开启协程1", 1.0f));
    }

    // 2.3 开启方法2
    public void StartMyCoroutine2()
    {
        IEnumerator ie =  MyCoroutine(1, "开启协程2", 1.0f);
        StartCoroutine(ie);
    }
    // 2.4 开启多个协程
    public void StartMyCoroutine3()
    {
        // 开启协程后保留写出对象
        c1 = StartCoroutine(MyCoroutine(1, "多个协程1", 1.0f));
        c2 = StartCoroutine(MyCoroutine(1, "多个协程2", 1.0f));
        c3 = StartCoroutine(MyCoroutine(1, "多个协程3", 1.0f));
       
    }
    // 3. 关闭协程
    public void CloseAllCoroutine()
    {
        StopAllCoroutines();
    }
    // 4. 关闭指定协程
    public void CloseSpecialCoroutine()
    {
        StopCoroutine(c1);
        StopCoroutine(c2);
        StopCoroutine(c3);
        // StopCoroutine(IEnumerator routine); 通过IEnumerator关闭              
        // StopCoroutine(Coroutine routine);   通过协程名称关闭
        // StopCoroutine(string methodName);   通过协程函数名关闭
    }

    // 5. 提前跳出协程
    public void BreakCoroutine()
    {
        IEnumerator MyNewCoroutine()
        {
            Debug.Log("开始执行协同程序");

            // 执行一些操作
            yield return new WaitForSeconds(1.0f);
            Debug.Log("协同程序执行了一秒");

            // 在这里，我们检查一个条件
            if (SomeCondition())
            {
                Debug.Log("满足条件，提前结束协同程序");
                yield break; // 提前终止协同程序
            }

            // 如果上面的条件不满足，这将不会执行
            yield return new WaitForSeconds(1.0f);
            Debug.Log("协同程序又执行了一秒");
        }
        StartCoroutine(MyNewCoroutine());

    }
    bool SomeCondition()
    {
        // 这里是条件的逻辑
        return true; // 例如，始终返回 true 来终止协同程序
    }
    void Start()
    {
        StartMyCoroutine1();
        StartMyCoroutine2();
        StartMyCoroutine3();
        CloseSpecialCoroutine();
        BreakCoroutine();
        // CloseAllCoroutine();
    }


}
