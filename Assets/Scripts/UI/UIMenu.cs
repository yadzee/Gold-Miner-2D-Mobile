using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    private GameObject _levelSheet;
    void Start()
    {
        _levelSheet = GameObject.Find("Levels Sheet");
        {
            if (_levelSheet != null)
            {
                _levelSheet.SetActive(false);
            }
        }

    }

    public void SetActiveSheet()
    {
        _levelSheet.SetActive(true);
    }
}
