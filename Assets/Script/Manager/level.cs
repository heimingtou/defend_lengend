using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject parentObject;
    tower parentScript;
    SpriteRenderer sr;
    private void Awake()
    {
        parentScript=parentObject.GetComponent<tower>();
        sr=parentObject.GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        if(parentScript.currentLevel>=0&&parentScript.currentLevel<=parentScript.updateRange.Count)
       { parentScript.currentLevel++;
        Debug.Log(parentScript.currentLevel+"cap nhat level");
            sr.sprite = parentScript.updateRange[parentScript.data.Level];
            sr.sortingOrder = 10;
        }
    }
}
