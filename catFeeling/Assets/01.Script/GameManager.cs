using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public enum ItemCateGory
{
    CHU,
    BEAR,
    FISH,
    MEAT
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text catStatusText;
    public Text msgText;


    public Button btnStart;
    public Button btnShuffle;

    private AudioSource audioSource;

    [Header("������ �������")]
    public Transform dropPoints;
    public Item[] dropItems;
    public int dropcount = 0;
    public int dropCompletCount = 0;
    public int shuffleCount = 0;

    public Item[] shuffledItems; //���ΰ� ������� �� �迭

    [Header("�ܺ� ���� ������Ʈ ����")]
    public ItemPanel itemPanel;
    public int[] count = new int[4];

    [Header("������ ����")]
    public CatScript cat;

    private void Awake()
    {
        instance = this;

        audioSource = GetComponent<AudioSource>();
        shuffledItems = new Item[3];

    }
    private void Start()
    {
        GameManager.SetMsgText("게임 시작버튼을 눌러 시작하세요",2f);

        dropItems = dropPoints.GetComponentsInChildren<Item>();
        foreach (Item i in dropItems)
        {
            i.gameObject.SetActive(false);
        }
    }

    public void GameStart()
    {
        GameManager.SetMsgText("먹이 3개를 선택하세요",2f);
        btnStart.interactable = false;
        for (int i = 0; i < count.Length; i++)
        {
            count[i] = 6;
        }
        itemPanel.SetItemText(count);
    }

    public void DropItem(int itemcategory)
    {
        if(dropcount >= 3)
        {
            GameManager.SetMsgText("이미 최대갯수만큼 드랍했어요" , 2f);
            return;
        }

        Debug.Log(itemcategory);
        if (count[itemcategory] <= 0)
        {
            GameManager.SetMsgText("해당 아이템은 모두 소진했어요", 2f);
            return;
        }

        Item item = dropItems[dropcount];
        item.gameObject.SetActive(true);

        item.SetItem((ItemCateGory)itemcategory);
        item.DropItem(dropPoints.position.x);
        dropcount++;
        count[(int)itemcategory]--;

        itemPanel.RefreshItemCount(count);
    }

    public static void SetMsgText(string text,float time)
    {
        instance.catStatusText.DOKill();
        instance.audioSource.Stop();

        instance.msgText.DOKill();
        instance.audioSource.Stop();
        instance.msgText.text = "";
        instance.audioSource.Play();
        instance.msgText.DOText(text, time).OnComplete(()=> {
        instance.audioSource.Stop();
        });
    }

    public static void SetCatText(string text,float time)
    {
        instance.catStatusText.DOKill();
        instance.audioSource.Stop();


        instance.catStatusText.text = "";
        instance.audioSource.Play();
        instance.catStatusText.DOText(text, time).OnComplete(() => {
            instance.audioSource.Stop();
        });
    }
    public void Shuffle()
    {
        if(dropcount < 3)
        {
            GameManager.SetMsgText("아이템을 3개 드롭후 실행가능합니다.",1.5f);
            return;
        }

        btnShuffle.interactable = false;
        List<int>[] lists = new List<int>[3];
        for (int i = 0; i < lists.Length; i++)
        {
            lists[i] = new List<int>();
        }
        for (int i = 0; i < 8; i++)
        {
            List<int> locList = new List<int> { 0, 1, 2 };

            for (int j = 0; j < lists.Length; j++)
            {
                if (i == 0)
                {
                    lists[j].Add(j); 
                }
                else
                {
                    List<int> clone = locList.ToList();
                    if (clone.Count > 1)
                        clone.Remove(lists[j][lists[j].Count - 1]);

                    int idx = Random.Range(0, clone.Count); // 0,2
                    lists[j].Add(clone[idx]);

                    locList.Remove(clone[idx]);
                }
            }
        }

        for (int i = 0; i < lists.Length; i++)
        {
            int idx = lists[i].Last();
            shuffledItems[idx] = dropItems[i]; 
        }

        for (int i = 0; i < lists.Length; i++)
            dropItems[i].CupAndShake(lists[i]);
    }
    public static void DropComlete()
    {
        instance.dropCompletCount++;

        if(instance.dropCompletCount >= 3)
            instance.btnShuffle.interactable = true;
    }

    public static void ShuffleComplete()
    {
        instance.shuffleCount++;

        if(instance.shuffleCount >= 3)
            instance.cat.ArrowSequence();
    }
    public static void OpenCup(int idx)
    {
        instance.shuffledItems[idx].Open();
    }

    public static void GiveItemToCat(ItemCateGory item)
    {
        instance.cat.Give(item);
    }
}
