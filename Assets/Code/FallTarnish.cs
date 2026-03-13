using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class FallTarnish : MonoBehaviour
{
    [SerializeField] private float embedDepth = 0.2f;
    private bool hasLandded = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        transform.rotation = Random.rotation;

        rb.AddForce(Vector3.down * Random.Range(5f, 15F), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasLandded && collision.gameObject.CompareTag("Floor"))
        {
            Stick(collision);
        }
    }

    void Stick(Collision collision)
    {
        hasLandded = true;

        rb.isKinematic = true;
        rb.detectCollisions = false;

        transform.position += transform.forward * embedDepth;

        transform.SetParent(collision.transform);
    }
}
