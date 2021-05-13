using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private void Update() 
    {
        if(DataManager.Instance.enemykillcount >= DataManager.Instance.enemymax)
        {
            DataManager.Instance.enemykillcount = 0;
            DataManager.Instance.totalEnemy = 0;
            DataManager.Instance.stageLvCount++;
        }
    }
}
