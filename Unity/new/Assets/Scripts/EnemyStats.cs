using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float enemyHealthAmount;
    public float enemyDefenceAmount;

    public float enemyMinHealth;
    public float enemyMaxHealth;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealthAmount <= enemyMinHealth)
        {
            Debug.Log("delete enemy");
            Destroy(gameObject);
        }

    }

    public void TakeDamage(float damage)
    {
        if (damage - enemyDefenceAmount > 0)
        {
            Debug.Log("damage taken");
            enemyHealthAmount -= damage - enemyDefenceAmount;
        }
        else
        {
            Debug.Log("chip damage taken");
            enemyHealthAmount -= 1;
        }
    }





}
