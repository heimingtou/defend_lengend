using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripod : MonoBehaviour
{
    // Start is called before the first frame update
    public bool occupie=false;
    public Color green;
    public Color none;
    public SpriteRenderer rend;
    void Start()
    {
        rend= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
