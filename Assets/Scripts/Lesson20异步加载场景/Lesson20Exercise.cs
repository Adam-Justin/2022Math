using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson20Exercise : MonoBehaviour
{    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            MySceneManager.Instance.LoadScene("测试场景", loadCompleteAction);
        }
    }

    private void loadCompleteAction()
    {
        Debug.Log("场景加载完毕");
    }
}
