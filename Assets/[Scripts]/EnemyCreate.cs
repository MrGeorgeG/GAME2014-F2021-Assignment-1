using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public EnemyManager enemyManager;
    public float fireDelay;

    private void Update()
    {
        _CreatNew();
    }

    private void _CreatNew()
    {
        // delay bullet firing 
        if (Time.frameCount % 60 == 0 && enemyManager.HasEnemy())
        {
            enemyManager.GetEnemy(transform.position);
        }
    }
}
