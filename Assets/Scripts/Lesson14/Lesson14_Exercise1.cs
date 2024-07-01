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
                // ˳���ʱ

                // �ִ���ֹʱ��
                if (time >= sumSeconds)
                {
                    Debug.Log(sumSeconds + "s ʱ�䵽(˳���ʱ)");
                    yield break;
                }
                // �ӳ�һ��ִ��
                yield return new WaitForSeconds(1.0f);
                // �޸�ʱ��
                time++;
                // ��ӡʱ��
                Debug.Log(time);
            }
            
        }
        else 
        {
            // ����ʱ
            time = sumSeconds;
            while (true)
            {
                
                // �ִ���ֹʱ��
                if (time <= 0)
                {
                    Debug.Log(sumSeconds + "s ʱ�䵽(�����ʱ)");
                    yield break;
                }

                // �޸�ʱ�� ��ӡʱ��
                Debug.Log(time--);

                // �ӳ�һ��ִ��
                yield return new WaitForSeconds(1.0f);
                
            }
            
        }

    }
    private void Start()
    {
        // ����������Э��
        Coroutine c1 = StartCoroutine(TimeConter(10, true));
        Coroutine c2 = StartCoroutine(TimeConter(3, false));
    }

}
