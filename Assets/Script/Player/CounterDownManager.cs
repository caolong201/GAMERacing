using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CounterDownManager : MonoBehaviour
{
    public GameObject CounterLable;
   
    public GameObject LapTimer;
    public GameObject AiCar,AiCar01,AiCar02;

    void Start()
    {
        StartCoroutine(CountDown());
       
    }
    IEnumerator CountDown ()
    {     
        yield return new WaitForSeconds(0.03f);
        CounterLable.GetComponent<TMP_Text>().text = "3";
        CounterLable.SetActive(true);
        yield return new WaitForSeconds(1);
        CounterLable.SetActive(false);
        CounterLable.GetComponent<TMP_Text>().text = "2";
        CounterLable.SetActive(true);
        yield return new WaitForSeconds(1);
        CounterLable.SetActive(false);
        CounterLable.GetComponent<TMP_Text>().text = "1";
        CounterLable.SetActive(true);
        yield return new WaitForSeconds(1);
        CounterLable.SetActive(false);
        AiCar.GetComponent<AiCarController>().enabled = true;
        AiCar01.GetComponent<AiCarController>().enabled=true;
        AiCar02.GetComponent<AiCarController>().enabled=(true);
        LapTimer.GetComponent<LapTimerDown>().enabled = true;
    }
    
}
