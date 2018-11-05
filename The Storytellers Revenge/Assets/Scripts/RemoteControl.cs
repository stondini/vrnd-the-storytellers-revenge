using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteControl : MonoBehaviour {

    private const double TITLE_TIME = 5;

    private const double CREDIT_TIME = 55;

    private const double CHAP_1_TIME = 0;

    private const double CHAP_2_TIME = 35;

    private const double CHAP_3_TIME = 44;

    public GameObject titlePanel;

    public GameObject actionPanel;

    public GameObject creditPanel;

    public GameObject videoSphere;

    private VideoPlayer videoPlayer;

    public GameObject particleSys;

    // Use this for initialization
    void Start () {
        videoPlayer = videoSphere.GetComponent<UnityEngine.Video.VideoPlayer>();
        particleSys.SetActive(false);
        JumpToChapter1();
        videoPlayer.Play();
    }
	
	void FixedUpdate () {
        if (videoPlayer.time > TITLE_TIME) {
            titlePanel.SetActive(false);
            actionPanel.SetActive(true);
        }
        if (videoPlayer.time > CREDIT_TIME)
        {
            creditPanel.SetActive(true);
            particleSys.SetActive(true);
        }
    }

    private void JumpTo(double time, bool particle, bool showTitle, bool showActions, bool showCredit) {
        particleSys.SetActive(particle);
        titlePanel.SetActive(showTitle);
        actionPanel.SetActive(showActions);
        creditPanel.SetActive(showCredit);
        if (!videoPlayer.isPlaying) {
            videoPlayer.Prepare();
            videoPlayer.Play();
        }
        videoPlayer.time = time;
    }

    public void JumpToChapter1 () {
        JumpTo(CHAP_1_TIME, false, true, false, false);
    }

    public void JumpToChapter2() {
        JumpTo(CHAP_2_TIME, false, false, true, false);
    }

    public void JumpToChapter3() {
        JumpTo(CHAP_3_TIME, false, false, true, false);
    }
}
