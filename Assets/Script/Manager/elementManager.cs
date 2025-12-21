using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static elementManager instance;
    public List<Sprite> SpriteELement;
    private void Awake()
    {
        instance = this;
    }
    public float calMultiplier(elementType bullet, elementType enemy)
    {
        switch(bullet)
        {
            case elementType.metal:
                if (enemy == elementType.wood) return 2f;
                if (enemy == elementType.fire) return 0.5f;
                break;
            case elementType.water:
                if (enemy == elementType.fire) return 2f;
                if (enemy == elementType.earth) return 0.5f;
                break;
            case elementType.fire:
                if (enemy == elementType.metal) return 2f;
                Debug.Log("gap doi sat thuong");
                if (enemy == elementType.water) return 0.5f;
                break;
            case elementType.wood:
                if (enemy == elementType.earth) return 2f;
                if (enemy == elementType.metal) return 0.5f;
                break;
            case elementType.earth:
                if (enemy == elementType.water) return 2f;
                if (enemy == elementType.wood) return 0.5f;
                break;
        }
        return 1f;
    }
    public Sprite getSpriteElement(elementType elementType)
    {
        switch (elementType)
        {
            case elementType.metal: 
                return SpriteELement[0];
                
            case elementType.wood:
                return SpriteELement[1];
                   
            case elementType.water:
                return SpriteELement[2];
                
            case elementType.fire:
                return SpriteELement[3];
               
            case elementType.earth:
                return SpriteELement[4];
                
        }
        return null;
    }
}
