using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatScript : MonoBehaviour
{

    [Header("고양이 화살표 관련 로직")]
    public Transform arrow;
    public bool isLookAt = false;
    public int arrowIndex = 0;

    public float timeBetChange = 0.8f;
    private float currentTime = 0;

    private Vector3 originPoint;

    [Header("기부니")]
    public float feeling = 30;
    public Sprite[] sprites;
    public SpriteRenderer mySprite;
    [Header("고양이의 상태가 바뀜")]
    public Image feelImg;
    public Text feelTex;

    public Dictionary<ItemCateGory, float> itemDictionary  = new Dictionary<ItemCateGory, float>();

    private void Awake()
    {
        originPoint = arrow.position; //처음 시작할때 화살표의 첫위치를 저장해둔다.
        arrow.gameObject.SetActive(false);
        itemDictionary.Add(ItemCateGory.CHU, 20);
        itemDictionary.Add(ItemCateGory.BEAR, -20);
        itemDictionary.Add(ItemCateGory.FISH, 10);
        itemDictionary.Add(ItemCateGory.MEAT, -10); 
    }
    private void Start()
    {
        mySprite = gameObject.GetComponent<SpriteRenderer>();
        mySprite.sprite = sprites[0];
    }

    public void ArrowSequence()
    {
        isLookAt = true;
        currentTime = Time.time;
        arrow.gameObject.SetActive(true);
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

                timeBetChange = Mathf.Clamp(timeBetChange +rTime, 0.1f, 2f);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StopLookAt();
            }
        }
        feelImg.fillAmount = Mathf.Clamp(feeling / 100,0,10);
    }

    public void StopLookAt()
    {
        isLookAt = false;
        GameManager.OpenCup(arrowIndex);
    }
    public void Give(ItemCateGory item)
    {
        switch (item)
        {
            case ItemCateGory.BEAR :
                feeling += itemDictionary[ItemCateGory.BEAR];
                break;
            case ItemCateGory.CHU :
                feeling += itemDictionary[ItemCateGory.CHU];
                break;
            case ItemCateGory.FISH:
                feeling += itemDictionary[ItemCateGory.FISH];
                break;
            case ItemCateGory.MEAT:
                feeling += itemDictionary[ItemCateGory.MEAT];
                break;
        }
        if (feeling > 80)
            mySprite.sprite = sprites[1];
        else if(feeling > 40&&feeling < 79)
            mySprite.sprite = sprites[0];
        else if(feeling < 40)
            mySprite.sprite = sprites[2];
    }
}
