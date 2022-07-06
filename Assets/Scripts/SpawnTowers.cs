using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTowers : MonoBehaviour
{
    private Vector3 mousePos;
    public  Vector3 objectPos;
    public GameObject yourPrefab;
    private bool enableScript = false;
    public bool SpawnTowersEnable
    {
        get { return enableScript; }
        set { enableScript = value; }
    }

    private void Update()
    {
        if (enableScript)
        {
            Debug.Log("Start of loop");

            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Button Down");

                mousePos = Input.mousePosition;
                mousePos.z = 2.0f;
                objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                Instantiate(yourPrefab, objectPos, Quaternion.identity);
                Debug.Log("Button Down");

            }
        }
    }

    //public void SpawnAtMousePos()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        mousePos = Input.mousePosition;
    //        mousePos.z = 2.0f;
    //        objectPos = Camera.main.ScreenToWorldPoint(mousePos);
    //        Instantiate(yourPrefab, objectPos, Quaternion.identity);
    //    }
    //}
}
