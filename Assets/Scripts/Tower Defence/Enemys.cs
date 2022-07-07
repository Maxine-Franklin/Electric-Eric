using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    [Header("Turret Properties")]
    public float speed = 10f;
    public WaveSpawner wave;

    private Transform target;
    private int wavepointIndex = 0;

    private GameObject gameControlSystem;

    void Start()
    {
        //Create an Array of waypoints and set them as a tranform object
        target = Waypoints.wayPoints[0];

        gameControlSystem = GameObject.Find("GameControlSystem");
    }

    void Update()
    {
        wave = gameControlSystem.GetComponent<WaveSpawner>();
        speed = wave.currentSpeed;

        //Move enemy along waypoint path
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        //Look into waypoint if goes over the amount of waypoints delete the target 
        if (wavepointIndex >= Waypoints.wayPoints.Length - 1)
        {
            //This will need to be set to build the dam in the finished product
            gameControlSystem.GetComponent<DamProgress>().humanWorkers = 1;

            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.wayPoints[wavepointIndex];
    }
}
