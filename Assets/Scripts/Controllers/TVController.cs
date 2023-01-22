using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TVController : MonoBehaviour
{
    public GameObject backgroundVideoPlayer;
    public GameObject tvVideoPlayer;

    public Canvas infoCanvas;
    public Canvas tvCanvas;

    public AudioSource audioClickButton;

    public void OnClickShowTVPanel()
    {
        audioClickButton.Play();

        infoCanvas.gameObject.SetActive(false);
        backgroundVideoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().Stop();

        tvCanvas.gameObject.SetActive(true);
        tvVideoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().Play();
    }

    public void OnClickCloseTVPanel()
    {
        audioClickButton.Play();

        tvCanvas.gameObject.SetActive(false);
        tvVideoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().Stop();

        infoCanvas.gameObject.SetActive(true);
        backgroundVideoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().Play();   
    }

}
