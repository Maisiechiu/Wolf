using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayEnding : MonoBehaviour
{
    public static bool play_ending = false;
    public static bool finish_ending = false;
    VideoPlayer myvideo = new VideoPlayer();
    // Start is called before the first frame update
    void Start()
    {
        myvideo = GetComponent<VideoPlayer>();
        myvideo.playOnAwake = false;
        myvideo.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer myvideo)
    {
        finish_ending = true;
        Debug.Log("finish playing");
        play_ending = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(play_ending && !myvideo.isPlaying)
        {
            myvideo.Play();
            
        }
    }
}
