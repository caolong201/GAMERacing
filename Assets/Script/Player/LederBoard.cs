using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class LederBoard : MonoBehaviour
{
    public GameObject lederboad;
    public GameObject Other;
    public GameObject Speedometer;
    public GameObject minimap;
    public GameObject couter;
    public GameObject PaneTime;
    public GameObject Pane;
    private bool playerReachedFirst = false;
    private bool aiReachedFirst = false;
    public TextMeshProUGUI[] positions;
    private bool aiReachedLast = false;
    public TextMeshProUGUI mytext;
    public TextMeshProUGUI Aitext;
    public TextMeshProUGUI Conin;
    public TextMeshProUGUI ConinAi;
    private void OnTriggerEnter(Collider other)
    {
        lederboad.SetActive(true);
        Other.SetActive(false);
        Speedometer.SetActive(false);
        minimap.SetActive(false);
        couter.SetActive(false);
        PaneTime.SetActive(false);
        Pane.SetActive(false);
        switch (other.tag)
        {
            case "Player":
                if (!aiReachedFirst)
                {
                    playerReachedFirst = true;
                    mytext.text = "ST1";
                    Aitext.text = "2nd";
                    Conin.text = "1000";
                    ConinAi.text = "0";
                }
                break;

            case "AI":
                if (!playerReachedFirst)
                {
                    aiReachedFirst = true;
                    Aitext.text = "ST1";
                    mytext.text = "2nd";
                    ConinAi.text = "1000";
                    Conin.text = "0";
                }
                break;
        }     
        }
    public void CloseLeaderboard()
    {
        lederboad.SetActive(false);

    }
}

