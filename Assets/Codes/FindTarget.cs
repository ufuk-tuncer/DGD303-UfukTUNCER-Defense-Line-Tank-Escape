using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTarget : MonoBehaviour
{
    [SerializeField] Transform barrel;
    [SerializeField] ParticleSystem projectileParicles;
    [SerializeField] float range = 1f;
    Transform enemy;

    void Update()
    {
        FindClosest();
        BarrelAiming();
    }

    void FindClosest()
    {
        Target[] enemies = FindObjectsOfType<Target>();
        Transform closestEnemy = null;
        float maxDistance = Mathf.Infinity;

        foreach (Target target in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, target.transform.position);

            if (enemyDistance < maxDistance )
            {
                closestEnemy = target.transform;
                maxDistance = enemyDistance;
            }
        }
        enemy = closestEnemy;
    }

    void BarrelAiming()
    {
        float enemyDistance = Vector3.Distance(transform.position, enemy.position);
        barrel.LookAt(enemy);

        if (enemyDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emissionComponent = projectileParicles.emission;
        emissionComponent.enabled = isActive;
    }
}
