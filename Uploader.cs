using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;


public class Uploader : MonoBehaviour
{
    string url = "https://UnityUpload.php";//填写https://xxxxxxxxx/UnityUpload.php
    /// <summary>
    /// 上传到服务器
    /// </summary>
    public void UploadFile()
    {
        StartCoroutine(UploadVideo());
    }

    // 上传视频
    IEnumerator UploadVideo()
    {
        byte[] fileByte = File.ReadAllBytes("Assets/Textures/transferFile.png");
        WWWForm form = new WWWForm();
        form.AddField("Name", "uploadFile");
        //根据自己长传的文件修改格式
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
                Debug.Log("服务器返回值" + text);
            }
        }
    }
}
