using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreWood : MonoBehaviour
{
    private bool activateMoney = true;
    //public float waitforsecounds;
    //public int addedmoneyamount;

    public float woodPerSecond = 10;
    private float woodToAdd = 0;


    void Start()
    {
        //StartCoroutine(MakingMoney());
    }

    private void FixedUpdate()
    {
        woodToAdd += woodPerSecond * Time.deltaTime;
        while (woodToAdd > 1)
        {
            woodToAdd -= 1;
            FindObjectOfType<MoneySystem>().addMoney(1);
        }
    }

    /*public IEnumerator MakingMoney()
    {
        //Creates money for the player every 25 secounds 
        while (activateMoney == true)
        {
            GameObject.FindObjectOfType<MoneySystem>().addMoney(addedmoneyamount);
            yield return new WaitForSeconds(waitforsecounds);
        }
    }*/
}

