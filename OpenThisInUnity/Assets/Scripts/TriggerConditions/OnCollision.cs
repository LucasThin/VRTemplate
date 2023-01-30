using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Calls functionality when a collision occurs. Requires a rigidbody on either the objects it's colliding with or itself.
/// </summary>

public class OnCollision : MonoBehaviour
{
    [Serializable] public class CollisionEvent : UnityEvent<Collision> { }
    [SerializeField] private bool _debugComments;
    // When the object enters a collision
    public CollisionEvent OnEnter = new CollisionEvent();

    // When the object exits a collision
    public CollisionEvent OnExit = new CollisionEvent();

    private void OnCollisionEnter(Collision collision)
    {
        if(_debugComments)Debug.Log($"{collision} has entered collision");
        OnEnter.Invoke(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        if(_debugComments)Debug.Log($"{collision} has exited collision");
        OnExit.Invoke(collision);
    }

    private void OnValidate()
    {
        if (TryGetComponent(out Collider collider))
            collider.isTrigger = false;
        
        if (TryGetComponent(out Rigidbody rigidbody))
            rigidbody.useGravity = false;
    }
}
