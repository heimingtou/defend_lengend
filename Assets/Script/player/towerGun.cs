using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerGun : tower
{
    public GameObject buttonUpdate;
    public  HeroUIPopup popupHeroPrefab;
    public static HeroUIPopup currentHeroPopup;
    public bool isSelect;
    // Start is called before the first frame update
    public void OnMouseDown()
    {
        if(currentHeroPopup==null)
        {
            Canvas canvas = FindObjectOfType<Canvas>();
            currentHeroPopup = Instantiate(popupHeroPrefab, canvas.transform);
        }
        Debug.Log(currentLevel);
        if(!isSelect)
       { currentHeroPopup.SetUp(currentDamage, currentRange, currentLevel, currentCost, updateRange[currentLevel],this.gameObject);
            circleRange.SetActive(true);
            isSelect= true;
        }
        else
        {
            currentHeroPopup.closePopup();
            circleRange.SetActive(false);
            isSelect= false;

        }
    }
    public void buildTower(Vector3 Position)
    {
        //Instantiate(gameObject, Position, Quaternion.identity); /// tu sin chinh minh khong hop li
    }
}
