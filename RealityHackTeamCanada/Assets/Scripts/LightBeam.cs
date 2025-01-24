using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RaycastManager.instance.AddLine(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
