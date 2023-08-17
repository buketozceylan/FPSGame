using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
    public class LookMode : MonoBehaviour
        {
            public PostProcessVolume vol;
            public PostProcessProfile standard;
            public PostProcessProfile inventory;
            public GameObject FlashlightOverlay;
            private Light flashlight;
            private bool flashLightOn = false;
        void Start()
        {
            vol = GetComponent<PostProcessVolume>();
            flashlight = GameObject.Find("flashlight").GetComponent<Light>();
            flashlight.enabled = false;
            FlashlightOverlay.SetActive(false);
            vol.profile = standard;
        }
        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(flashLightOn == false)
                {
                    FlashlightOverlay.SetActive(true);
                    flashlight.enabled = true;
                    flashLightOn = true;
                    FlashLightSwitchOff();
                    FlashlightOverlay.GetComponent<FlashlightScript>().StartDrain();
                }
                else if (flashLightOn == true)
                {
                    FlashlightOverlay.SetActive(false);
                    flashlight.enabled = false;
                    FlashlightOverlay.GetComponent<FlashlightScript>().StopDrain();
                    flashLightOn = false;
                }
                }

            if(flashLightOn == true)
            {
                FlashLightSwitchOff();
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                if (SaveScript.inventoryOpen == false)
                {
                    vol.profile = inventory;
                    if (flashLightOn == true)
                    {
                        FlashlightOverlay.SetActive(false);
                        flashlight.enabled = false;
                        FlashlightOverlay.GetComponent<FlashlightScript>().StopDrain();
                        flashLightOn = false;
                    }
                }
                else if (SaveScript.inventoryOpen == true)
                {
                    vol.profile = standard;
                }
            }

            }

        private void FlashLightSwitchOff()
            {
                if (FlashlightOverlay.GetComponent<FlashlightScript>().batteryPower > 0)
                {
                    return;
                }
                FlashlightOverlay.SetActive(false);
                flashlight.enabled = false;
                FlashlightOverlay.GetComponent<FlashlightScript>().StopDrain();
                flashLightOn = false;
            }

        }