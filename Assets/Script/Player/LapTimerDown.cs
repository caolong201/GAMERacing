using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LapTimerDown : MonoBehaviour
{
    public GameObject MiliLabel;
    public GameObject SecondLabel;
    public GameObject MinLabel;
    public static int min;
    public static int Sec;
    public static float mili;
    void Update()
    {
        mili = mili + Time.deltaTime * 10;
        MiliLabel.GetComponent<TMP_Text>().text = "" + mili.ToString("F0");

        if (mili > 9)
        {
            Sec = Sec + 1;
            mili = 0;
        }
        if (Sec >= 0 && Sec < 10)
        {
            SecondLabel.GetComponent<TMP_Text>().text = "0" + Sec.ToString() + ".";

        }
        else if (Sec >= 10 && Sec <= 59)
        {
            SecondLabel.GetComponent<TMP_Text>().text = "" + Sec.ToString() + ".";
        }
        else if (Sec == 60)
        {
            Sec = 0;
            min = min + 1;
        }

        if (min >= 0 && min < 10)
        {
            MinLabel.GetComponent<TMP_Text>().text = "0" + min.ToString() + ".";

        }
        else if (min >= 10 && min <= 59)
        {
            MinLabel.GetComponent<TMP_Text>().text = "" + min.ToString() + ".";
     
        }
    }


}
