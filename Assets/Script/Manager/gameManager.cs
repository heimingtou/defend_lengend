using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class gameManager : MonoBehaviour
{
    towerGun towerToBuilding;
    public TMP_Text Text;
    public GameObject rangeCircle;
    public cursorCustom cursorCustom;
    public Tripod[] tripods;
    float maxDistance=2f;
    public float coin=200;
    public float hpPlayer = 100;
    GameObject towerToBuild;
    // Start is called before the first frame update
    public static gameManager instance;
    public void Awake()
    {
        instance = this;
        towerToBuild = null;
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
            //Debug.Log("bat duoc vi tri gan");
            cursorCustom.transform.position = nearlestTile.transform.position;
        }
        
        if (Input.GetMouseButtonDown(0) && towerToBuilding != null && nearlestTile!=null && towerToBuild!=null )
        {
            Instantiate(towerToBuild.gameObject, nearlestTile.transform.position,Quaternion.identity);
            
            nearlestTile.occupie = true;
            towerToBuilding = null;
            cursorCustom.gameObject.SetActive(false); // Ẩn con trỏ tùy chỉnh
            Cursor.visible = true;
            towerToBuild = null; 
        }
    }
    public void BuyTower( GameObject towerPrefab)
    {
        towerGun tower=towerPrefab.GetComponent<towerGun>();
        if (tower.data.cost<coin)
       { cursorCustom.gameObject.SetActive(true);
        cursorCustom.GetComponent<SpriteRenderer>().sprite = tower.GetComponent<SpriteRenderer>().sprite;
        rangeCircle.SetActive(true);
        rangeCircle.transform.localScale = new Vector3(tower.data.Range * 2, tower.data.Range * 2, 1);
        Cursor.visible = false;
        towerToBuilding = tower;
        changeCost(tower.data.cost * (-1f));
            Debug.Log("so tien phai tra"+ tower.data.cost);
        towerToBuild = towerPrefab;
        }
    }
    public void changeCost(float addCoint)
    {
       
        coin += addCoint;
        Debug.Log(coin);
        PlayerPrefs.SetFloat(keyForData.Cost_key, coin);
        Text.text = coin.ToString();
    }
}
