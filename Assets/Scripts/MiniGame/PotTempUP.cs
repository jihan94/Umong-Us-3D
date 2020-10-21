using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotTempUP : MonoBehaviour
{ 
    private float currentTemp;
    private int goalTemp;
    private int count;
    private bool isKeyDown;

    public Text currentTempTxt;
    public Text goalTempTxt;
    public Button button;
    public bool isUpButton;
    public PlayerCrtl player;

    void Start()
    {
        button = GetComponent<Button>();
        currentTemp = Random.Range(200, 250);
        goalTemp = Random.Range(320, 350);
        currentTempTxt.text = currentTemp.ToString();
        goalTempTxt.text = goalTemp.ToString();
    }

    private void Update()
    {
        if (isKeyDown == true) IncreaseTemp();
    }

    public void IncreaseTemp()
    {
        if (isUpButton) currentTemp += 0.1f;
        else currentTemp -= 0.1f;
        currentTempTxt.text = ((int)currentTemp).ToString();
        goalTempTxt.text = goalTemp.ToString();
    }

    public void IsUpButton()
    {
        isUpButton = true;
    }

    public void IsDownButton()
    {
        isUpButton = false;
    }

    public void IsKeyDown()
    {
        isKeyDown = true;
    }
    public void IsKeyUp()
    {
        isKeyDown = false;
        if((int)currentTemp == goalTemp)
        {
            gameObject.SetActive(false);
        }
    }
}
