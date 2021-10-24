using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyManager : MonoBehaviour
{
    public EnemyFactory enemyFactory;
    public int MaxEnemy;

    private Queue<GameObject> m_enemyPool;

    // Start is called before the first frame update
    void Start()
    {
        _BuilEnemyPool();
    }

    private void _BuilEnemyPool()
    {
        m_enemyPool = new Queue<GameObject>();

        for(int count = 0; count < MaxEnemy; count++)
        {
            var tempEnemy = enemyFactory.createEnemy();
            m_enemyPool.Enqueue(tempEnemy);
        }
    }

    public GameObject GetEnemy(Vector3 position)
    {
        var newEnemy = m_enemyPool.Dequeue();
        newEnemy.SetActive(true);
        newEnemy.transform.position = position;
        return newEnemy;
    }

    public bool HasEnemy()
    {
        return m_enemyPool.Count > 0;
    }

    public void ReturnEnemy(GameObject returnedEnemy)
    {
        returnedEnemy.SetActive(false);
        m_enemyPool.Enqueue(returnedEnemy);
    }
}
