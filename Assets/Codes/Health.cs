using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHit = 10;
    int currentHit = 0;

    [Tooltip("Increases maxHit when the enemy dies.")]
    [SerializeField] int difficultyIncrease = 1;

    Target target;
    void OnEnable()
    {
        currentHit = maxHit;
    }

    void Start() 
    {
        target = GetComponent<Target>();
    }

    void OnParticleCollision(GameObject other)
    {
        HitProcedure();
    }

    void HitProcedure()
    {
        currentHit--;

        if (currentHit <= 0)
        {
            gameObject.SetActive(false);
            maxHit += difficultyIncrease;
            target.Gain();
        }
    }
}
