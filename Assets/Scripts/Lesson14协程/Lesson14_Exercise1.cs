using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson14_Exercise1 : MonoBehaviour
{
    
    IEnumerator TimeConter(int sumSeconds, bool sequence)
    {
        int time = 0;

        if (sequence)
        {
            while (true)
            {
                // 顺序计时

                // 抵达终止时间
                if (time >= sumSeconds)
                {
                    Debug.Log(sumSeconds + "s 时间到(顺序计时)");
                    yield break;
                }
                // 延迟一秒执行
                yield return new WaitForSeconds(1.0f);
                // 修改时间
                time++;
                // 打印时间
                Debug.Log(time);
            }
            
        }
        else 
        {
            // 倒计时
            time = sumSeconds;
            while (true)
            {
                
                // 抵达终止时间
                if (time <= 0)
                {
                    Debug.Log(sumSeconds + "s 时间到(倒序计时)");
                    yield break;
                }

                // 修改时间 打印时间
                Debug.Log(time--);

                // 延迟一秒执行
                yield return new WaitForSeconds(1.0f);
                
            }
            
        }

    }
    private void Start()
    {
        // 开启记秒器协程
        Coroutine c1 = StartCoroutine(TimeConter(10, true));
        Coroutine c2 = StartCoroutine(TimeConter(3, false));
    }

}
