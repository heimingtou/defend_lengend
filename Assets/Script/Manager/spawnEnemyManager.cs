using FluffyUnderware.Curvy;
using FluffyUnderware.Curvy.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemyManager : MonoBehaviour
{
    // Start is called before the first frame update\\

    public List<GameObject> enemyPrefab;
    public int countEnemyLive;
    //public GameObject enemyPrefab;
    //public GameObject PositionSpawn;
    public bool isSpawn;
    float timer = 0;
    public static spawnEnemyManager instance;
    public int countEnemy;
    public int count;
    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        countEnemy = 50;
        isSpawn = false;
        count = 0;
        countEnemyLive = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == countEnemy)
        {
            isSpawn = false;
            count = 0;
            countEnemy += 10;
            Debug.Log("endWave");
        }
        if (!isSpawn)
            return;
        timer += Time.deltaTime;
        if(timer>0.5)
        {
            spawn();
            timer = 0;
            count++;
        }

    }
    void spawn()
    {
        int select= CurvySplineManager.instance.allSplines.Count;
        countEnemyLive++;
        if (select> gameManager.instance.countWave)
        {
            select= gameManager.instance.countWave;
        }
        int index = UnityEngine.Random.Range(0,10 ) % select;
        CurvySpline path = CurvySplineManager.instance.GetCurvySpline(index);
        select = enemyPrefab.Count;
        if (gameManager.instance.countWave < enemyPrefab.Count)
        {
            select = gameManager.instance.countWave;
        }
        index= UnityEngine.Random.Range(0, 10) % select;
        GameObject enemy= Instantiate(enemyPrefab[index], path.transform.position, Quaternion.identity);
        SplineController controler= enemy.GetComponent<SplineController>();
        controler.Spline = path;
        controler.Play();
    }
    public void clickToSpawn()
    {
        if(!isSpawn)
        gameManager.instance.countWave++;
        isSpawn = true;
        gameManager.instance.showWave();
        Debug.Log("start Wave");
    }
}
