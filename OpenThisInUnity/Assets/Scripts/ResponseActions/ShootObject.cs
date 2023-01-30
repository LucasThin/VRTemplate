using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// Apply forward force to instantiated prefab
/// </summary>
public class ShootObject : MonoBehaviour
{
    [Tooltip("The object that's going to be shot e.g a bullet")]
    public GameObject ObjectToBeShot = null;

    [Tooltip("The point that the object is shooting from")]
    public Transform startPoint = null;

    [Tooltip("The speed at which the object is shot")]
    public float shootSpeed = 1.0f;

    public void Fire()
    {
        GameObject newObject = Instantiate(ObjectToBeShot, startPoint.position, startPoint.rotation);

        if (newObject.TryGetComponent(out Rigidbody rigidBody))
            ApplyForce(rigidBody);
    }

    private void ApplyForce(Rigidbody rigidBody)
    {
        Vector3 force = startPoint.forward * shootSpeed;
        rigidBody.AddForce(force);
    }
}
