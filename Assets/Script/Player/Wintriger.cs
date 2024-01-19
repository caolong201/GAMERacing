using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Wintriger : MonoBehaviour
{
    public class SceneName
    {
        public const string Map1 = "map2";
        public const string Main = "main";
    }
    public void NextGame()
    {
        SceneManager.LoadScene("Map2");
    }
    public void main()
    {
        SceneManager.LoadScene("Main");
    }
}
