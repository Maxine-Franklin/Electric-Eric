using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject terrain; //Main player camera
    private int layer = 10; //Current layer tracker
    private Vector3 cameraPos = Vector3.zero; //Position of player camera

    // Start is called before the first frame update
    void Start()
    { cameraPos = gameObject.transform.position; } //Obtains position of player camera

    // Update is called once per frame
    void Update()
    {
        if (layer < 10) //If camera is below the maximum layer then...
        { 
            if (Input.GetKeyDown(KeyCode.UpArrow)) //If the up arrow key is pressed then...
            {
                //Increases the camera's vertical position by 1 layer
                cameraPos.y += 2.54f;
                gameObject.transform.position = cameraPos;

                layer += 1; //Increases the current tracked layer by 1
            }
        }
        if (layer > -0)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow)) //If the up arrow key is pressed then...
            {
                //Decreases the camera's vertical position by 1 layer
                cameraPos.y -= 2.54f;
                gameObject.transform.position = cameraPos;

                layer -= 1; //Decreases the current tracked layer by 1
            }
        }
    }
}
