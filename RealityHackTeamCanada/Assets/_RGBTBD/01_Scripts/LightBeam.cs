using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour
{
    EnvRaycastManager ERManager;
    OVRPassthroughLayer OVRlayer;
    private float sizeScale;
    public bool isBrightnessFlashlight;

    // Start is called before the first frame update
    void Start()
    {
        ERManager = FindFirstObjectByType<EnvRaycastManager>();
        OVRlayer = GetComponentInChildren<OVRPassthroughLayer>();
        if (isBrightnessFlashlight == null)
        {
            isBrightnessFlashlight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        sizeScale = ERManager.getDistance();
        if (transform.Find("Cone") == null)
        {
        }
        else
        {
            changeSize();
            if (isBrightnessFlashlight)
            {
                changeColor();
            }
        }
    }
    public void changeSize()
    {
        float scale = sizeScale / 2;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    public void changeColor()
    {
        //float brightness = Mathf.Clamp(sizeScale, -1f, 1f);
        //Mathf.InverseLerp(-1f, 1f, inputValue);
        float brightness = 0.6f - Mathf.InverseLerp(1f, 10f, sizeScale);
        brightness = Mathf.Max(0, brightness);
        OVRlayer.SetBrightnessContrastSaturation(brightness, 0, 0);
    }
}
