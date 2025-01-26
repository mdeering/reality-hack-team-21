using UnityEngine;
using Meta.XR;

public class EnvRaycastManager : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private EnvironmentRaycastManager raycastManager;
    private float distance;
    public GameObject anchor;

    private float timegap = 0.1f;
    private float timeLeft;

    private void Start()
    {
        anchor = GameObject.Find("RightHandAnchor");
        raycastManager = gameObject.GetComponent<EnvironmentRaycastManager>();
        distance = 10f;
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
            moveObject(distance);

        }
        else
        {
            Debug.Log("No hit detected.");
        }

    }

    private void moveObject(float distance)
    {

        //distance = Mathf.Max(distance, 1f);
        Vector3 moveDirection = anchor.transform.forward;

        // Calculate the new position by adding the movement vector to the current position
        obj.transform.position = anchor.transform.position + moveDirection * distance;

        // Set the object's scale to the new value
        //obj.transform.localScale += Mathf.Pow(1.5f, distance);
        //float scale = Mathf.Pow(1f, distance);
        float scale = distance / 2;
        obj.transform.localScale = new Vector3(scale, scale, scale);

        //obj.transform.localScale = new Vector3(obj.transform.localScale.x * scale, obj.transform.localScale.y * scale, obj.transform.localScale.z * scale);

        Debug.Log("Obj moved to: " + obj.transform.position);
    }

    float getDistance()
    {
        return distance;
    }

}
