using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    public double time;
    public double currentTime;
    // Use this for initialization
    public VideoPlayer VP;


    void Start() 
    { 
        //Play the video!
        VP.GetComponent<VideoPlayer>().Play();
    }

    void Update()
    {
        //Invoke repeating of checkOver method
        InvokeRepeating("checkOver", .1f, .1f);
    }

    private void checkOver()
    {

        long playerCurrentFrame = VP.GetComponent<VideoPlayer>().frame;
        long playerFrameCount = Convert.ToInt64(VP.GetComponent<VideoPlayer>().frameCount);


        //versione performante dell'algoritmo sottostante
        if (playerCurrentFrame >= playerFrameCount)
        {
            print("VIDEO IS OVER");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
            CancelInvoke("checkOver");
        }

        /*
        if (playerCurrentFrame < playerFrameCount)
        {
            //print("VIDEO IS PLAYING");
        }
        else
        {
            print("VIDEO IS OVER");
            //Do w.e you want to do for when the video is done playing.
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
            //Cancel Invoke since video is no longer playing
            CancelInvoke("checkOver");
        }*/
    }
}