using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;
[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(AudioSource))]
public class PlayVideoAtStart_ImageTarget : MonoBehaviour, ITrackableEventHandler

{
    protected TrackableBehaviour mTrackableBehaviour;

    public VideoPlayer videoPlayer;
    public AudioSource audioPlayer;
    public GameObject VideoPlane;
    public GameObject LobbyUI;
    private bool HasVideoPlayedOnce;

    // Use this for initialization
    void Start()
    {
        LobbyUI.SetActive(false);

        var VideoPresentation = videoPlayer.GetComponent<VideoPlayer>();
        var AudioPresentation = audioPlayer.GetComponent<AudioSource>();

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
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

    IEnumerator WaitForVideoToComplete()
    {
        yield return new WaitForSeconds(16.5f);
        LobbyUI.SetActive(true);
        VideoPlane.SetActive(false);
        HasVideoPlayedOnce = true;
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

            Debug.Log("Play");


            if (HasVideoPlayedOnce == false)
            {
                var VideoPresentation = videoPlayer.GetComponent<VideoPlayer>();
                var AudioPresentation = audioPlayer.GetComponent<AudioSource>();
                VideoPresentation.Play();
                AudioPresentation.Play();
                VideoPlane.SetActive(true);
                StartCoroutine(WaitForVideoToComplete());
            }
            else
            {
                LobbyUI.SetActive(true);
            }

            //yield return new WaitForSeconds(4.5f);


            //Assign the Audio from Video to AudioSource to be played
            // <-- We have added this line. It tells video player that you will have one audio track playing in Unity AudioSource.
            //videoPlayer.EnableAudioTrack(0, true);
            //videoPlayer.SetTargetAudioSource(0, AudioSource);

        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            Debug.Log("Stop!");
            var VideoPresentation = videoPlayer.GetComponent<VideoPlayer>();
            var AudioPresentation = audioPlayer.GetComponent<AudioSource>();
            VideoPresentation.Pause();
            AudioPresentation.Pause();
            VideoPlane.SetActive(false);
            LobbyUI.SetActive(false);
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations

        }
    }

}