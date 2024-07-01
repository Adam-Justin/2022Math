using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson15_Exercise : MonoBehaviour
{
    class Cat
    {
        public string name;
        public int age;
        public Cat() { }

        public Cat(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return "name:" + name + " age:" + age;
        }
    }
    /// <summary>
    /// yield return ����ֵ Ϊ��ʱʱ��
    /// </summary>
    /// <returns></returns>
    IEnumerator MyTest()
    {
        Debug.Log(Time.time + "1");
        yield return 1;
        Debug.Log(Time.time + "2");
        yield return 2;
        Debug.Log(Time.time + "3");
        yield return 3;
        Debug.Log(Time.time + "4");
        yield return new Cat("С��", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Unity�Դ�����Э��
        // ���ִ�����һ֡����
        // StartCoroutine(MyTest());
        // 
        // ʹ���Լ��ķ�ʽ����Э��
        IEnumerator ie = MyTest();
        CoroutineManager.Instance.MyStartCoroutine(MyTest());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
