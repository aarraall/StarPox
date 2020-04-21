﻿using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("FX prefab on death")] [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    
    ScoreBoard scoreBoard;


    // Start is called before the first frame update
    void Start()
    {
        addNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void addNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }


    private void OnParticleCollision(GameObject other)
    {
        
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity) as GameObject;
        fx.transform.parent = parent;
        Destroy(fx, 5f); // todo customize it    
        Destroy(gameObject);

        scoreBoard.ScoreHit();
    }

}