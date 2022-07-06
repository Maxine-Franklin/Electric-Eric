using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnTowers : MonoBehaviour
{
    //private Camera cam = null;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    cam = Camera.main;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //        Vector3 mousePos = Input.mousePosition;
    //}

    //private void SpawnAtMousePos()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        Ray ray = cam.ScreenPointToRay()
    //    }

    //}

    private Vector3 mousePos;
    private Vector3 objectPos;
    public GameObject yourPrefab;

    public void SpawnAtMousePos()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 2.0f;
            objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(yourPrefab, objectPos, Quaternion.identity);
        }
    }
}
