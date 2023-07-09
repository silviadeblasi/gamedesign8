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
    public float damage;
    public Vector3 attackOffset;
    public Vector3 upAttackOffset;
    public Vector3 downAttackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;
        float amountToDamage = damage;

        // Attacco verso destra
        Vector3 rightAttackPos = pos + transform.right * attackOffset.x;
        Collider2D rightColInfo = Physics2D.OverlapCircle(rightAttackPos, attackRange, attackMask);
        if (rightColInfo != null)
        {
            rightColInfo.GetComponent<PlayerHealth>().Damage(amountToDamage);
        }

        // Attacco verso sinistra
        Vector3 leftAttackPos = pos - transform.right * attackOffset.x;
        Collider2D leftColInfo = Physics2D.OverlapCircle(leftAttackPos, attackRange, attackMask);
        if (leftColInfo != null)
        {
            leftColInfo.GetComponent<PlayerHealth>().Damage(amountToDamage);
        }

        // Attacco verso l'alto
        Vector3 upAttackPos = pos + transform.up * upAttackOffset.y;
        Collider2D upColInfo = Physics2D.OverlapCircle(upAttackPos, attackRange, attackMask);
        if (upColInfo != null)
        {
            upColInfo.GetComponent<PlayerHealth>().Damage(amountToDamage);
        }

        // Attacco verso il basso
        Vector3 downAttackPos = pos - transform.up * downAttackOffset.y;
        Collider2D downColInfo = Physics2D.OverlapCircle(downAttackPos, attackRange, attackMask);
        if (downColInfo != null)
        {
            downColInfo.GetComponent<PlayerHealth>().Damage(amountToDamage);
        }
    }
}
