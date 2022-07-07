using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTowers : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 objectPos;
    private bool enableScript = false;

    public GameObject TowerPrefab;

    //Activates the Spawn tower function when enabled in another script
    public bool SpawnTowersEnable
    {
        get { return enableScript; }
        set { enableScript = value; }
    }

    private void Update()
    {
        if (enableScript)
        {
            //If mouse down find postion and create tower
            if (Input.GetButtonDown("Fire1"))
            {
                mousePos = Input.mousePosition;
                mousePos.z = 2.0f;
                objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                Instantiate(TowerPrefab, objectPos, Quaternion.identity);
            }
        }
    }
}
