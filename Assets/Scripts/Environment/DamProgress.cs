using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamProgress : MonoBehaviour
{
    private float currentDamProgress = 0.0f; //Value between 0 and 1, represent the dams current progress
    public float waterLevel //A value between 1 and 0, is the inverse of dam progress
    { get { return 1f - currentDamProgress; } } //No set currently as dam progress should not change externally
    private int[] workerCount = { 5, 0 }; //Workers in the dam {human workers, masquerading workers}
    private float progressPerWorker = 0.1f; //The amount of dam progress per second for every worker in the dam

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (workerCount[0] - workerCount[1] >= 0)
        { currentDamProgress += progressPerWorker * (workerCount[0] - workerCount[1]); }
    }
}
