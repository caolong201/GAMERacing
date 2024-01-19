using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class CarsSelection : MonoBehaviour
{
    public AudioSource SoudClick;

    public GameObject[] Car;
    public Button Next;
    public Button Previous;
    public TextMeshProUGUI displayText;
  
    int index;
    public class SceneName
    {
        public const string Map1 = "Map1";
    }
    void Start()
    {
        UpdateCarDisplay();
        index = PlayerPrefs.GetInt("CarIndex");
        for (int i = 0; i < Car.Length; i++)
        {
            Car[i].SetActive(false);
            Car[index].SetActive(true);
            displayText.text = Car[index].name;
        }     
    }

    void UpdateCarDisplay()
    {
        for (int i = 0; i < Car.Length; i++)
        {
            Car[i].SetActive(false);
        }
        Car[index].SetActive(true);
        displayText.text = "Car" + (index + 1).ToString();
    }
    void Update()
    {
        if (index >= 2)
        {
            Next.interactable = false;
        }
        else
        {
            Next.interactable = true;
        }
        if (index <= 0)
        {
            Previous.interactable = false;
        }
        else
        {
            Previous.interactable = true;
        }
        Next.interactable = index < Car.Length - 1;
        Previous.interactable = index > 0;
    }
    public void Nexts()
    {
        SoudClick.Play();
        index++;
        if (index >= Car.Length)
        {
            index = 0;
        }
        UpdateCarDisplay();
        PlayerPrefs.SetInt("CarIndex", index);
        PlayerPrefs.Save();
    }
    public void Previouss()
    {
        SoudClick.Play();
        index--;
        if (index < 0)
        {
            index = Car.Length - 1;
        }
        UpdateCarDisplay();
        PlayerPrefs.SetInt("CarIndex", index);
        PlayerPrefs.Save();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Map1");
    }
}
