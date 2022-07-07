using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Varibles for the bullets
    [Header("Bullet Properties")]
    public float speed = 70f;
    public int deathTime = 5;
    public int damage = 25;

    //Target to lock onto
    private Transform target;

    //Seeks onto the target is called in turrets
    public void Seek (Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        //If there is no target delete object
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //Move Bullet towards target varibles
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        //If the bullet is ontop of enemy 
        if (dir.magnitude <= distanceThisFrame)
        {
            //Destory bullet and enemy
            HitTarget();
            return;
        }

        //Move Bullet 
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
