    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;
[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(AudioSource))]
public class TrackFound_ImageTarget : MonoBehaviour, ITrackableEventHandler
   
{
   

    protected TrackableBehaviour mTrackableBehaviour;

    public VideoPlayer videoPlayer;
    public AudioSource audioPlayer;
    public GameObject VideoPlane;

    // Use this for initialization
    void Start() {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

        GameObject video = GameObject.Find("Video_Plane");
       var video1 =  videoPlayer.GetComponent<VideoPlayer>();
        var Audio1 = audioPlayer.GetComponent<AudioSource>();
        //videoPlayer = video.GetComponent<VideoPlayer>();
        //videoPlayer.Play();
        //videoPlayer.Pause();

        //video1.Play();
        //Audio1.Play();

        //audioPlayer = video.GetComponent<AudioSource>();
        //audioPlayer.Play();
        //audioPlayer.Pause();

    }
    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }
  void Update()
    {
        if (mTrackableBehaviour.TrackableName == "3")
        {
            Debug.Log("HELLLOP");
        }
    }
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            var video1 = videoPlayer.GetComponent<VideoPlayer>();
            var Audio1 = audioPlayer.GetComponent<AudioSource>();
           
            Debug.Log("Play");
            video1.Play();
            Audio1.Play();
            VideoPlane.SetActive(true);

            //Assign the Audio from Video to AudioSource to be played
            // <-- We have added this line. It tells video player that you will have one audio track playing in Unity AudioSource.
            //videoPlayer.EnableAudioTrack(0, true);
            //videoPlayer.SetTargetAudioSource(0, AudioSource);

        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            var video1 = videoPlayer.GetComponent<VideoPlayer>();
            var Audio1 = audioPlayer.GetComponent<AudioSource>();
            Debug.Log("Stop!");
            video1.Stop();
            Audio1.Stop();
            VideoPlane.SetActive(false);
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
         
        }
    }

}
