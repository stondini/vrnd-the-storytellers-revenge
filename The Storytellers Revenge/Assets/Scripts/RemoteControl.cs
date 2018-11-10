using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteControl : MonoBehaviour {

    private const double TITLE_TIME = 5;

    private const double CREDIT_1_TIME = 55;

    private const double CREDIT_2_TIME = 74;

    private const double CHAP_1_TIME = 0;

    private const double CHAP_2_TIME = 35;

    private const double CHAP_3_TIME = 44.6;

    private const double PATH_1_TIME = 45;

    private const double PATH_2_TIME = 64;

    public GameObject titlePanel;

    public GameObject actionPanel;

    public GameObject pathSelectionPanel;

    public GameObject creditPanel;

    public GameObject videoSphere;

    private VideoPlayer videoPlayer;

    public GameObject particleSys;

    public GameObject heavenAudioSrc;

    public GameObject hellAudioSrc;

    // Use this for initialization
    void Start () {
        hellAudioSrc.GetComponent<ResonanceAudioSource>().audioSource.Stop();
        heavenAudioSrc.GetComponent<ResonanceAudioSource>().audioSource.Stop();

        videoPlayer = videoSphere.GetComponent<UnityEngine.Video.VideoPlayer>();
        particleSys.SetActive(false);
        //videoPlayer.url = "https://www.dropbox.com/s/dl/l9agvws26ixzea9/Strange%20Road%20-%20Mobile4K.mp4";
        //videoPlayer.url = "https://www.dropbox.com/s/dl/chvntnvytzfu7wd/BW_Short.mp4";
        Debug.Log("URL: " + videoPlayer.url);
        videoPlayer.playOnAwake = false;
        videoPlayer.Prepare();
        Debug.Log("Prepared");
        videoPlayer.Play();
        JumpToChapter1();
    }
	
	void FixedUpdate () {
        double videoTime = videoPlayer.time;
        if ((videoTime >= TITLE_TIME) && titlePanel.active) {
            Debug.Log("Title timeout: " + videoTime);
            titlePanel.SetActive(false);
            actionPanel.SetActive(true);
        }
        if ((videoTime >= CHAP_3_TIME) && (videoTime < PATH_1_TIME)) {
            Debug.Log("Path chose time: " + videoTime);
            videoPlayer.Stop();
            pathSelectionPanel.SetActive(true);
        }
        if (((videoTime >= CREDIT_1_TIME) && (videoTime < PATH_2_TIME)) | (videoTime > CREDIT_2_TIME)) {
            Debug.Log("Credit time: " + videoTime);
            videoPlayer.Stop();
            creditPanel.SetActive(true);
            particleSys.SetActive(true);
        }
    }

    private void JumpTo(double time, bool particle, bool showTitle, bool showActions, bool showCredit) {
        particleSys.SetActive(particle);
        titlePanel.SetActive(showTitle);
        pathSelectionPanel.SetActive(false);
        actionPanel.SetActive(showActions);
        creditPanel.SetActive(showCredit);
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Prepare();
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Pause();
            videoPlayer.time = time;
            videoPlayer.Play();
        }
    }

    public void JumpToChapter1 () {
        hellAudioSrc.GetComponent<ResonanceAudioSource>().audioSource.Stop();
        heavenAudioSrc.GetComponent<ResonanceAudioSource>().audioSource.Stop();
        JumpTo(CHAP_1_TIME, false, true, false, false);
    }

    public void JumpToChapter2() {
        hellAudioSrc.GetComponent<ResonanceAudioSource>().audioSource.Stop();
        heavenAudioSrc.GetComponent<ResonanceAudioSource>().audioSource.Stop();
        JumpTo(CHAP_2_TIME, false, false, true, false);
    }

    public void JumpToChapter3() {
        hellAudioSrc.GetComponent<ResonanceAudioSource>().audioSource.Stop();
        heavenAudioSrc.GetComponent<ResonanceAudioSource>().audioSource.Stop();
        JumpTo(CHAP_3_TIME, false, false, true, false);
    }

    public void SelectPath1() {
        pathSelectionPanel.SetActive(false);
        videoPlayer.Pause();
        videoPlayer.time = PATH_1_TIME;
        videoPlayer.Play();
        hellAudioSrc.GetComponent<ResonanceAudioSource>().audioSource.Stop();
        heavenAudioSrc.GetComponent<ResonanceAudioSource>().audioSource.Play();
    }

    public void SelectPath2() {
        pathSelectionPanel.SetActive(false);
        videoPlayer.Pause();
        videoPlayer.time = PATH_2_TIME;
        videoPlayer.Play();
        heavenAudioSrc.GetComponent<ResonanceAudioSource>().audioSource.Stop();
        hellAudioSrc.GetComponent<ResonanceAudioSource>().audioSource.Play();
    }
}