using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishPoint : MonoBehaviour
{
    public GameObject MinlabelBest;

    public GameObject SecLabelBest;

    public GameObject MililableBest;

    public GameObject Fpoint;

    public GameObject Halpoint;


    public GameObject LapCounterLable;

    public int Lapscounter;

    void OnTriggerEnter()
    {
        Lapscounter = Lapscounter + 1;

        MililableBest.GetComponent<TMP_Text>().text = "" + LapTimerDown.mili.ToString() + ".";
        if (LapTimerDown.Sec >= 0 && LapTimerDown.Sec < 10)
        {
            SecLabelBest.GetComponent<TMP_Text>().text = "0" + LapTimerDown.Sec.ToString() + ".";
        }
        else if (LapTimerDown.Sec >= 10 && LapTimerDown.Sec <= 59)
        {
            SecLabelBest.GetComponent<TMP_Text>().text = "" + LapTimerDown.Sec.ToString() + ".";
        }

        if (LapTimerDown.min >= 0 && LapTimerDown.min < 10)
        {
            MinlabelBest.GetComponent<TMP_Text>().text = "0" + LapTimerDown.min.ToString() + ". ";
        }

        else if (LapTimerDown.min >= 10 && LapTimerDown.min <= 59)
        {
            MinlabelBest.GetComponent<TMP_Text>().text = "" + LapTimerDown.min.ToString() + ":";
        }

        LapCounterLable.GetComponent<TMP_Text>().text = "" + Lapscounter;

        LapTimerDown.mili = 0;
        LapTimerDown.Sec = 0;
        LapTimerDown.min = 0;
        Fpoint.SetActive(false);
        Halpoint.SetActive(true);
    }



}
