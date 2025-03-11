using System;
using Unity.Mathematics;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public float force;
    private Transform target;
    public Transform originTower;
    public Animator anim;

    public int shootPerSecond;
    public float fireRate;
    
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }


    private void Update()
    {
        Target();

    }


    public void ShootProjectiles()
    {
        if(target == null) return;
        Vector2 dir = target.position - firePoint.position;
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(dir * force, ForceMode2D.Impulse);
    }

    private bool Target()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(originTower.position,5f,LayerMask.GetMask("Enemy"));
        if (hits.Length > 0)
        {
            target = hits[0].transform;
            return true;
        }
        else
        {
            target = null;
            return false;
        }
    }

    private void HandleShooting()
    {
        if (target != null)
        {
            Debug.Log("Shoot");
            
            //Ham cap nhat qua nhanh trigger khong hoat dong kip
            anim.SetTrigger("Shoot");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(originTower.position,5f);
    }
}
