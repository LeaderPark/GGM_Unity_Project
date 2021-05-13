using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Cannon cannon;
    private CrateScript crate;

    public Text cannontext;
    public Text cratetext;
    public GameObject gameclear;

    private float alpha = 0f;

    void Start()
    {
        cannontext.text = "Ball : " + Cannon.ballcount;
        cratetext.text = "Crate : " + CrateScript.cratecount;
    }

    void Update() 
    {
        cannontext.text = "Ball : " + Cannon.ballcount;
        cratetext.text = "Crate : " + CrateScript.cratecount;




        if(CrateScript.cratecount == 0)
        {
            gameclear.SetActive(true);
            gameclear.GetComponent<Image>().color = new Color(176, 176, 176, alpha);
            if(alpha <= 0.6f)
            {
                alpha += 0.1f * Time.deltaTime;
            }
                
        }
    }
}
