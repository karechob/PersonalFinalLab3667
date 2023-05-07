using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownDisplay : MonoBehaviour
{
    public TextMeshProUGUI LevelOneDesc;
    public TextMeshProUGUI LevelTwoDesc;
    public TextMeshProUGUI LevelThreeDesc;
    

    public void DisplayRules(int optionIndex)
    {
        switch (optionIndex)
        {
            case 0:
                break;
            case 1:
                LevelOneDesc.gameObject.SetActive(true);
                LevelTwoDesc.gameObject.SetActive(false);
                LevelThreeDesc.gameObject.SetActive(false);
                break;
            case 2:
                LevelOneDesc.gameObject.SetActive(false);
                LevelTwoDesc.gameObject.SetActive(true);
                LevelThreeDesc.gameObject.SetActive(false);
                break;
            case 3:
                LevelOneDesc.gameObject.SetActive(false);
                LevelTwoDesc.gameObject.SetActive(false);
                LevelThreeDesc.gameObject.SetActive(true);
                break;
        }
    }
}