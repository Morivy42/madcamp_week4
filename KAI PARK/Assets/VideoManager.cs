using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    VideoPlayer videoPlayer;
    public bool isChanged;
    public VideoClip[] videoClips;
    int indexNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        indexNum = 0;
        videoPlayer = GetComponent<VideoPlayer>();
        SetVideo();
    }

    public void SetVideo()
    {
        if (isChanged)
        {
            videoPlayer.clip = videoClips[indexNum];
            videoPlayer.Play();
            isChanged = false;
        }
    }

    public IEnumerator FadeIn()
    {
        isChanged = false;
        while (videoPlayer.targetCameraAlpha < 0.99f)
        {
            videoPlayer.targetCameraAlpha += 0.025f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator FadeOut()
    {
        while (videoPlayer.targetCameraAlpha > 0.01f)
        {
            videoPlayer.targetCameraAlpha -= 0.025f;
            yield return new WaitForSeconds(0.01f);
        }
        isChanged = true;
    }
}
