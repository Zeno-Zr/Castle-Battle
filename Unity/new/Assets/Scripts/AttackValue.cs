using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackValue : MonoBehaviour
{

    // public Text AttackValueText;
    public TextMeshProUGUI AttackValueText;

    public SwitchPart SwitchPart;

    public bool IsRangedWeapon;
    public string WeaponTag;
    public float attackdamage; 

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
        attackdamage = AttackStats;
    }

    public void ChangeAttackValue(string weaponname)
    {
        switch (weaponname)
        {
            case "Weapon_Pistol":
                ChangeAttacktext(5);
                Debug.Log("add weapon stats1");
                SwitchPart.SwapWeapon(0);
                break;
            case "Weapon_Shotgun":
                ChangeAttacktext(9);
                Debug.Log("add weapon stats2");
                SwitchPart.SwapWeapon(1);
                break;
            case "Weapon_Rifle":
                ChangeAttacktext(13);
                Debug.Log("add weapon stats3");
                SwitchPart.SwapWeapon(2);
                break;
            default:
                ChangeAttacktext(0);
                SwitchPart.SwapWeapon(0);
                break;
        }
    }
}
