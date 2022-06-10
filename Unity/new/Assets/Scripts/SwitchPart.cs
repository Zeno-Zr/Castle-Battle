using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SwitchPart : MonoBehaviour
{
    [SerializeField] string[] labels;
    [SerializeField] BodyParts bodyParts;
    [SerializeField] WeaponParts weaponParts;
    
    // for sprite swapping, use:
    // 
    // gameObject @@@@ = GameObject.Find("Player_armor");
    // 
    // @@@@.SwitchPart.SwapArmor(****)
    // or
    // @@@@.SwitchPart.SwapWeapon(****)
    
    // called during armor swap
    public void SwapArmor(int slot_ID)
    {
        bodyParts.SwitchParts(labels, slot_ID);        
    }

    // called during weapon swap
    public void SwapWeapon(int weaponSlot_ID)
    {
        weaponParts.SwitchWeapons(weaponSlot_ID);        
    }
}

[System.Serializable]
    public class BodyParts
    {
        [SerializeField] UnityEngine.U2D.Animation.SpriteResolver[] spriteResolver;
 
        public UnityEngine.U2D.Animation.SpriteResolver[] SpriteResolver { get => spriteResolver; }
 
        //method that are going to be triggered by the button, and it will switch the sprites of each resolver list.
        public void SwitchParts(string[] labels, int id)
        {
            id = id % labels.Length;
 
            foreach (var item in spriteResolver)
            {
                Debug.Log(item.GetCategory() + " " + labels[id] + " " + id);
                item.SetCategoryAndLabel(item.GetCategory(), labels[id]);
            }
        }
    }

[System.Serializable]
    public class WeaponParts
    {
        [SerializeField] UnityEngine.U2D.Animation.SpriteResolver[] spriteResolver;
        [SerializeField] string[] weaponLabels;
 
        public UnityEngine.U2D.Animation.SpriteResolver[] SpriteResolver { get => spriteResolver; }

        public void SwitchWeapons(int wid)
        {
            wid = wid % weaponLabels.Length;

            foreach (var item in spriteResolver)
            {
                Debug.Log(item.GetCategory() + " " + weaponLabels[wid] + " " + wid);
                item.SetCategoryAndLabel(item.GetCategory(), weaponLabels[wid]);
            }
        }
    }