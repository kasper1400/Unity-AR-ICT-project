using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Threading;

public class GetData : MonoBehaviour {

    public string Room;
    public Text Subject;
    public Text StartDate;
    public Text EndDate;
    string url = "https://opendata.hamk.fi:8443/r1/reservation/search";

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
        // Used for GET request:
        //string url = "https://opendata.hamk.fi:8443/r1/reservation/building";
        //UnityWebRequest www = UnityWebRequest.Get(url);

        // Using API key as username for authorization
        string authorization = Authenticate("ucSrzhL6ojWEXotgiOWM", "");

        // Defining JSON query
        CultureInfo ci = Thread.CurrentThread.CurrentCulture;
        DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;
        DayOfWeek today = DateTime.Now.DayOfWeek;
        DateTime FirstDayOfThisWeek = DateTime.Now.AddDays(-(today - fdow)).Date;
        DateTime LastDayOfThisWeek = DateTime.Now.AddDays(-(today - fdow - 7)).Date;
        var json = "{'startDate':'"+ FirstDayOfThisWeek.ToString("yyyy-MM-ddTHH:mm")+"', 'endDate': '"+LastDayOfThisWeek.ToString("yyyy-MM-ddTHH:mm")+"', 'room': ['"+ Room +"']}";
        
        // Sending JSON query as POST method to web server and receiving response 
        var postData = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest www = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST);
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(json);
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        www.SetRequestHeader("AUTHORIZATION", authorization);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Saving JSON values in a string
            string jsonString = www.downloadHandler.text;

            Debug.Log(jsonString);

            // Parsing JSON data and sending results to GUI Text elements
            foreach (var acc in JObject.Parse(jsonString)["reservations"])
            {
                string subject = acc["subject"].ToString();
                //subject = subject.Substring(0, 23);
                Subject.GetComponent<Text>().text += subject + "\n" + "\n";
            
                string startdate = acc["startDate"].ToString();
                StartDate.GetComponent<Text>().text +=  startdate + "\n" + "\n";
            
                string enddate = acc["endDate"].ToString();        
                EndDate.GetComponent<Text>().text += enddate + "\n" + "\n";         
            }
        } 
    }
}
