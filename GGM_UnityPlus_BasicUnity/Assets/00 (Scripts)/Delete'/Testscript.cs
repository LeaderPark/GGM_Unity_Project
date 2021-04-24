using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testscript : MonoBehaviour
{
    void Start()
    {
        Enemy a = new EnemyFighter();
        Enemy b = new EnemyShip();

        a.Damaged(20);
        b.Damaged(20);
    }
}
