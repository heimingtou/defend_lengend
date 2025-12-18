using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class gameManager : MonoBehaviour
{
    tower towerToBuilding;
    public cursorCustom cursorCustom;
    public Tripod[] tripods;
    float maxDistance=2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePostition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Tripod nearlestTile = null;
        MousePostition.z = 0;
        if (towerToBuilding != null)
        {
            float nearlestDistance = float.MaxValue;
            foreach (Tripod tripod in tripods)
            {
                float dis = Vector3.Distance(tripod.transform.position, MousePostition);
                if (dis < nearlestDistance && dis<=maxDistance && !tripod.occupie)
                {
                    nearlestDistance = dis;
                    nearlestTile = tripod;
                    nearlestTile.rend.color = nearlestTile.green;
                }
                else
                {
                   tripod.rend.color = tripod.none;
                }
            }
        }
        if(nearlestTile!=null)
        {
            Debug.Log("bat duoc vi tri gan");
            cursorCustom.transform.position = nearlestTile.transform.position;
        }
        
        if (Input.GetMouseButtonDown(0) && towerToBuilding != null && nearlestTile!=null)
        {
            towerToBuilding.buildTower(nearlestTile.transform.position);
            towerToBuilding = null;
            cursorCustom.gameObject.SetActive(false); // Ẩn con trỏ tùy chỉnh
            Cursor.visible = true;
        }
    }
    public void BuyTower(tower tower)
    {
        cursorCustom.gameObject.SetActive(true);
        cursorCustom.GetComponent<SpriteRenderer>().sprite = tower.GetComponent<SpriteRenderer>().sprite;
        Cursor.visible = false;
        towerToBuilding = tower;
    }
}
