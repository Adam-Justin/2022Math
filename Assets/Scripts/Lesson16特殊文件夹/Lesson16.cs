using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson16 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ����·����ȡ
        //ע�� �÷�ʽ ��ȡ����·�� һ������� ֻ�� �༭ģʽ��ʹ��
        //���ǲ�����ʵ�ʷ�����Ϸ�� ��ʹ�ø�·��
        //��Ϸ�������� ��·���Ͳ������� 
        print(Application.dataPath);
        #endregion

        #region ֪ʶ��� Resources ��Դ�ļ���
        //·����ȡ��
        //һ�㲻��ȡ
        //ֻ��ʹ��Resources���API���м���
        //���ӲҪ��ȡ �����ù���·��ƴ��
        print(Application.dataPath + "/Resources");

        //ע�⣺
        //��Ҫ�����Լ�������
        //���ã�
        //��Դ�ļ���
        //1-1.��Ҫͨ��Resources���API��̬���ص���Դ��Ҫ��������
        //1-2.���ļ����������ļ����ᱻ�����ȥ
        //1-3.���ʱUnity�����ѹ������
        //1-4.���ļ��д����ֻ�� ֻ��ͨ��Resources���API����
        #endregion

        #region ֪ʶ���� StreamingAssets ������Դ�ļ���
        //·����ȡ��
        print(Application.streamingAssetsPath);
        //ע�⣺
        //��Ҫ�����Լ�������
        //���ã�
        //���ļ���
        //2-1.�����ȥ���ᱻѹ�����ܣ������������ǰڲ�
        //2-2.�ƶ�ƽֻ̨����PCƽ̨�ɶ���д
        //2-3.���Է���һЩ��Ҫ�Զ��嶯̬���صĳ�ʼ��Դ
        #endregion

        #region ֪ʶ���� persistentDataPath �־������ļ���
        //·����ȡ��
        print(Application.persistentDataPath);

        //ע�⣺
        //����Ҫ�����Լ�������
        //���ã�
        //�̶������ļ���
        //3-1.����ƽ̨���ɶ���д
        //3-2.һ�����ڷ��ö�̬���ػ��߶�̬�������ļ�����Ϸ�д������߻�ȡ���ļ�����������
        #endregion

        #region ֪ʶ���� Plugins ����ļ���
        //·����ȡ��
        //һ�㲻��ȡ

        //ע�⣺
        //��Ҫ�����Լ�������
        //���ã�
        //����ļ���
        //��ͬƽ̨�Ĳ������ļ���������
        //����IOS��Androidƽ̨
        #endregion

        #region ֪ʶ���� Editor �༭���ļ���
        //·����ȡ��
        //һ�㲻��ȡ
        //���ӲҪ��ȡ �����ù���·��ƴ��
        print(Application.dataPath + "/Editor");

        //ע�⣺
        //��Ҫ�����Լ�������
        //���ã�
        //�༭���ļ���
        //5-1.����Unity�༭��ʱ���༭����ؽű����ڸ��ļ�����
        //5-2.���ļ��������ݲ��ᱻ�����ȥ
        #endregion

        #region ֪ʶ���� Ĭ����Դ�ļ��� Standard Assets
        //·����ȥ��
        //һ�㲻��ȡ

        //ע�⣺
        //��Ҫ�����Լ�������
        //���ã�
        //Ĭ����Դ�ļ���
        //һ��Unity�Դ���Դ����������ļ�����
        //�������Դ���ȱ�����
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
