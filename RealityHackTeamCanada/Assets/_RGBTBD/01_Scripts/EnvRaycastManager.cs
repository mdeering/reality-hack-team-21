using UnityEngine;
using Meta.XR;

public class EnvRaycastManager : MonoBehaviour
{
    [SerializeField] private GameObject sphere;
    [SerializeField] private EnvironmentRaycastManager raycastManager;

    private void Update()
    {
        //environmentRaycastManager.Raycast

        //sphere.position = EnvironmentRaycastHit.point
        //move to hit point
        //moveObject();
    }
    /*
    private void moveObject()
    {
        // Cast a ray from the center of the camera's view
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;

        // Perform raycast using EnvironmentRaycastManager
        if (raycastManager.Raycast(ray, out hit, Mathf.Infinity))
        {
            // Move the object to the hit point
            sphere.transform.position = hit.point;

            // Optionally, align the object's rotation to the hit normal
            sphere.transform.rotation = Quaternion.LookRotation(hit.normal);

            Debug.Log("Object moved to: " + hit.point);
        }
        else
        {
            Debug.Log("No hit detected.");
        }
    
    }
    */
}
