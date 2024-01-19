using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    float CurenntTime = 0f;
    public float StartTime = 250f;
    public TMP_Text CoutDownText ;
    public GameObject GameOver;
    //public GameObject Win;

     void Start()
    {
        CurenntTime = StartTime;
    }
  
    void Update()
    {
        CurenntTime-= 1 * Time.deltaTime;
        CoutDownText.text = "Remaing Time:" +CurenntTime.ToString();
       if( CurenntTime <= 0f)
        {
            CurenntTime = 0;
            GameOver.SetActive(true);
            Time.timeScale = 0f;
        }
          
    }
}
