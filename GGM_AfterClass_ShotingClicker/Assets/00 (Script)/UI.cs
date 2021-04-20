using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text power;
    public Text levelUpCost;
    public Text level;
    private Clicker lvup;
    // private GameObject HpBar;

    private void Start() 
    {
        lvup = GameObject.Find("ClickerManager").GetComponent<Clicker>();
        //HpBar = GameObject.Find("Canvas/Slider");
        power.text = "" + DataManager.Instance.power;
        level.text = "" + DataManager.Instance.level;
        levelUpCost.text = "" + DataManager.Instance.levelUpCost;

    }

    private void Update() 
    {
        power.text = "" + DataManager.Instance.power;
        level.text = "" + DataManager.Instance.level;
        levelUpCost.text = "" + DataManager.Instance.levelUpCost;

        // HpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));
    }

    public void levelUp()
    {
        lvup.LevelUp();
    }
}

