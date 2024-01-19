using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("AudioManager");
                    instance = go.AddComponent<AudioManager>();
                }
            }
            return instance;
        }
    }

    [SerializeField] private AudioSource sourceWIn, source;
    public void SetVolume(float volume)
    {
        if (sourceWIn != null)
        {
            sourceWIn.volume = volume;
        }
        if (source != null)
        {
            source.volume = volume;
        }
    }

}
