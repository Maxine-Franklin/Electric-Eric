using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingMaster : MonoBehaviour
{

    public List<GameObject> colliders;
    public DamProgress damProgress;
    private float priorWaterLevel = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (priorWaterLevel - 0.1f > damProgress.waterLevel)
        {
            priorWaterLevel -= 0.1f;
            foreach (GameObject buidling in colliders)
            {
                if (buidling.GetComponent<MeshCollider>().GetComponent<Collider>().tag == "Terrain")
                { colliders.Remove(buidling); Destroy(buidling); }
            }
            //Check for collisions on buildings
        }
    }
}
