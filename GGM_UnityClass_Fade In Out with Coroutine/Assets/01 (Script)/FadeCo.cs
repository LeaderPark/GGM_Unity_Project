using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public enum eFadeState //소문자e는 enum을 나타냄
{
    None,
    FadeOut,
    ChangeBg,
    FadeIn,
    Done
}

public class FadeCo : MonoBehaviour
{
    eFadeState fadeState;
    
    Image imgBg;
    
    IEnumerator iStateCo = null;

    public float fadeindelaytime = 0f;
    public float fadeoutdelaytime = 0f;

    private void Awake() 
    {
        imgBg = this.gameObject.GetComponent<Image>();
        if(imgBg == null)
        {
            Debug.LogWarning("img is null");
        }
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && fadeState ==eFadeState.None)
        {
            fadeState = eFadeState.None;
            NextState();
        }
    }

    IEnumerator None()
    {
        while(fadeState == eFadeState.None)
        {
            fadeState = eFadeState.FadeOut;
            yield return null;
        }

        NextState();
    }

    IEnumerator FadeOut()
    {
        float alpha = 0f;

        while(fadeState == eFadeState.FadeOut)
        {
            if(alpha < 1)
            {
                alpha += Time.deltaTime * fadeoutdelaytime;
                //alpha -= Time.deltaTime/fadeoutdelaytime; 
            }
            else
            {
                fadeState = eFadeState.ChangeBg;
            }

            alpha = Mathf.Clamp(alpha, 0, 1);

            imgBg.color = new Color(imgBg.color.r, imgBg.color.g, imgBg.color.b, alpha);
        
            yield return null;
        }

        NextState();
    }

    IEnumerator FadeIn()
    {
        float alpha = 1f;

        while(fadeState == eFadeState.FadeIn)
        {
            if(alpha > 0)
            {
                alpha -= Time.deltaTime * fadeindelaytime; 
                //alpha += Time.deltaTime/fadeindelaytime; 
            }
            else
            {
                fadeState = eFadeState.Done;
            }

            alpha = Mathf.Clamp(alpha, 0, 1);

            imgBg.color = new Color(imgBg.color.r, imgBg.color.g, imgBg.color.b, alpha);
        
            yield return null;
        }

        NextState();
    }

    IEnumerator ChangeBg()
    {
        yield return null;

        fadeState = eFadeState.FadeIn;

        NextState();
    }

    IEnumerator Done()
    {
        yield return null;

        fadeState = eFadeState.None;
    }

    void NextState()
    {
        // 오늘 배울 하이라이트 함수 
        MethodInfo mInfo = this.GetType().GetMethod(fadeState.ToString(), BindingFlags.Instance | BindingFlags.NonPublic); // | = BindingFlags.Instance 와 BindingFlags.NonPublic 를 동시에 만족하는 함수를 불러옴
        iStateCo = (IEnumerator)mInfo  //강제 형변환
                    .Invoke(this, null);

        StartCoroutine(iStateCo);
    }
}
