using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using System; //Serializable
using System.IO; // File  Input / Output

[SerializeField]
public class PlayerData
{
    public int clickerLevel;
    public int stageLevel;
    public string gold; // Big Integer 형식은 string으로 저장

    public void GetData()
    {
        DataManager.Instance.level = clickerLevel;
        DataManager.Instance.stageLvCount = stageLevel;
        DataManager.Instance.gold = BigInteger.Parse(gold);
 
        //이렇게 데이터 접근해서 실제 데이터 매니저에서 가져오기 
    }
}

public class DataManager : MonoBehaviour
{
    public BigInteger gold = 1;

    public int stageLvCount = 1;
    public int totalEnemy = 0;
    public int enemykillcount = 0;
    public int enemymax = 8;
    public int enemyHp;
    public int killReward;
    public int power = 1;

    public float level = 1f;
    public float levelUpCost = 1f;

    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<DataManager>();
                if (obj != null)
                {
                    instance = obj;

                }
                else
                {
                    var newSingleton = new GameObject("Singleton Class").AddComponent<DataManager>();
                    instance = newSingleton;
                }
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        var objs = FindObjectsOfType<DataManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public string GetGoldText(BigInteger _Data) //돈 변환 코드
    {
        string gText = string.Empty;

        gText = _Data.ToString();

        switch (gText.Length)
        {
            case 1:
            case 2:
            case 3:
                break;
            case 4:
            case 5:
            case 6:
                gText = gText.Remove(gText.Length - 3, 3);
                gText += 'k';
                break;
            case 7:
            case 8:
            case 9:
                gText = gText.Remove(gText.Length - 6, 6);
                gText += 'M';
                break;
            case 10:
            case 11:
            case 12:
                gText = gText.Remove(gText.Length - 9, 9);
                gText += 'B';
                break;
            case 13:
            case 14:
            case 15:
                gText = gText.Remove(gText.Length - 12, 12);
                gText += 'T';
                break;
            default:
                gText = string.Format("{0}.{1}{2}E + {3}", gText[0], gText[1], gText[2], gText.Length - 1);
                break;
        }
        return gText;
    }

    public void SaveData() //데이터 저장
    {
        PlayerData myData = new PlayerData();
        myData.clickerLevel = (int)level;
        myData.stageLevel = stageLvCount;
        myData.gold = gold.ToString();

        string str = JsonUtility.ToJson(myData);

        Debug.Log(str); //로그 찍어보기 

        File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", JsonUtility.ToJson(myData));
        PlayerData data2 = JsonUtility.FromJson<PlayerData>(JsonUtility.ToJson(myData)); // 데이터 로드
        data2.GetData();
    }
    
}
