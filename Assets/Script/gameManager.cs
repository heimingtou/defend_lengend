using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class gameManager : MonoBehaviour
{
    tower towerToBuilding;
    public TMP_Text Text;
    public GameObject rangeCircle;
    public cursorCustom cursorCustom;
    public Tripod[] tripods;
    float maxDistance=2f;
    public float coin=200;

    // Start is called before the first frame update
    public static gameManager instance;
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Text.text = coin.ToString();
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
            nearlestTile.occupie = true;
            towerToBuilding = null;
            cursorCustom.gameObject.SetActive(false); // Ẩn con trỏ tùy chỉnh
            Cursor.visible = true;
        }
    }
    public void BuyTower(tower tower)
    {
        if(tower.cost<coin)
       { cursorCustom.gameObject.SetActive(true);
        cursorCustom.GetComponent<SpriteRenderer>().sprite = tower.GetComponent<SpriteRenderer>().sprite;
        rangeCircle.SetActive(true);
        rangeCircle.transform.localScale = new Vector3(tower.range * 2, tower.range * 2, 1);
        Cursor.visible = false;
        towerToBuilding = tower;
        changeCost(tower.cost * -1);
        }
    }
    public void changeCost(float addCoint)
    {
       
        coin += addCoint;
        PlayerPrefs.SetFloat(keyForData.Cost_key, coin);
        Text.text = coin.ToString();
    }
}
