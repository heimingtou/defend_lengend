using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp;
    public float damage=2;
    public float cost;
    public elementType  element;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        //if (viewPos.x > 1)
        //{
        //    gameManager.instance.hpPlayer--;
        //    Debug.Log(gameManager.instance.hpPlayer);
        //    Destroy(gameObject);
        //}


    }
    public void takeDamage(float damage)
    {
        Debug.Log(damage);
        hp = hp - damage ;
    }
    public void die()
    {
        gameManager.instance.changeCost(cost);
        Destroy(gameObject);
        spawnEnemyManager.instance.countEnemyLive--;
        if (spawnEnemyManager.instance.countEnemyLive <= 0 && gameManager.instance.countWave == gameManager.instance.waveLevel)
            gameManager.instance.End();
    }
}
