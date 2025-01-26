using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour
{
    EnvRaycastManager ERManager;
    // Start is called before the first frame update
    void Start()
    {
        ERManager = FindFirstObjectByType<EnvRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Cone") != null)
        {
            changeSize();
        }
    }
    public void changeSize()
    {
        float sizeScale = ERManager.getDistance();
        float scale = sizeScale / 2;
        transform.localScale = new Vector3(scale, scale, scale);
        
    }
}
