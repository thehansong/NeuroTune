using System.Collections;
using System.Collections.Generic;
using Unity.FPS.AI;
using Unity.FPS.Game;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float lifetime = 2f; // Lifetime of the target in seconds
    private bool isHit = false;

    void Start()
    {
        EventManager.AddListener<EnemyKillEvent>(OnEnemyKilled2);
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

    void OnEnemyKilled2(EnemyKillEvent evt)
    {
        TargetSpawner.Instance.HitByPlayer();
    }
}
