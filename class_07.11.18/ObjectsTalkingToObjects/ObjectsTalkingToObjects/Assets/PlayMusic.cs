using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour {

    public AudioSource myaudio;
    public bool toggle;
    // Use this for initialization
    void Start()
    {
        myaudio = this.gameObject.GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {
        if(toggle == true)
        {
            myaudio.Play();
        }
        else
        {
            myaudio.Stop();
        }
    }
}
