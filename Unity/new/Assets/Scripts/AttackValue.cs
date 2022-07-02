using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackValue : MonoBehaviour
{

    // public Text AttackValueText;
    public TextMeshProUGUI AttackValueText;

    public SwitchPart SwitchPart;

    public SpecialAttack specialAttack;

    public bool IsRangedWeapon;
    public string WeaponTag;
    public float attackdamage;

    public bool IsUsingSpecialAttack;
    public float TimeLimitForSpecialAttack = 0;

    public GameObject SpecialAttackAura;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsUsingSpecialAttack)
        {
            TimeLimitForSpecialAttack -= Time.deltaTime;

        }

        if (TimeLimitForSpecialAttack <= 0 && IsUsingSpecialAttack)
        {
            IsUsingSpecialAttack = false;
            ChangeAttackValue(WeaponTag);
            SpecialAttackAura.SetActive(false);
        }
        

    }

    void ChangeAttacktext(float AttackStats)
    {
        Debug.Log("changed");
        Debug.Log(AttackStats);
        AttackValueText.text = AttackStats.ToString();
        attackdamage = AttackStats;
    }

    public void ChangeAttackValue(string weaponname)
    {
        switch (weaponname)
        {
            case "Weapon_Pistol":
                ChangeAttacktext(7);
                Debug.Log("add weapon stats1");
                SwitchPart.SwapWeapon(0);
                specialAttack.ChangeMaxAmount(100);
                break;
            case "Weapon_Shotgun":
                ChangeAttacktext(13);
                Debug.Log("add weapon stats2");
                SwitchPart.SwapWeapon(1);
                specialAttack.ChangeMaxAmount(50);
                break;
            case "Weapon_Rifle":
                ChangeAttacktext(21);
                Debug.Log("add weapon stats3");
                SwitchPart.SwapWeapon(2);
                specialAttack.ChangeMaxAmount(25);
                break;
            default:
                ChangeAttacktext(0);
                SwitchPart.SwapWeapon(0);
                specialAttack.ChangeMaxAmount(0);
                break;
        }
    }

    public void SpecialAttackValue()
    {
        Debug.Log("is inside specialattackvalue");
        switch (WeaponTag)
        {
            case "Weapon_Pistol":
                ChangeAttacktext(7 + 5);
                Debug.Log("pistol");
                break;
            case "Weapon_Shotgun":
                ChangeAttacktext(13 + 9);
                Debug.Log("shot");
                break;
            case "Weapon_Rifle":
                ChangeAttacktext(21 + 13);
                Debug.Log("rifle");
                break;
            default:
                ChangeAttacktext(0);
                break;
        }

        IsUsingSpecialAttack = true;
        TimeLimitForSpecialAttack = 10;
        SpecialAttackAura.SetActive(true);



        

        

    }
}
