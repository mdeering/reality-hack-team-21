using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BalloonFloating : MonoBehaviour
{
    [Header("Floating Settings")]
    [Tooltip("Balloon will float without gravity or random forces.")]

    public float smallUpwardForce = 8f;
    public float bottomOffset = 0.5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Turn off gravity so it floats
        rb.centerOfMass = new Vector3(0, -bottomOffset, 0);
    }

    // No random forces in FixedUpdate
    private void FixedUpdate()
    {
        // If you want it perfectly still, do nothing here,
        // or gently nudge upward if needed:
        rb.AddForce(Vector3.up * smallUpwardForce, ForceMode.Force);
    }

    // Example collision behavior: balloon will “glide” along walls
    private void OnCollisionStay(Collision collision)
    {
        // This simplistic approach just zeroes out velocity
        // into the collision surface, letting it slide tangentially.
        // Not perfect, but it keeps the balloon from getting stuck.
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 normal = contact.normal;
            Vector3 velocity = rb.linearVelocity;
            
            // Remove the component of velocity toward the wall
            float dot = Vector3.Dot(velocity, normal);
            if (dot < 0f)
            {
                Vector3 cancelIntoWall = normal * dot;
                rb.linearVelocity = velocity - cancelIntoWall;
            }
        }
    }
}