using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotMiniGame : MonoBehaviour
{
    public Text goalTemp;
    public Text currentTemp;
    public Button upButton; 
    public Button downButton; 

    void Start()
    {
        goalTemp = GetComponent<Text>();
        currentTemp = GetComponent<Text>();
        upButton = GetComponent<Button>();
        downButton = GetComponent<Button>();
    }

    void Update()
    {
        

    }
}
