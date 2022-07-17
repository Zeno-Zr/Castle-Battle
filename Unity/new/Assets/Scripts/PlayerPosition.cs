using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private GameMaster gm;
    public GameObject mainCamera;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        //check if it's next level or the same level (maybe use portal as a way to do so)
        transform.position = gm.lastCheckPointPos;
        mainCamera.GetComponent<CameraMovement>().transform.position = gm.lastCheckPointPos;

        //check the two strings
        FindObjectOfType<PlayerAttributes>().LoadPlayer();
        string weaponTag = FindObjectOfType<PlayerAttributes>().weaponTag;
        string armorTag = FindObjectOfType<PlayerAttributes>().armorTag;

        //check battery
        if (FindObjectOfType<PlayerAttributes>().hasBattery)
        {
            FindObjectOfType<PlayerInteraction>().battery = FindObjectOfType<PlayerAttributes>().hasBattery;
            GameObject battery = GameObject.FindGameObjectWithTag("Battery");
            battery.SetActive(false);
        }

        GameObject weaponEquipped;
        GameObject armorEquipped;

        if (!string.IsNullOrEmpty(weaponTag))
        {
            weaponEquipped = GameObject.FindWithTag(weaponTag);
            weaponEquipped.transform.position = FindObjectOfType<WeaponSlot>().gameObject.transform.position;
        }

        if (!string.IsNullOrEmpty(armorTag))
        {
            armorEquipped = GameObject.FindWithTag(armorTag);
            armorEquipped.transform.position = FindObjectOfType<ArmorSlot>().gameObject.transform.position;
        }

    }
}


