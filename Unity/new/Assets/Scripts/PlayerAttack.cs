using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private bool IsPlayerAttacking = false;

    private float timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack = 0.3f;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    [SerializeField] private float attackRange;
    //public int damage;

    public AttackValue attackValue; // checks IsMeleeWeapon from here

    public GameObject projectile;
    public Transform shotPoint;
    public bool isLeft = true;


    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (IsPlayerAttacking)
            {
                if (!attackValue.IsRangedWeapon)
                {
                    Debug.Log("working melee");
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<EnemyStats>().TakeDamage(); // deduct health from enemy
                        Debug.Log("aa");
                    }
                }
                else if (attackValue.IsRangedWeapon)
                {
                    
                    Debug.Log("working ranged");
                    if (isLeft)
                    {
                        shotPoint.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                        Instantiate(projectile, shotPoint.position, shotPoint.rotation);
                    }
                    else if (!isLeft)
                    {
                        shotPoint.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f));
                        Instantiate(projectile, shotPoint.position, shotPoint.rotation);
                    }

                }

                timeBtwAttack = startTimeBtwAttack;
            }

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }


    }
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("player is attacking!");

            IsPlayerAttacking = true;
        }

        if (context.canceled)
        {
            Debug.Log("player stopped attacking!");
            IsPlayerAttacking = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }


}
