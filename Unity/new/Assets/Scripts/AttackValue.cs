using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackValue : MonoBehaviour
{

    // public Text AttackValueText;
    public TextMeshProUGUI AttackValueText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeAttacktext(float AttackStats)
    {
        AttackValueText.text = AttackStats.ToString();
    }

    public void ChangeAttackValue(string weaponname)
    {
        switch (weaponname)
        {
            case "Weapon_Pistol":
                ChangeAttacktext(5);
                Debug.Log("add weapon stats1");
                break;
            case "Weapon_Rifle":
                ChangeAttacktext(9);
                Debug.Log("add weapon stats2");
                break;
            default:
                ChangeAttacktext(0);
                break;
        }



    }
}
