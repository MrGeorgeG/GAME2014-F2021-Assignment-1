using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyFactory : MonoBehaviour
{
    public GameObject goblin;
    public GameObject mushroom;
    public GameObject skeleton;
    public GameObject flyingEye;

    public GameObject createEnemy(EnemyType type = EnemyType.RANDOM)
    {
        if(type == EnemyType.RANDOM)
        {
            var randomEnemy = Random.Range(0, 4);
            type = (EnemyType)randomEnemy;
        }

        GameObject tempEnemy = null;

        switch(type)
        {
            case EnemyType.GOBLIN:
                tempEnemy = Instantiate(goblin);
                //tempEnemy.GetComponent<EnemyController>().score =
                break;

            case EnemyType.MUSHROOM:
                tempEnemy = Instantiate(mushroom);
                //tempEnemy.GetComponent<EnemyController>().score =
                break;

            case EnemyType.SKELETON:
                tempEnemy = Instantiate(skeleton);
                //tempEnemy.GetComponent<EnemyController>().score =
                break;

            case EnemyType.FLYINGEYE:
                tempEnemy = Instantiate(flyingEye);
                //tempEnemy.GetComponent<EnemyController>().score =
                break;

        }

        tempEnemy.transform.parent = transform;
        tempEnemy.SetActive(false);

        return tempEnemy;
    }
}