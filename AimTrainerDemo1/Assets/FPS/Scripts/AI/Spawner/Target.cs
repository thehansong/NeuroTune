using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float lifetime = 2f; // Lifetime of the target in seconds
    private bool isHit = false;

    void Start()
    {
        // Destroy the target after 'lifetime' seconds
        Destroy(gameObject, lifetime);
    }

    void OnDestroy()
    {
        if (!isHit)
        {
            TargetSpawner.Instance.Miss();
        }
    }

    void OnMouseDown() // Assuming clicking on the target to simulate a hit
    {
        isHit = true;
        TargetSpawner.Instance.Hit();
        Destroy(gameObject);
    }
}
