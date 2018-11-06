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

    private const double CHAP_3_TIME = 44;

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
        videoPlayer = videoSphere.GetComponent<UnityEngine.Video.VideoPlayer>();
        particleSys.SetActive(false);
        JumpToChapter1();
        videoPlayer.Play();
    }
	
	void FixedUpdate () {
        double videoTime = videoPlayer.time;
        if (videoTime > TITLE_TIME) {
            titlePanel.SetActive(false);
            actionPanel.SetActive(true);
        }
        if ((videoTime > CHAP_3_TIME) && (videoTime < PATH_1_TIME)) {
            videoPlayer.Stop();
            pathSelectionPanel.SetActive(true);
        }
        if (((videoTime > CREDIT_1_TIME) && (videoTime < PATH_2_TIME)) | (videoTime > CREDIT_2_TIME))
        {
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
        if (!videoPlayer.isPlaying) {
            videoPlayer.Prepare();
            videoPlayer.Play();
        }
        videoPlayer.time = time;
    }

    public void JumpToChapter1 () {
        hellAudioSrc.GetComponent<GvrAudioSource>().Stop();
        heavenAudioSrc.GetComponent<GvrAudioSource>().Stop();
        JumpTo(CHAP_1_TIME, false, true, false, false);
    }

    public void JumpToChapter2() {
        hellAudioSrc.GetComponent<GvrAudioSource>().Stop();
        heavenAudioSrc.GetComponent<GvrAudioSource>().Stop();
        JumpTo(CHAP_2_TIME, false, false, true, false);
    }

    public void JumpToChapter3() {
        hellAudioSrc.GetComponent<GvrAudioSource>().Stop();
        heavenAudioSrc.GetComponent<GvrAudioSource>().Stop();
        JumpTo(CHAP_3_TIME, false, false, true, false);
    }

    public void SelectPath1() {
        pathSelectionPanel.SetActive(false);
        videoPlayer.Prepare();
        videoPlayer.time = PATH_1_TIME;
        videoPlayer.Play();
        hellAudioSrc.GetComponent<GvrAudioSource>().Stop();
        heavenAudioSrc.GetComponent<GvrAudioSource>().Play();
    }

    public void SelectPath2() {
        pathSelectionPanel.SetActive(false);
        videoPlayer.Prepare();
        videoPlayer.time = PATH_2_TIME;
        videoPlayer.Play();
        heavenAudioSrc.GetComponent<GvrAudioSource>().Stop();
        hellAudioSrc.GetComponent<GvrAudioSource>().Play();
    }
}