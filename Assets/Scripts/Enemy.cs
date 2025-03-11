using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public float speed;
    private int index;
    public event Action OnDeath;
    private void Start()
    {
        index = 0;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position,PathManager.instance.waypoints[index].position) <= 0.3f)
        {
            if (index == PathManager.instance.waypoints.Count - 1)
            {
                OnDeath?.Invoke();
                DestroyEnemy();
            }
            else
            {
                index++;

            }
        }
        
        
        
        transform.position =  Vector2.MoveTowards(transform.position, PathManager.instance.waypoints[index].position, speed * Time.deltaTime);
        
         
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    
}
