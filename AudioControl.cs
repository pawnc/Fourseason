using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public bool Pause;

    public AudioSource Audio;

    public Slider volume;

    // Start is called before the first frame update
    void Start()
    {
        Pause = PauseMenu.GameIsPause;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Pause)
        {
            Audio.Pause();
        }
        else
        {
            Audio.UnPause();
        }
        VolumeControl();



    }
    void VolumeControl()
    {
        Audio.volume = volume.value;
    }
}
