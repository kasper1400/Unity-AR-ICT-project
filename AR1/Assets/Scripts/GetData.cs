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
using System.Linq;


public class GetData : MonoBehaviour {

    public string Room;
    public Text Title;
    public Text Monday;
    public Text Tuesday;
    public Text Wednesday;
    public Text Thursday;
    public Text Friday;
    public Text Saturday;
    public Text Sunday;
    string url = "https://opendata.hamk.fi:8443/r1/reservation/search";
    public bool IsNextWeekClicked;
    public bool IsPreviousWeekClicked;
    public int DayCounter;
    public int WeekNumCounter;

    // Use this for initialization
    void Start() {
        IsPreviousWeekClicked = false;
        IsNextWeekClicked = false;
        StartCoroutine(MakeRequest());
    }

    // Update is called once per frame
    void Update() {
    }

    public void PreviousWeekbtn_Clicked(){
        IsPreviousWeekClicked = true;
        StartCoroutine(MakeRequest());
        Debug.Log("PreviousWeek Button clicked");
        IsPreviousWeekClicked = false;
    }

    public void NextWeekbtn_Clicked()
    {
        IsNextWeekClicked = true;
        StartCoroutine(MakeRequest());
        Debug.Log("NextWeek Button clicked");
        IsNextWeekClicked = false;
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
        Monday.GetComponent<Text>().text = null;
        Tuesday.GetComponent<Text>().text = null;
        Wednesday.GetComponent<Text>().text = null;
        Thursday.GetComponent<Text>().text = null;
        Friday.GetComponent<Text>().text = null;
        Saturday.GetComponent<Text>().text = null;
        Sunday.GetComponent<Text>().text = null;

        // Used for GET request:
        //string url = "https://opendata.hamk.fi:8443/r1/reservation/building";
        //UnityWebRequest www = UnityWebRequest.Get(url);

        // Using API key as username for authorization
        string authorization = Authenticate("ucSrzhL6ojWEXotgiOWM", "");

        // Defining weeknumber for title
        CultureInfo cul = CultureInfo.CurrentCulture;
        int weekNum = cul.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        // Defining JSON query
        CultureInfo ci = Thread.CurrentThread.CurrentCulture;
        DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;
        DayOfWeek today = DateTime.Now.DayOfWeek;
        DateTime FirstDayOfWeek = DateTime.Now.Date;
        DateTime LastDayOfWeek = DateTime.Now.Date;

        if (IsPreviousWeekClicked == true)
        {
            DayCounter -= 7;
            FirstDayOfWeek = DateTime.Now.AddDays(-(today - fdow - DayCounter)).Date;
            LastDayOfWeek = DateTime.Now.AddDays(-(today - fdow - DayCounter - 7)).Date;
            WeekNumCounter -= 1;
            weekNum = cul.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) + WeekNumCounter;
        }
        else if (IsNextWeekClicked == true)
        {
            DayCounter += 7;
            FirstDayOfWeek = DateTime.Now.AddDays(-(today - fdow - DayCounter)).Date;
            LastDayOfWeek = DateTime.Now.AddDays(-(today - fdow - DayCounter-7)).Date;
            WeekNumCounter += 1;
            weekNum = cul.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) + WeekNumCounter;
        }
        else {
            FirstDayOfWeek = DateTime.Now.AddDays(-(today - fdow)).Date;
            LastDayOfWeek = DateTime.Now.AddDays(-(today - fdow - 7)).Date;
        }
        var json = "{'startDate':'"+ FirstDayOfWeek.ToString("yyyy-MM-ddTHH:mm")+"', 'endDate': '"+LastDayOfWeek.ToString("yyyy-MM-ddTHH:mm")+"', 'room': ['"+ Room +"']}";

        // Adding week number to title
        Title.GetComponent<Text>().text = "Week " + weekNum.ToString() + " reservations " + Room;

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

            //Debug.Log(jsonString);
            JArray items = JArray.Parse(@"["+jsonString+"]");
            Debug.Log(items.ToString());

            // Parsing JSON data and sending results to GUI Text elements
            foreach (var acc in JObject.Parse(jsonString)["reservations"])
            {
                string sortingDate = acc["startDate"].ToString();
                DateTime date = Convert.ToDateTime(sortingDate);
                DayOfWeek Weekday = date.DayOfWeek;

                if ("Monday" == Weekday.ToString())
                {
                    //subject = subject.Substring(0, 30);
                    string subject = acc["subject"].ToString();
                    string startdate = acc["startDate"].ToString();
                    string enddate = acc["endDate"].ToString();
                    Monday.GetComponent<Text>().text += subject + "\n" + startdate + "\n" + enddate + "\n" + "\n";
                }

                if ("Tuesday" == Weekday.ToString())
                {
                    string subject = acc["subject"].ToString();
                    string startdate = acc["startDate"].ToString();
                    string enddate = acc["endDate"].ToString();
                    Tuesday.GetComponent<Text>().text += subject + "\n" + startdate +"\n" + enddate + "\n" + "\n";
                }

                if ("Wednesday" == Weekday.ToString())
                {
                    string subject = acc["subject"].ToString();
                    string startdate = acc["startDate"].ToString();
                    string enddate = acc["endDate"].ToString();
                    Wednesday.GetComponent<Text>().text += subject + "\n" + startdate + "\n" + enddate + "\n" + "\n";
                }

                if ("Thursday" == Weekday.ToString())
                {
                    string subject = acc["subject"].ToString();
                    string startdate = acc["startDate"].ToString();
                    string enddate = acc["endDate"].ToString();
                    Thursday.GetComponent<Text>().text += subject + "\n" + startdate + "\n" + enddate + "\n" + "\n";
                }

                if ("Friday" == Weekday.ToString())
                {
                    string subject = acc["subject"].ToString();
                    string startdate = acc["startDate"].ToString();
                    string enddate = acc["endDate"].ToString();
                    Friday.GetComponent<Text>().text += subject + "\n" + startdate + "\n" + enddate + "\n" + "\n";
                }

                if ("Saturday" == Weekday.ToString())
                {
                    string subject = acc["subject"].ToString();
                    string startdate = acc["startDate"].ToString();
                    string enddate = acc["endDate"].ToString();
                    Saturday.GetComponent<Text>().text += subject + "\n" + startdate + "\n" + enddate + "\n" + "\n";
                }

                if ("Sunday" == Weekday.ToString())
                {
                    string subject = acc["subject"].ToString();
                    string startdate = acc["startDate"].ToString();
                    string enddate = acc["endDate"].ToString();
                    Sunday.GetComponent<Text>().text += subject + "\n" + startdate + "\n" + enddate + "\n" + "\n";
                }
            }
        }
    }
}
