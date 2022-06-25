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

    public SwitchPart SwitchPart;

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
                DefenceBarAdjustment(20);
                SwitchPart.SwapArmor(0);
                break;
            case "Armor_Dodge":
                Debug.Log("add armor stats2");
                DefenceBarAdjustment(45);
                SwitchPart.SwapArmor(1);
                break;
            case "Armor_Knight":
                Debug.Log("add armor stats3");
                DefenceBarAdjustment(65);
                SwitchPart.SwapArmor(2);
                break;
            case "Armor_Strong":
                Debug.Log("add armor stats4");
                DefenceBarAdjustment(80);
                SwitchPart.SwapArmor(3);
                break;

            default:
                Debug.Log("remove armor stats");
                DefenceBarAdjustment(0);
                SwitchPart.SwapArmor(0);
                break;
        }
    }

}
