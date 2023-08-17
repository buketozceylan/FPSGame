using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterScript : MonoBehaviour
{
    public GameObject lighterObj;

    void OnEnable()
    {
        lighterObj.SetActive(true);
    }


    void Update()
    {
        
    }
     void OnDisable()
    {
        lighterObj.SetActive(false);
    }
}
