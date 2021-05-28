using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : MonoBehaviour
{
    public Sprite[] images;

    public Transform cupObject;

    private SpriteRenderer spriteRender;

    private Vector3 originPoint;
    private float originX;
    private ItemCateGory category;
    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        originPoint = transform.position; //처음 위치를 기억해둔다.
    }

    public void Reset()
    {
        transform.position = originPoint;
        cupObject.position = transform.position;
        gameObject.SetActive(false);
    }

    public void SetItem(ItemCateGory category)
    {
        this.category = category;
        cupObject.gameObject.SetActive(false);
        spriteRender.sprite = images[(int)category];
    }

    public void DropItem(float originX)
    {
        this.originX = originX;

        transform.DOMoveY(-3f, 1f).OnComplete(() => {
            GameManager.DropComlete();
        });
    }

    public void CupAndShake(List<int> shuffleSeq)
    {
        cupObject.Translate(new Vector3(0, 3, 0));
        cupObject.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();
        seq.Append(cupObject.DOMoveY(transform.position.y - 0.4f, 1f));
        seq.Append(cupObject.DOShakePosition(1f,0.3f));

        //시퀀스대로 움직이는 것 만들어줘
        for (int i = 0; i < shuffleSeq.Count; i++)
        {
            seq.Append(transform.DOMoveX(originX + shuffleSeq[i]*3,0.2f));
        }
        seq.AppendCallback(() => {
            GameManager.ShuffleComplete();
        });
    }
    public void Open()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(cupObject.DOShakePosition(1f, 0.3f));
        seq.Append(cupObject.DOMoveY(cupObject.position.y + 2f,0.8f));
        seq.AppendCallback(() =>
        {
            cupObject.gameObject.SetActive(false);
            GameManager.GiveItemToCat(category);
        });
    }

}
