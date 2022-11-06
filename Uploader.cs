using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;


public class Uploader : MonoBehaviour
{
    string url = "https://UnityUpload.php";//��дhttps://xxxxxxxxx/UnityUpload.php
    /// <summary>
    /// �ϴ���������
    /// </summary>
    public void UploadFile()
    {
        StartCoroutine(UploadVideo());
    }

    // �ϴ���Ƶ
    IEnumerator UploadVideo()
    {
        byte[] fileByte = File.ReadAllBytes("Assets/Textures/transferFile.png");
        WWWForm form = new WWWForm();
        form.AddField("Name", "uploadFile");
        //�����Լ��������ļ��޸ĸ�ʽ
        form.AddBinaryData("post", fileByte);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string text = www.downloadHandler.text;
                Debug.Log("����������ֵ" + text);
            }
        }
    }
}
