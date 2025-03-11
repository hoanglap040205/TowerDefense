using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class PathManager : MonoBehaviour
{
    public Transform path;
    public Transform startPoint;
    public List<Transform> waypoints = new List<Transform>();
    
    public static PathManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        for (int i = 0; i < path.childCount; i++)
        {
            waypoints.Add(path.GetChild(i));
        }
        startPoint = waypoints[0];

    }
    
    
    
    
    
}
