using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Enemy : MonoBehaviour
{
    public float enemyHealthAmount;
    public float enemyDefenceAmount;

    public float enemyMinHealth;
    public float enemyMaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        if (enemyHealthAmount <= enemyMinHealth)
        {
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(float damage)
    {
        enemyHealthAmount -= damage;
        Debug.Log("damage taken");
    }
}
