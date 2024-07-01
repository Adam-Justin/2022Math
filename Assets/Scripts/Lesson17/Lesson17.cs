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
        
        // ����Resources�ļ����µ�Ԥ����
        GameObject go = Resources.Load("Cube") as GameObject;
        Instantiate(go);

        // ���������ļ����µ�Resources�µ�Ԥ����
        GameObject goSphere = Resources.Load("Sphere") as GameObject;
        Instantiate(goSphere);

        // ������Ƶ�ļ�
        
        AudioClip audioClip = Resources.Load("Music/BGM") as AudioClip;
        audioSource = this.gameObject.AddComponent<AudioSource>();

        audioSource.clip = audioClip;

        // ʹ�÷��ͼ���
        TextAsset textAsset = Resources.Load<TextAsset>("Documents/ReadMe");
        string textString = textAsset.text;
        Debug.Log(textString);

        // ����ͼƬ
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
