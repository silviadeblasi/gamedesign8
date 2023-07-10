// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BossWeapon : MonoBehaviour
// {
//     public float damage;
//     public Vector3 attackOffset;
//     public Vector3 rightAttackOffset;
//     public Vector3 leftAttackOffset;
//     public Vector3 upAttackOffset;
//     public Vector3 downAttackOffset;
//     public float attackRange = 1f;
//     public LayerMask attackMask;

//     public void Attack()
//     {
//         Vector3 pos = transform.position;
//         pos += transform.right * attackOffset.x;
//         pos += transform.up * attackOffset.y;

//         Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
//         if(colInfo != null)
//         {
//             colInfo.GetComponent<PlayerHealth>().Damage(damage);
//         }
//         Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, attackMask);
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public float damage = 1;
    public float enragedDamage = 2;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(colInfo != null)
        {
            if(GetComponent<Animator>().GetBool("isEnraged"))
            {
                colInfo.GetComponent<PlayerHealth>().Damage(enragedDamage);
            }
            else
            {
                colInfo.GetComponent<PlayerHealth>().Damage(damage);
            }
        }
    }
}
