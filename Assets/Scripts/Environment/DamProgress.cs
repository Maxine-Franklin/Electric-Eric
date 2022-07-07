using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamProgress : MonoBehaviour
{
    private float currentDamProgress = 0.0f;
    public float waterLevel
    { get { return 1f - currentDamProgress; } } //No set currently as dam progress should not change externally

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
