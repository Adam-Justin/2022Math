using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lesson20 : MonoBehaviour
{
    AsyncOperation aso = null;
    // Start is called before the first frame update
    void Start()
    {
        // ͬ�����س���
        // SceneManager.LoadScene("���Գ���");        
    }

    /// <summary>
    /// ��ͨ�첽���س��� + ���ûص�����
    /// </summary>
    /// <param name="scenenName">��������</param>
    void LoadSceneAsychonized(string scenenName)
    {
        // ���س���
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenenName);
        operation.completed += LoadSceneCompleted;
    }
    /// <summary>
    /// ����������ϻص�����
    /// </summary>
    /// <param name="operation"></param>
    private void LoadSceneCompleted(AsyncOperation operation)
    {
        // ����������ɺ�ִ�еĴ���
        Debug.Log("Scene loaded successfully");

        // ��������Խ��г�����ʼ����������Һͳ�ʼ����Ϸ����������Ϸ״̬��
    }

    /// <summary>
    /// �첽���س��� + Э�̵ķ�ʽ
    /// </summary>
    void LoadSceneAsychonizedWithCoroutine(string scenenName)
    {
        // �첽���س���
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenenName);

        // ��ֹ����������������³�����
        operation.allowSceneActivation = false;

        // ��ؼ��ؽ���
        // ����һ��Э������ؼ��ؽ���
        StartCoroutine(LoadWaitScene(operation));
    }

    /// <summary>
    /// Э�̵ķ�ʽ�첽���س���
    /// </summary>
    /// <param name="sceneName">��������</param>
    /// <returns></returns>
    IEnumerator LoadScene(string sceneName)
    {
        DontDestroyOnLoad(this.gameObject);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        Debug.Log("������...");
        yield return operation;
        // ����������޷���ӡ,��Ϊ�������������,��ǰ��������Ϸ����,�ű����Ƴ�
        Debug.Log("����������Ϻ��ӡ����");
        // Ҫ�볡��������Ϻ�Ҳ���Լ���ִ��yield return ��Ĵ���,��Ҫʹ�� DontDestroyOnLoad ����������
        // ע��: DontDestroyOnLoad�������Ҫ�����첽���س���֮ǰ������λ��,��������Э��ǰ,�������ڿ����첽���س���Э��ǰ.
       
        Debug.Log("���س���ʱ�����ٶ���");

        // �������ؽ���,����������ʾ����
        // �������ؽ���, ����������һ��
        // ���ż��س����е�������Ϣ
        // ���ع���-���������Ͻ���������һ��
        // ��̬���� ����ģ��
        // ��ʱ�����Ϊ�������,����������100%, ���ؽ�����
        
    }
    /// <summary>
    /// �Զ���Э�̼��س���
    /// </summary>
    /// <param name="operation"></param>
    /// <returns></returns>
    IEnumerator LoadWaitScene(AsyncOperation operation)
    {
        // ��ü��ؽ���
        while(! operation.isDone)
        {
            Debug.Log("������...\t����: " + operation.progress);
            if (operation.progress >= 0.9f)
            {
                // ����� Allow Scenes to be activated as soon as it is ready.
                operation.allowSceneActivation = true;
            }
            
            // �Լ������ٵĽ�����
            yield return null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ��ͨ�첽���س��� + �ص�����
            LoadSceneAsychonized("���Գ���");

            // һ�첽���س��� + Э��
            // LoadSceneAsychonizedWithCoroutine("���Գ���");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            // ����Э�� + ���س��������ٶ���
            StartCoroutine(LoadScene("���Գ���"));
        }
    }
}
