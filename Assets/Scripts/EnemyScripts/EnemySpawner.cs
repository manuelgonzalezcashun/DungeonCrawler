using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Enemy enemyData;
    public float waitForNextEnemy = 5f;
    private int newOrderInLayer = -1;
    private Coroutine coroutine;

    void Start()
    {
        StartCoroutine();
    }

    void StartCoroutine()
    {
        coroutine = StartCoroutine(SpawnEnemy(waitForNextEnemy, enemyPrefab));
    }
    void PauseCoroutine()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
    void ResumeCoroutine()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(SpawnEnemy(waitForNextEnemy, enemyPrefab));
        }
    }

    IEnumerator SpawnEnemy(float interval, GameObject obj)
    {
        {
            if (!GameManagement.GetInstance().gameIsPaused)
            {
                Debug.Log(obj.name);
                yield return new WaitForSeconds(interval);
                GameObject newPrefab = Instantiate(obj, new Vector3(Random.Range(-16, 17), Random.Range(-9, 10), 0), Quaternion.identity);
                //EnemyBehavior enemyBehavior = newPrefab.GetComponent<EnemyBehavior>();
                //enemyBehavior.enemy = enemyData;
                StartCoroutine(SpawnEnemy(interval, obj));
            }
        }
    }

    void Update()
    {
        if (GameManagement.GetInstance().gameIsPaused)
        {
            PauseCoroutine();
            Debug.Log("Coroutine paused");

            GameObject[] hideObjects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject obj in hideObjects)
            {
                SpriteRenderer objRenderer = obj.GetComponent<SpriteRenderer>();
                objRenderer.sortingOrder = newOrderInLayer;
            }
        }
        else
        {
            ResumeCoroutine();
            Debug.Log("Coroutine resumed");
        }

        if (GameManagement.GetInstance().playerisDead())
        {
            GameObject[] destroyObjects = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject obj in destroyObjects)
            {
                Destroy(obj);
            }
        }
    }

}