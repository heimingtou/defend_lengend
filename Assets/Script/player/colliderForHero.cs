using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class colliderForHero : MonoBehaviour
{
    public bool isSelect=false;
    public tower towerParent;
    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("khoi dong collider");
        isSelect = false;
    }
    public void OnMouseDown()
    {
        
        isSelect = !isSelect;
        if (isSelect)
        {
            HeroUIPopup.instance.showPopup();
        }
        else
        {
            HeroUIPopup.instance.closePopup();
        }
        Debug.Log("bat range");
        towerParent.circleRange.SetActive(isSelect);
        SpriteRenderer sr= towerParent.GetComponent<SpriteRenderer>();
        GameObject tower = transform.parent.gameObject;
        HeroUIPopup.instance.SetUp(towerParent.currentDamage,
                                   towerParent.currentRange,
                                   towerParent.currentLevel,
                                   towerParent.currentCost,sr.sprite,
                                   tower,
                                   elementManager.instance.getSpriteElement(towerParent.element));
       // HeroUIPopup.instance.SetPopup();
        //HeroUIPopup.instance.SetPopup();
        // if(currentHeroPopup==null)
        // {
        //     Canvas canvas = FindObjectOfType<Canvas>();
        //     currentHeroPopup = Instantiate(popupHeroPrefab, canvas.transform);
        // }
        // Debug.Log(currentLevel);
        // if(!isSelect)
        //{ currentHeroPopup.SetUp(currentDamage, currentRange, currentLevel, currentCost, updateRange[currentLevel],this.gameObject);
        //     circleRange.SetActive(true);
        //     isSelect= true;
        // }
        // else
        // {
        //     currentHeroPopup.closePopup();
        //     circleRange.SetActive(false);
        //     isSelect= false;

        // }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(isSelect)
            {
                isSelect = false;
                HeroUIPopup.instance.closePopup();
                towerParent.circleRange.SetActive(isSelect);
            }
        }
    }
}
