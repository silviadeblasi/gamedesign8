using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform projPos;
    private float timer;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 5)
        {
            timer += Time.deltaTime;

            if(timer > 2)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(projectile, projPos.position, projPos.rotation);
    }
}
