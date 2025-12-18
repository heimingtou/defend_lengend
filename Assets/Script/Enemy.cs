using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp;
    public float cost;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(float damage)
    {
        hp = hp - damage ;
    }
    public void die()
    {
        gameManager.instance.changeCost(cost);
        Destroy(gameObject);
    }
}
