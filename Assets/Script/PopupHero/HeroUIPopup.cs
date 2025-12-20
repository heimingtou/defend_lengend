//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HeroUIPopup : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text damage;
    public TMP_Text range;
    public TMP_Text level;
    public TMP_Text Ldamage;
    public TMP_Text Lrange;
    public TMP_Text Llevel;
    public TMP_Text price;
    public TMP_Text sell;
    public UnityEngine.UI.Image Icon;
    public GameObject target;
    public void SetUp(float Damage, float Range,float Level, float Cost, Sprite sprite,GameObject targetTower)
    {
        Icon.sprite=sprite;
        damage.text = Damage.ToString();
        range.text = Range.ToString();
        level.text = Level.ToString();
        Ldamage.text = (Damage+10f).ToString();
        Lrange.text = (Range+0.2f).ToString();
        Llevel.text = (Level+1f).ToString();
        price.text = Cost.ToString();
        sell.text = ((int)Cost / 2).ToString();
        target=targetTower;
        gameObject.SetActive(true);
    }
    public void closePopup()
    {
        gameObject.SetActive (false);
    }
    public void updateLevel()
    {
        tower targetSprite = target.GetComponent<tower>();
        if (gameManager.instance.coin>targetSprite.currentCost && targetSprite.currentLevel<targetSprite.updateRange.Count)
       {
            gameManager.instance.changeCost(targetSprite.currentCost * -1);
        targetSprite.currentLevel++;
        targetSprite.currentRange += 0.2f;
        targetSprite.currentDamage += 10f;
        targetSprite.currentCost += 50;
        targetSprite.circleRange.transform.localScale= new Vector3(targetSprite.currentRange * 2, targetSprite.currentRange * 2, 1);
        SpriteRenderer sr=targetSprite.GetComponent<SpriteRenderer>();
        sr.sprite = targetSprite.updateRange[targetSprite.currentLevel];
            SetUp(targetSprite.currentDamage, targetSprite.currentRange, targetSprite.currentLevel, targetSprite.currentCost, sr.sprite, target.gameObject);
        }
    }
    public void sellGun()
    {
        float cost = float.Parse(sell.text);
        gameManager.instance.changeCost(cost);
        Destroy(target);
    }
}
