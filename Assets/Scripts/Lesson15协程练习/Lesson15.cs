using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Cup
{
    string name;    // 名称
    float length;   // 长
    float width;    // 宽
    float height;   // 高
    float weight;   // 重

    public Cup() { }

    public Cup(string name, float length, float width, float height, float weight)
    {
        this.name = name;
        this.length = length;
        this.width = width;
        this.height = height;
        this.weight = weight;
    }
    public override String ToString()
    {
        return ("杯子名称:"+this.name + "杯子长度:"+length as string + "杯子宽度:" + width as string + "杯子高度:" + height as string +"杯子重量:" + weight as string);
    }
}
public class Lesson15 : MonoBehaviour
{
    float time = 0.0f;
    IEnumerator ie;
    // 协程的本质 是迭代器-->分步执行

    IEnumerator MyCorntinue()
    {
        Debug.Log("第一次执行");
        yield return 1;
        Debug.Log("第二次执行");
        yield return 2;
        Debug.Log("第三次执行");
        yield return 3;
        Debug.Log("第四次执行");
         yield return new Cup("猫爪杯", 6.0f,6.0f,10.0f, 50.0f);
    }

    /// <summary>
    /// 执行协程
    /// </summary>
    /// <param name="ie">协程迭代器</param>
    /// <param name="time">延时时间</param>
    public void ExecCortinue( ref IEnumerator ie, ref float time)
    {
        // 使用计时实现分时执行
        if (time >= 1)
        {
            // 分步执行
            if (ie.MoveNext())
            {
                Debug.Log(ie.Current.ToString());
                time = 0.0f;
            }
        }
    }

    void Start()
    {
        // 保存协程
        ie = MyCorntinue();
    }

    void Update()
    {
        // 计时
        time += Time.deltaTime;
        // 执行协程
        ExecCortinue(ref ie, ref time);
    }
}
