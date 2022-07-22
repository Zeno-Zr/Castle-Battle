using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource click;
    public AudioSource chargeActivate;
    public AudioSource chargeDeactivate;
    public AudioSource attacking;
    public AudioSource takingDamage;
    public AudioSource bossExplode;

    private void Start()
    {
        click = GameObject.Find("Click").GetComponent<AudioSource>();
        chargeActivate = GameObject.Find("Charge Activate").GetComponent<AudioSource>();
        chargeDeactivate = GameObject.Find("Charge Deactivate").GetComponent<AudioSource>();
        attacking = GameObject.Find("Attacking").GetComponent<AudioSource>();
        takingDamage = GameObject.Find("Taking Damage").GetComponent<AudioSource>();
        bossExplode = GameObject.Find("Boss Explode").GetComponent<AudioSource>();
        
    }


    public void Click()
    {
        click.PlayOneShot(click.clip);
    }

    public void ChargeActivate()
    {
        chargeActivate.PlayOneShot(chargeActivate.clip);
    }

    public void ChargeDeactivate()
    {
        chargeDeactivate.PlayOneShot(chargeDeactivate.clip);
    }

    public void Attacking()
    {
        attacking.PlayOneShot(attacking.clip);
    }

    public void TakingDamage()
    {
        takingDamage.PlayOneShot(takingDamage.clip);
    }

    public void BossExplode()
    {
        bossExplode.PlayOneShot(bossExplode.clip);
    }
}
