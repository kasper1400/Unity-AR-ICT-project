using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetData : MonoBehaviour {

    public string URL;
    public Text ID_text;

    // Use this for initialization
    void Start() {
        StartCoroutine(MakeRequest());
    }

    // Update is called once per frame
    void Update() {
    }

    string Authenticate(string username, string password)
    {
        string auth = username + ":" + password;
        auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
        auth = "Basic " + auth;
        return auth;
    }

    IEnumerator MakeRequest()
    {
        //string url = "https://opendata.hamk.fi:8443/r1/reservation/building";
        //UnityWebRequest www = UnityWebRequest.Get(url);

        string authorization = Authenticate("ucSrzhL6ojWEXotgiOWM", "");
        string url = "https://opendata.hamk.fi:8443/r1/reservation/search";
        var timeNow = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm");
        var json = "{'startDate':'"+ timeNow +"', 'endDate': '2018-11-26T00:00', 'room': ['Vi-C-222']}";

        var postData = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest www = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST);
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(json);
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        www.SetRequestHeader("AUTHORIZATION", authorization);
        //www.chunkedTransfer = false;

        yield return www.Send();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }

    //IEnumerator GetDataFromServer(){

    //    WWWForm formData = new WWWForm();
    //    formData.AddField("userName", "ucSrzhL6ojWEXotgiOWM");

    //    WWW www;
    //    www = new WWW(URL);
    //    yield return www;

    //    string json = www.text;

    //    if (www.isDone)
    //    {
    //        Building data = JsonUtility.FromJson<Building>(json);
    //        ID_text.text = data.id;
    //    }
    //}

    class Building
    {
        public string id;
        public string type;
    }
}
