using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreWood : MonoBehaviour
{
    private bool activateMoney = true;
    public float waitforsecounds;
    public int addedmoneyamount;


    void Start()
    {
        StartCoroutine(MakingMoney());
    }

    public IEnumerator MakingMoney()
    {
        //Creates money for the player every 25 secounds 
        while (activateMoney == true)
        {
            GameObject.FindObjectOfType<MoneySystem>().addMoney(addedmoneyamount);
            yield return new WaitForSeconds(waitforsecounds);
        }
    }
}

