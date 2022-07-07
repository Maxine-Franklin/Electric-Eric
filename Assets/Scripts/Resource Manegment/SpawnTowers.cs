using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTowers : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 objectPos;
    private bool enableScript = false;

    public GameObject Balsita;
    public GameObject ScoutTower;
    public GameObject Trebuchet;
    public GameObject EmuRaid;
    public GameObject Espionage;
    public GameObject Propaganda;
    public GameObject House;
    public GameObject LumberYard;

    public string Towername;

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
                enableScript = false;
                mousePos = Input.mousePosition;
                mousePos.z = 2.0f;
                objectPos = Camera.main.ScreenToWorldPoint(mousePos);

                if (Towername == ("Ballista"))
                {
                    if (GameObject.FindObjectOfType<MoneySystem>().money >= 45)
                    {
                        Instantiate(Balsita, objectPos, Quaternion.identity);
                        GameObject.FindObjectOfType<MoneySystem>().subtractMoney(45);
                    }
                }

                if (Towername == ("ScoutTower"))
                {
                    if (GameObject.FindObjectOfType<MoneySystem>().money >= 15)
                    {
                        Instantiate(ScoutTower, objectPos, Quaternion.identity);
                        GameObject.FindObjectOfType<MoneySystem>().subtractMoney(15);
                    }
                }

                if (Towername == ("Trebuchet"))
                {
                    if (GameObject.FindObjectOfType<MoneySystem>().money >= 25)
                    {
                        Instantiate(Trebuchet, objectPos, Quaternion.identity);
                        GameObject.FindObjectOfType<MoneySystem>().subtractMoney(25);
                    }
                }

                if (Towername == ("EmuRaid"))
                {
                    if (GameObject.FindObjectOfType<MoneySystem>().money >= 80)
                    {
                        Instantiate(EmuRaid, objectPos, Quaternion.identity);
                        GameObject.FindObjectOfType<MoneySystem>().subtractMoney(80);
                    }
                }

                if (Towername == ("Espionage"))
                {
                    if (GameObject.FindObjectOfType<MoneySystem>().money >= 40)
                    {
                        Instantiate(Espionage, objectPos, Quaternion.identity);
                        GameObject.FindObjectOfType<MoneySystem>().subtractMoney(40);
                    }
                }

                if (Towername == ("Propaganda"))
                {
                    if (GameObject.FindObjectOfType<MoneySystem>().money >= 40)
                    {
                        Instantiate(Propaganda, objectPos, Quaternion.identity);
                        GameObject.FindObjectOfType<MoneySystem>().subtractMoney(40);
                    }
                }

                if (Towername == ("House"))
                {
                    if (GameObject.FindObjectOfType<MoneySystem>().money >= 20)
                    {
                        Instantiate(House, objectPos, Quaternion.identity);
                        GameObject.FindObjectOfType<MoneySystem>().subtractMoney(20);
                    }
                }

                if (Towername == ("LumberYard"))
                {
                    if (GameObject.FindObjectOfType<MoneySystem>().money >= 10)
                    {
                        Instantiate(LumberYard, objectPos, Quaternion.identity);
                        GameObject.FindObjectOfType<MoneySystem>().subtractMoney(10);
                    }
                }
            }
        }
    }
}
