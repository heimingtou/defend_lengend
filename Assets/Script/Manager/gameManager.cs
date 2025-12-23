using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class gameManager : MonoBehaviour
{
    towerGun towerToBuilding;
    /* UI Text*/
    public TMP_Text Text;
    public TMP_Text TextWave;
    /*GameObjec*/
    public GameObject rangeCircle;
    public Transform shopContent;    // Kéo cái 'ShopContent' (có Layout Group) vào đây
    public GameObject buttonPrefab; // Kéo Prefab nút bấm tháp vào đây
    public cursorCustom cursorCustom;
    public GameObject HpObject; // object thanh mau
    public Tripod[] tripods;
    GameObject towerToBuild;
    /*chi so*/
    float localScaleHp;
    float maxDistance=2f;
    public int waveLevel; // tong so wave
    public int countWave; // dem so wave
    public float coin=200;
    public float hpPlayer;
    public float MaxHp = 100;
    
    // Start is called before the first frame update
    public static gameManager instance;
    public void Awake()
    {
        instance = this;
        hpPlayer = MaxHp;
        towerToBuild = null;
        //waveLevel = 10; // sau nay thay bang thong so cua man choi
        countWave = 0;
        showWave();
        localScaleHp=HpObject.transform.localScale.x;
    }
    void Start()
    {
        Text.text = coin.ToString();
        SpawnGunShop();
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
            GameObject towerBuilding= Instantiate(towerToBuild.gameObject, nearlestTile.transform.position,Quaternion.identity);
            nearlestTile.occupie = true;
            towerToBuilding = null;
            cursorCustom.gameObject.SetActive(false); // Ẩn con trỏ tùy chỉnh
            UnityEngine.Cursor.visible = true;
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
        UnityEngine.Cursor.visible = false; // duong dan chinh xac cua cursor
        towerToBuilding = tower;
        changeCost(tower.data.cost * (-1f));
            //Debug.Log("so tien phai tra"+ tower.data.cost);
        towerToBuild = towerPrefab;
        }
    }
    public void changeCost(float addCoint)
    {
       
        coin += addCoint;
        //Debug.Log(coin);
        PlayerPrefs.SetFloat(keyForData.Cost_key, coin);
        Text.text = coin.ToString();
    }
    public void SpawnGunShop()
    {
        foreach (GameObject tower in GunUseManager.instance.listGunUse)
        {
            GameObject shop = Instantiate(buttonPrefab,shopContent);
            towerBuy towerBuy=shop.GetComponent<towerBuy>();
            if(towerBuy != null )
            {
                towerBuy.addIfShop(tower);
            }
            UnityEngine.UI.Button btn = shop.GetComponent<UnityEngine.UI.Button>();
            btn.onClick.RemoveAllListeners();
            GameObject tempTower = tower; // Biến tạm để tránh lỗi closure
            btn.onClick.AddListener(() => BuyTower(tempTower));
        }
    }
    public void  changeHp(float damage)
    {
        float Decrease = HpObject.transform.localScale.x-(damage / (MaxHp * localScaleHp));
        
        if(Decrease>=0)
        { HpObject.transform.localScale = new Vector3( Decrease, HpObject.transform.localScale.y, HpObject.transform.localScale.z); }
        else
        {
            HpObject.transform.localScale = Vector3.zero;
        }
        if (hpPlayer <= 0)
            End();
    }
    public void showWave()
    {
        TextWave.text = $"{countWave}/{waveLevel}";
    }
    public void End()
    {
      
            Debug.Log("End Game");
        
       
    }
}
