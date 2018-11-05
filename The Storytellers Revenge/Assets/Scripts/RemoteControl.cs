using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteControl : MonoBehaviour {

    public GameObject titlePanel;

    public GameObject actionPanel;

    public GameObject creditPanel;

    public GameObject videoSphere;

    private VideoPlayer videoPlayer;

    // Use this for initialization
    void Start () {
        videoPlayer = videoSphere.GetComponent<UnityEngine.Video.VideoPlayer>();
        Init();
    }
	
	// Update is called once per frame
	void Update () {
        if (videoPlayer.time > 5) {
            titlePanel.SetActive(false);
            actionPanel.SetActive(true);
        }
        if (videoPlayer.time > 55)
        {
            creditPanel.SetActive(true);
        }
    }

    void Init () {
        titlePanel.SetActive(true);
        actionPanel.SetActive(false);
        creditPanel.SetActive(false);
        videoPlayer.Play();
    }

    public void JumpToChapter1 () {
        titlePanel.SetActive(true);
        actionPanel.SetActive(false);
        creditPanel.SetActive(false);
        videoPlayer.time = 0;
    }

    public void JumpToChapter2() {
        titlePanel.SetActive(false);
        actionPanel.SetActive(true);
        creditPanel.SetActive(false);
        videoPlayer.time = 35;
    }

    public void JumpToChapter3() {
        titlePanel.SetActive(false);
        actionPanel.SetActive(true);
        creditPanel.SetActive(false);
        videoPlayer.time = 44;
    }
}
