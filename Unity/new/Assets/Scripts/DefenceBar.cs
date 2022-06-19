using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefenceBar : MonoBehaviour
{
    public Image defenceBar;
    public float defenceAmount = 0;
    public float minDefence = 0;
    public float maxDefence = 100;

    private void Start()
    {
        defenceAmount = Mathf.Clamp(defenceAmount, minDefence, maxDefence);
        defenceBar.fillAmount = defenceAmount / maxDefence;
    }
    private void Update()
    {
    }
    public void DefenceBarAdjustment(float defencePoints)
    {
        defenceAmount = defencePoints;
        defenceAmount = Mathf.Clamp(defenceAmount, minDefence, maxDefence);
        defenceBar.fillAmount = defenceAmount / maxDefence;
    }

    public void ArmorDefence(string armorname)
    {
        switch (armorname)
        {
            case "Armor_Basic":
                Debug.Log("add armor stats1");
                DefenceBarAdjustment(10);
                break;
            case "Armor_Dodge":
                Debug.Log("add armor stats2");
                DefenceBarAdjustment(30);
                break;
            case "Armor_Knight":
                Debug.Log("add armor stats3");
                DefenceBarAdjustment(60);
                break;
            case "Armor_Strong":
                Debug.Log("add armor stats4");
                DefenceBarAdjustment(80);
                break;

            default:
                DefenceBarAdjustment(0);
                break;
        }
    }

}
