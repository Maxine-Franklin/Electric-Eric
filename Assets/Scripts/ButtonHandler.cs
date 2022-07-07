using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    int number = 0;
    public GameObject Camera;
    public SpawnTowers TowerToSpawn;
    public Camera MainCamera;
    public string url;

    //Set Text when button pressed
    public void SetText(string text)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }

    //If button pressed function run 
    public void PressedButton()
    {
        if (number == 1)
        {
            //Move postion of camera and turn of placing towers
            number--;
            Camera.transform.position = new Vector3(0, 3, 10);
            Camera.transform.Rotate(-90, 0, 0);
            TowerToSpawn.SpawnTowersEnable = false;
            MainCamera.clearFlags = CameraClearFlags.Skybox; //Turns background to use the skybox

            //Change camera perspective
            MainCamera.orthographic = false;
        }
        else
        {
            //Move postion of camera and allow placing on towers
            number++;
            Camera.transform.position = new Vector3(0, 30, 0);
            Camera.transform.Rotate(90, 0, 0);
            TowerToSpawn.SpawnTowersEnable = true;
            MainCamera.clearFlags = CameraClearFlags.Skybox; //Turns the background to a solid colour

            //Change camera perspective
            MainCamera.orthographic = true;
        }
    }

    //Comment 
    //If statment for placement of towers 
    //If money not enough no tower, combined with tower

    //URL link
    public void OpenURL()
    {
        Application.OpenURL(url);
    }

}
