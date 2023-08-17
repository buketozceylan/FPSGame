using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightScript : MonoBehaviour
{
    private Image FLBatteryChunks;
    public float batteryPower = 1.0f;
    public float drainTime = 2; 
    void Start()
    {
        FLBatteryChunks = GameObject.Find("FLBatteryChunks").GetComponent<Image>();
        StartDrain();
    }

  
    void Update()
    {
        FLBatteryChunks.fillAmount = batteryPower;
    }

    private void FLBatteryDrain ()
    {
        if(batteryPower > 0.0f)
        batteryPower -= 0.05f;
    }
    public void StartDrain(){
        InvokeRepeating("FLBatteryDrain",drainTime, drainTime);
    }
    public void StopDrain()
        {
        CancelInvoke("FLBatteryDrain");
        }

}
