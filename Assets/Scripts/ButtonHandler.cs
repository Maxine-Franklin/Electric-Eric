using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public string Tower;
    public GameObject Camera;
    public SpawnTowers TowerToSpawn;
    public Camera MainCamera;
    public string url;
    public string SceneToTransitionTo;
    public GameObject panel;

    //Set Text when button pressed
    public void SetText(string text)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }

    //If button pressed allow to spawn tower
    public void PressedButton()
    {
        string myName = gameObject.name;
        Debug.Log(myName);
        TowerToSpawn.Towername = myName;
        TowerToSpawn.SpawnTowersEnable = true;
    }

    //URL link
    public void OpenURL()
    {
        Application.OpenURL(url);
    }

    //Change scene
    public void NextScene()
    {
        SceneManager.LoadScene(SceneToTransitionTo);
    }

    public void EnablePanel()
    {
        //Change camera perspective, camera postion enables build mode
        panel.SetActive(true);
        MainCamera.orthographic = true;
        Camera.transform.position = new Vector3(0, 30, 0);
        Camera.transform.Rotate(90, 0, 0);
        MainCamera.clearFlags = CameraClearFlags.Skybox; //Turns the background to a solid colour

    }
    public void DisablePanel()
    {
        //Move postion of camera and disable build mode
        panel.SetActive(false);
        MainCamera.orthographic = false;
        Camera.transform.position = new Vector3(0, 3, 10);
        Camera.transform.Rotate(-90, 0, 0);
        MainCamera.clearFlags = CameraClearFlags.Skybox; //Turns background to use the skybox
    }

}
