using UnityEngine;
using Meta.XR;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;

public class EnvRaycastManager : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private EnvironmentRaycastManager raycastManager;
    private float distance;
    private List<float> pastDistances;
    public GameObject anchor;
    public UnityEvent function;

    private float timegap = 0.1f;
    private float timeLeft;

    private void Start()
    {
        if (anchor == null)
        {
            anchor = GameObject.Find("RightHandAnchor");
        }
        raycastManager = gameObject.GetComponent<EnvironmentRaycastManager>();
        distance = 10f;
        pastDistances = new List<float>();

}

private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            cast();
            timeLeft = timegap;
        }
    }

    private void cast()
    {
        // Cast a ray from the center of the camera's view
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        EnvironmentRaycastHit hit;

        // Perform raycast using EnvironmentRaycastManager
        if (raycastManager.Raycast(ray, out hit, 100f))//EnvironmentRaycastHit
        {
            // Optionally, align the object's rotation to the hit normal
            obj.transform.rotation = Quaternion.LookRotation(hit.normal);

            distance = Vector3.Distance(this.transform.position, hit.point);
            pastDistances.Add(distance);

            // Remove the oldest value if the list exceeds max size
            if (pastDistances.Count > 5)
            {
                pastDistances.RemoveAt(0); // Remove the value at index 0
            }
            moveObject(distance);
        }
        else
        {
            Debug.Log("No hit detected.");
        }

    }

    private void moveObject(float distance)
    {
        Vector3 moveDirection = anchor.transform.forward;

        obj.transform.position = anchor.transform.position + moveDirection * distance;

        float scale = distance / 2;
        obj.transform.localScale = new Vector3(scale, scale, scale);

        Debug.Log("Obj moved to: " + obj.transform.position);
    }

    public float getDistance()
    {
        return pastDistances.Average(); 
    }

}
