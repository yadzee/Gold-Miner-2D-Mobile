using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCatchUI : MonoBehaviour
{
    public Image _image { get; set; }

    public Animation _animation { get; set; }

    private void Awake()
    {
        _image = GameObject.Find("ItemCatchUI").GetComponent<Image>();
        _animation = GameObject.Find("ItemCatchUI").GetComponent<Animation>();
    }
}
