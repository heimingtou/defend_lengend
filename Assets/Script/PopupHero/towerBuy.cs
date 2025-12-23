using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class towerBuy : MonoBehaviour
{
    public Image towerImg;
    public Image element;
    public TMP_Text Price;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addIfShop(GameObject tower)
    {
        towerGun towerGun= tower.GetComponent<towerGun>();
        towerImg.sprite = towerGun.updateRange[0];
        element.sprite = elementManager.instance.getSpriteElement(towerGun.element);
        Price.text = towerGun.data.cost.ToString();
    }
}
