using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main_menu : MonoBehaviour
{
    CarsSelection myCar;
    public GameObject Closewher;
    public GameObject SettingSmoke;
    public GameObject smokeColorLif;
    public GameObject smokeColoRight;
    public GameObject Grea;
    public GameObject CloseVolum;
    public GameObject Carstt;
    public GameObject Lv;
    public AudioSource SoudGrea;
    public AudioSource Soudsmoke;
    public AudioSource SoudSetting;
    public AudioSource SoudClos;
    [SerializeField] private Slider volumeSlider;
    public AudioSource SoundGame;


    public void Start()
    {
        SoundGame.Play();
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }
    private void OnVolumeSliderChanged(float value)
    {
        AudioManager.Instance.SetVolume(value);
    }
    public void SelecTrack()
    {
        Lv.SetActive(true);
        Carstt.SetActive(false);
    }
    public void Volums()
    {
        CloseVolum.SetActive(false);
    }
    public void Greas()
    {
        SoudGrea.Play();
        Grea.SetActive(true);
    }
    public void Smokes()
    {
        Soudsmoke.Play();
        smokeColorLif.SetActive(true);
        smokeColoRight.SetActive(true);

    }
    public void STsmockWheel()
    {
        SoudSetting.Play();
        SettingSmoke.SetActive(true);
      
    }
    
    public void Close()
    {
        SoudClos.Play();
        Closewher.SetActive(false);
    }
 
}
