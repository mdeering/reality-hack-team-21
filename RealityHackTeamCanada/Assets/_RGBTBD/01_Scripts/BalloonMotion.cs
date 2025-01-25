using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BalloonMotion : MonoBehaviour
{
    [Header("Random Motion Settings")]
    public float minDirectionChangeInterval = 0.5f;
    public float maxDirectionChangeInterval = 2f;
    public float forceStrength = 2f;     // Sideways “wind” force
    public float torqueStrength = 0.5f;  // Random rotation impulse

    // Shift balloon’s center of mass lower so it “prefers” upright
    public float bottomOffset = 0.5f;
    
    private Rigidbody rb;
    private float changeTimer;
    private float currentInterval;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Position the center of mass slightly below the balloon’s geometric center
        rb.centerOfMass = new Vector3(0, -bottomOffset, 0);

        // Pick an initial random time interval before the first direction change
        currentInterval = Random.Range(minDirectionChangeInterval, maxDirectionChangeInterval);
        changeTimer = currentInterval;
    }

    void FixedUpdate()
    {
        changeTimer -= Time.fixedDeltaTime;
        if (changeTimer <= 0f)
        {
            // Choose a random horizontal direction for the force
            Vector3 randomForceDir = new Vector3(
                Random.Range(-1f, 1f), 
                0f, 
                Random.Range(-1f, 1f)
            ).normalized;

            // Apply an impulse force in that direction
            rb.AddForce(randomForceDir * forceStrength, ForceMode.Impulse);

            // Apply a small random torque to create rotational wiggle
            Vector3 randomTorque = new Vector3(
                Random.Range(-1f, 1f), 
                Random.Range(-1f, 1f), 
                Random.Range(-1f, 1f)
            ).normalized;

            rb.AddTorque(randomTorque * torqueStrength, ForceMode.Impulse);

            // Reset the timer for the next random interval
            currentInterval = Random.Range(minDirectionChangeInterval, maxDirectionChangeInterval);
            changeTimer = currentInterval;
        }
    }
}