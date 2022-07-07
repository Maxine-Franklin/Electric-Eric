using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamProgress : MonoBehaviour
{
    private bool gameOver = false;

    private float currentDamProgress = 0.0f; //Value between 0 and 1, represent the dams current progress
    public float waterLevel //A value between 1 and 0, is the inverse of dam progress
    { get { return 1f - currentDamProgress; } } //No set currently as dam progress should not change externally
    private int[] workerCount = { 5, 0 }; //Workers in the dam {human workers, masquerading workers}
    public int humanWorkers
    { get { return workerCount[0]; } set { workerCount[0] += value; } }
    public int masqueradingWorkers
    { get { return workerCount[1]; } set { workerCount[1] += value; } }
    public float progressPerWorker = 0.005f; //The amount of dam progress per second for every worker in the dam

    const float yAdjust = 25.5f; //Adjustment of y axis to fully drain the lake
    public GameObject dam;
    public GameObject water;
    private Vector3[] gameObjectPos = { Vector3.zero, Vector3.zero };

    public Text[] workerCounters = new Text[2];

    public GameObject btnExit;
    public GameObject btnWorker;

    public Slider waterLevelSlider;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectPos[0] = dam.transform.position; //Obtains and stores the dam's final position
        gameObjectPos[0].y -= yAdjust; //Decreases the dam's y position to the water's draining point
        gameObjectPos[1] = water.transform.position; //Obtains and stores the water's starting position
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        workerCounters[0].text = workerCount[0].ToString();
        workerCounters[1].text = workerCount[1].ToString();
        if (masqueradingWorkers < 0) { workerCount[1] = 0; } //Safe code
        if (waterLevel > 0f)
        {

            if (workerCount[0] - workerCount[1] >= 0) //If human workers outnumber masquerading workers...
            //Increases dam progress based on worker count
            { currentDamProgress += progressPerWorker * (workerCount[0] - workerCount[1]) * Time.deltaTime; }

            //Adjusts the dam and water positions to reflect upon dam progress
            dam.transform.position = new Vector3(gameObjectPos[0].x, gameObjectPos[0].y + yAdjust * currentDamProgress, gameObjectPos[0].z);
            water.transform.position = new Vector3(gameObjectPos[1].x, gameObjectPos[1].y - yAdjust * currentDamProgress, gameObjectPos[1].z);

            waterLevelSlider.value = currentDamProgress; //Changes the value of a UI slider to show the player how much water they have left
        }
        else if (gameOver == false) //if the dam has been completed...
        {
            gameOver = true; //Prevents end state looping
            //Ensures dam is in the correct ending position
            gameObjectPos[0].y += yAdjust;
            dam.transform.position = gameObjectPos[0];
            btnExit.SetActive(true);
            btnWorker.SetActive(false);
        }
    }
}
