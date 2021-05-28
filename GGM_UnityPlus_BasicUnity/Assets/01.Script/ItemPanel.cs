using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour
{
    public Text[] countTex; // 몇개씩있는지
    public Button[] buttons;

    public void RefreshItemCount(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            countTex[i].text = $"{arr[i]}개";
        }
    }
    public void SetItemText(int[] arr)
    {
        RefreshItemCount(arr);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
