using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson17 : MonoBehaviour
{
    AudioSource audioSource;
    Texture texture;
    // Start is called before the first frame update
    void Start()
    {
        
        // 加载Resources文件夹下的预制体
        GameObject go = Resources.Load("Cube") as GameObject;
        Instantiate(go);

        // 加载其他文件夹下的Resources下的预制体
        GameObject goSphere = Resources.Load("Sphere") as GameObject;
        Instantiate(goSphere);

        // 加载音频文件
        
        AudioClip audioClip = Resources.Load("Music/BGM") as AudioClip;
        audioSource = this.gameObject.AddComponent<AudioSource>();

        audioSource.clip = audioClip;

        // 使用泛型加载
        TextAsset textAsset = Resources.Load<TextAsset>("Documents/ReadMe");
        string textString = textAsset.text;
        Debug.Log(textString);

        // 加载图片
        texture  = Resources.Load<Texture>("Pictures/Picture");



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
            else
            {   
                
                audioSource.Play();
            }
        }
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(new Vector2(0, 0), new Vector2(Screen.width, Screen.height)), texture);
    }
}
