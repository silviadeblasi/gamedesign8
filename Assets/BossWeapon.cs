using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public float damage = 1;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public void Attack()
    {
        // Vector3 pos = transform.position;
        // pos += transform.right * attackOffset.x;
        // pos += transform.up * attackOffset.y;

        // Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        // if(colInfo != null)
        // {
        //     colInfo.GetComponent<PlayerHealth>().Damage(damage);
        // }
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, attackMask);
    }
}
