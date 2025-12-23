using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUseManager : MonoBehaviour
{
    public List<GameObject> listGunUse;
    public static GunUseManager instance;
    public void Awake()
    {
        instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
