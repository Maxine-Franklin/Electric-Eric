using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    //public WaveSpawner wave;
    private int wavepointIndex = 0;

    void Start()
    {
        //Create an Array of waypoints and set them as a tranform object
        target = Waypoints.wayPoints[0];
    }

    void Update()
    {
        //wave = GameObject.Find("GameController").GetComponent<WaveSpawner>();
        speed = 0; //wave.currentSpeed;
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNewtWayPoint();
        }
    }

    void GetNewtWayPoint()
    {     
        if (wavepointIndex >= Waypoints.wayPoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.wayPoints[wavepointIndex];
    }
}
