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

    [Header("아이템 드랍관련")]
    public Transform dropPoints;
    public Item[] dropItems;
    public int dropcount = 0;
    public int dropCompletCount = 0;
    public int shuffleCount = 0;

    public Item[] shuffledItems; //섞인게 순서대로 들어갈 배열

    [Header("외부 게임 오브젝트 관리")]
    public ItemPanel itemPanel;
    public int[] count = new int[4];

    [Header("고양이 관련")]
    public CatScript cat;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        shuffledItems = new Item[3];

    }
    private void Start()
    {
        GameManager.SetMsgText("게임 시작 버튼을 눌러 게임을 시작하세요",2f);
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
            GameManager.SetMsgText("이미 최대갯수만큼 드랍했어요", 2f);
            return;
        }

        Debug.Log(itemcategory);
        if (count[itemcategory] <= 0)
        {
            GameManager.SetMsgText("해당 아이템은 모두 소진했어요",2f);
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
            GameManager.SetMsgText("아이템을 3개 드롭후 실행 가능합니다.",1.5f);
            return;
        }
        btnShuffle.interactable = false;//사용 버튼 잠궈주고
        List<int>[] lists = new List<int>[3];
        for (int i = 0; i < lists.Length; i++)
        {
            lists[i] = new List<int>();
        }
        for (int i = 0; i < 8; i++)
        {
            //각 한번마다 0,1,2를 겹치지 않게 lists[0,1,2]번째에 Add 해주면 돼.
            //제자리에 가만 있으면 안되니까 현재있는 위치하고는 다르게
            List<int> locList = new List<int> { 0, 1, 2 };

            for (int j = 0; j < lists.Length; j++)
            {
                if (i == 0)
                {
                    lists[j].Add(j); //처음에는 시작위치 그대로 넣고
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
            shuffledItems[idx] = dropItems[i]; //i번째 아이템이 만약 2번이 마지막위치라면
            //셔플드아이템의 2번위체에 ㅑ번째 아이템을 넣어둔다.

        }

        for (int i = 0; i < lists.Length; i++)
            dropItems[i].CupAndShake(lists[i]);
    }
    public static void DropComlete()
    {
        instance.dropCompletCount++;
        if(instance.dropCompletCount >= 3)
        {
            instance.btnShuffle.interactable = true;
        }
    }

    public static void ShuffleComplete()
    {
        instance.shuffleCount++;
        if(instance.shuffleCount >= 3)
        {
            instance.cat.ArrowSequence();
        }
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
