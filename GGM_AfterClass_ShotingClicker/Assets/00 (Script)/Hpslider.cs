using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpslider : MonoBehaviour
{
    public Slider HpSlider;

    public GameObject hpPrefabs;
    public GameObject _hpPrefabs;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _hpPrefabs = Instantiate(hpPrefabs, canvas.transform);
        HpSlider = _hpPrefabs.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sliderpos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x ,transform.position.y + 1f, 0));
        HpSlider.transform.position = sliderpos;
    }
}
