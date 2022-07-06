using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    int number = 0;
    public GameObject Camera;
    public SpawnTowers towerMeUpDaddy;    
    
    public string url;

    //gameObject.properties<SpawnTowers>().SpawnTowersEnable = 1;
    //SpawnTowers.SpawnTowersEnable = 1;

    public void SetText(string text)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }

    public void PressedButton()
    {
        if (number == 1)
        {            
            number--;
            Camera.transform.position = new Vector3(0, 3, 10);
            Camera.transform.Rotate(-90, 0, 0);
            towerMeUpDaddy.SpawnTowersEnable = false;
        }
        else
        {
            number++;
            Camera.transform.position = new Vector3(0, 30, 0);
            Camera.transform.Rotate(90, 0, 0);
            towerMeUpDaddy.SpawnTowersEnable = true;
        }
    }

    public void OpenURL()
    {
        Application.OpenURL(url);
    }

}
