using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingCollider : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Water")
        {
            GetComponent<Rigidbody>().mass = 1;
        }
    }
}
