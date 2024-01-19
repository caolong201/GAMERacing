using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Sound;
    public AudioSource GosSound;
    void Start()
    {
        GosSound.Play();
        Sound.Play();
    }
}
