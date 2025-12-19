using FluffyUnderware.Curvy;
using FluffyUnderware.Curvy.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemyManager : MonoBehaviour
{
    // Start is called before the first frame update\\


    public GameObject enemyPrefab;
    public GameObject PositionSpawn;
    float timer = 0;
    public static spawnEnemyManager instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>0.5)
        {
            spawn();
            timer = 0;
        }

    }
    void spawn()
    {
        int index = UnityEngine.Random.Range(0,10 ) % (CurvySplineManager.instance.allSplines.Count-1);
        CurvySpline path = CurvySplineManager.instance.GetCurvySpline(index);
        GameObject enemy= Instantiate(enemyPrefab, path.transform.position, Quaternion.identity);
        
        SplineController controler= enemy.GetComponent<SplineController>();
        controler.Spline = path;
        controler.Play();

    }
}
