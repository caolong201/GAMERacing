using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfiDistanceTrigger : MonoBehaviour
{
    public GameObject HaifPoint;
    public GameObject FinishPoint;

    void OnTriggerEnter ()
    {
        HaifPoint.SetActive (false);
        FinishPoint.SetActive (true);
        
    }
}
