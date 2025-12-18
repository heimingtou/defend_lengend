using FluffyUnderware.Curvy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvySplineManager : MonoBehaviour
{
    public static CurvySplineManager instance;
    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    public List<CurvySpline> allSplines;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public CurvySpline GetCurvySpline(int index)
    {
        CurvySpline spline = allSplines[index];
        return spline;
    }
}
