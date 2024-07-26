using System.Collections;
using System.Collections.Generic;
using Unity.FPS.AI;
using Unity.FPS.Game;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float lifetime = 2f; // Lifetime of the target in seconds
    private Health healthComponent;


    void Start()
    {
        healthComponent = GetComponent<Health>();
        if (healthComponent == null)
        {
            return;
        }
        

    }

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            healthComponent.TakeDamage(healthComponent.CurrentHealth, gameObject);
        }
    }
}
