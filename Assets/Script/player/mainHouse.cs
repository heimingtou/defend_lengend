using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.FilterWindow;

public class mainHouse : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            gameManager.instance.hpPlayer-=enemy.damage;
            gameManager.instance.changeHp(enemy.damage);
            Debug.Log(gameManager.instance.hpPlayer);
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
