using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingMaster : MonoBehaviour
{

    public List<buildingCollider> colliders;
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
            foreach (buildingCollider buidling in colliders)
            {
                //if (buidling.gameObject.GetComponent<Collision>().collider.tag == "terrain")
                //{ colliders.Remove(buidling); buidling. }
            }
            //Check for collisions on buildings
        }
    }
}
