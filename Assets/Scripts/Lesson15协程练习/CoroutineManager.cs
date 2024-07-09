using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class YieldReturnTime
{
    // 下次需要继续执行的迭代器接口
    public IEnumerator ie;
    //下次需要执行的时间
    public float time;
}
// 静态的协程管理器--给很多协程使用
public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager instance;
    // 申明存储迭代器返回的结构
    private List<YieldReturnTime> list = new List<YieldReturnTime>();
    public static CoroutineManager Instance
    {
        get
        {
            return instance;
        }
        
    }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    /// <summary>
    /// 自定义协程-分时-分步
    /// </summary>
    /// <param name="ie">协程</param>
    public void MyStartCoroutine(IEnumerator ie)
    {
        // 一开始就执行 moveNext为true代表后面还有内容
        if (ie.MoveNext())
        {
            // 判断返回值
            if (ie.Current is int)
            {
                // 返回的是数字, 需要等待 = 当前时间+等待时间
                // 将迭代器和等待时间记录下来,不停检测是否到了时间到了的话迭代器继续执行
                // 记录迭代器迭代器需要执行的时间
                YieldReturnTime yrt = new YieldReturnTime();

                yrt.ie = ie;
                yrt.time = Time.time + (int)ie.Current;

                // 添加到了协程列表中--可能有多个协程函数开启
                list.Add(yrt);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 检测list中所有协程是否到了自己的执行时间
        for (int i = list.Count - 1 ; i >= 0; i--)
        {
            //  判断是否到了时间--还没到yield return x的返回值
            if (list[i].time <= Time.time)
            {                
                // 判断是否执行完了
                if (list[i].ie.MoveNext())
                {
                    // true 后面还有内容需要保存并执行
                    if (list[i].ie.Current is int)
                    {
                        list[i].time = Time.time + (int)list[i].ie.Current;
                    }
                    else 
                    {
                        // 该list只是存储处理时间相关的迭代器返回值
                        // 如果是其他类型的需要放在其他的list中或者单独处理
                        list.RemoveAt(i);
                    }
                }
                else
                {
                    // 后面没数据了
                    list.RemoveAt(i);
                }
            }
            
        }
    }
}
