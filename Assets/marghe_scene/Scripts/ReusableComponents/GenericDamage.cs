using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GenericDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private string otherTag; //We are using a tag to identify the object we want to damage

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "enemy")
        {
           EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
           BossHealth bossHealth = other.GetComponent<BossHealth>();
            if(enemyHealth)
            {
                enemyHealth.Damage(damage);
            }
            else if(bossHealth)
            {
                bossHealth.Damage(damage);
            }
        }
        else if (other.gameObject.CompareTag(otherTag) && other.isTrigger) 
        {
            GenericHealth temp = other.GetComponent<GenericHealth>();
            if (temp)
            {
                temp.Damage(damage);
            }
        }
    }
}
