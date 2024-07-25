using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float lifetime = 2f; // Lifetime of the target in seconds

    void Start()
    {
        // Destroy the target after 'lifetime' seconds
        Destroy(gameObject, lifetime);
    }
}
