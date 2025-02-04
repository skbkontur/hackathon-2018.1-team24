﻿using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusEnemyController : EnemyBase
{

    public EnemyParams enemyParams;
    
    private float release;

	void Start ()
    {
        Set(0, enemyParams.hit, 0);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (release < Time.time)
        {
            var enemy = collision.gameObject.GetComponent<EnemyBase>();
            enemy?.ApplyHit(enemyParams.hit);
            release = Time.time + 1f;
            SoundManager.Instance.Play("punch");
        }
    }

}
