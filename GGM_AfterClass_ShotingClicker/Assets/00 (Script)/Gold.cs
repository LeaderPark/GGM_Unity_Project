using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using System;

public class Gold : MonoBehaviour
{
    public Text Goldtext01;

    private void Start() 
    {
        Goldtext01.text = DataManager.Instance.GetGoldText(DataManager.Instance.gold);
    }

    private void Update()
    {
        IncreaseGold();
    }

    public void IncreaseGold()
    {
        Goldtext01.text = DataManager.Instance.GetGoldText(DataManager.Instance.gold);
    }
}

    

    