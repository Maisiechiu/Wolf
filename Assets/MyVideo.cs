using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MyVideo : Menu
{
    // Start is called before the first frame update
    public static bool play = false;
    public static bool finish = false;
    VideoPlayer myvideo = new VideoPlayer();
    void Start()
    {
        myvideo = GetComponent<VideoPlayer>();
        myvideo.playOnAwake = false;
        myvideo.loopPointReached += EndReached;

    }
    void EndReached(UnityEngine.Video.VideoPlayer myvideo)
    {
        finish = true;
        Debug.Log("finish playing");
        play = false;
        clickLoadButton();
    }

    // Update is called once per frame
    void Update()
    {
        if(play && !myvideo.isPlaying)
        {
            myvideo.Play();
            
        }
    }

}
