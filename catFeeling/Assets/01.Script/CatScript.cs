using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatScript : MonoBehaviour
{

    [Header("Cup")]
    public Transform arrow;
    public bool isLookAt = false;
    public int arrowIndex = 0;

    public float timeBetChange = 0.8f;
    private float currentTime = 0;

    private Vector3 originPoint;

    [Header("Feeling")]
    public float feeling = 30;
    public Sprite[] sprites;
    public SpriteRenderer mySprite;
    [Header("Feeling Bar")]
    public Slider feelingBar;

    public Dictionary<ItemCateGory, float> itemDictionary  = new Dictionary<ItemCateGory, float>();

    private void Awake()
    {
        originPoint = arrow.position;

        arrow.gameObject.SetActive(false);

        itemDictionary.Add(ItemCateGory.CHU, 20);
        itemDictionary.Add(ItemCateGory.BEAR, -20);
        itemDictionary.Add(ItemCateGory.FISH, 10);
        itemDictionary.Add(ItemCateGory.MEAT, -10); 
    }

    private void Start()
    {
        mySprite = gameObject.GetComponent<SpriteRenderer>();
        mySprite.sprite = sprites[1];
    }

    private void Update()
    {
        if (isLookAt)
        {
            if(currentTime + timeBetChange <= Time.time)
            {
                arrowIndex = (arrowIndex + 1) % 3;
                arrow.position = originPoint + new Vector3(arrowIndex *3,0,0);
                currentTime = Time.time;

                float rTime = Random.Range(-0.3f, 0.3f);

                timeBetChange = Mathf.Clamp(timeBetChange + rTime, 0.1f, 2f);
            }

            if (Input.GetKeyDown(KeyCode.Space))
                selectCup();
        }

        feelingBar.value = feeling;
        

        if (feeling < 30)
            mySprite.sprite = sprites[0];
        else if(feeling < 70)
            mySprite.sprite = sprites[1];
        else if(feeling >= 70)
            mySprite.sprite = sprites[2];
    }

    public void selectCup()
    {
        isLookAt = false;
        GameManager.OpenCup(arrowIndex);
    }

    public void ArrowSequence()
    {
        isLookAt = true;
        currentTime = Time.time;
        arrow.gameObject.SetActive(true);
    }

    public void Give(ItemCateGory item)
    {
        switch (item)
        {
            case ItemCateGory.BEAR :
                feeling += itemDictionary[ItemCateGory.BEAR];
                GameManager.SetCatText("기분이 매우 안좋아지신 듯 하다.", 1.5f);
                break;
            case ItemCateGory.CHU :
                feeling += itemDictionary[ItemCateGory.CHU];
                GameManager.SetCatText("기분이 매우 좋아지신 듯 하다.", 1.5f);
                break;
            case ItemCateGory.FISH :
                feeling += itemDictionary[ItemCateGory.FISH];
                GameManager.SetCatText("기분이 좋아지신 듯 하다.", 1.5f);
                break;
            case ItemCateGory.MEAT :
                feeling += itemDictionary[ItemCateGory.MEAT];
                GameManager.SetCatText("기분이 안좋아지신 듯 하다.", 1.5f);
                break;
            default :
                Debug.LogError("Give swich case : Error");
                break;
        }
    }
}
