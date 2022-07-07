using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Turret Properties")]
    public float range = 55f;
    public float fireRate = 1f;
    public float fireCountDown = 0f;
    public float turnSpeed = 10f;

    [Header("Unity Variables")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public GameObject bulletprefab;
    public Transform firePoint;

    void Start()
    {
        //Starts loop to find targets
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        //Find all enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearstEnemy = null;

        //For Every enemy found
        foreach (GameObject enemy in enemies)
        {
            //Get the distance of enemies 
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            //If the distance is shorter then previous enemies 
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearstEnemy = enemy;
            }
        }

        //If found enemy is within range
        if (nearstEnemy != null && shortestDistance <= range)
        {
            target = nearstEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        //Creates a vector dirction that is at the postion of the enemy
        Vector3 dir = target.position - transform.position;

        //Look at the enemy position
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        //Smooth out the rotation of the turret from one rotation to the other
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        
        //Rotate the turret
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletprefab, firePoint.position, Quaternion.identity);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    //Creates the area size which the turret shots in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

}

