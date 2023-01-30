using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Calls events for when the velocity of this objects breaks the begin and end threshold
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class OnVelocity : MonoBehaviour
{
    [SerializeField] private bool _debugComments;
    [Tooltip("The speed calls the begin event")]
    public float beginThreshold = 1.25f;

    [Tooltip("The speed calls the end event")]
    public float endThreshold = 0.25f;

    [Serializable] public class VelocityEvent : UnityEvent<MonoBehaviour> { }

    // Begin threshold has been broken
    public VelocityEvent OnBegin = new VelocityEvent();

    // End threshold has been broken
    public VelocityEvent OnEnd = new VelocityEvent();

    private Rigidbody rigidBody = null;
    private bool hasBegun = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckVelocity();
    }

    private void CheckVelocity()
    {
        float speed = rigidBody.velocity.magnitude;
        hasBegun = HasVelocityBegun(speed);

        if (HasVelcoityEnded(speed))
            Reset();
    }

    private bool HasVelocityBegun(float speed)
    {
        if (hasBegun)
            return true;

        bool beginCheck = speed > beginThreshold;

        if (beginCheck)
        {
            if(_debugComments) Debug.Log("Velocity began");
            OnBegin.Invoke(this); 
        }
               

        return beginCheck;
    }

    private bool HasVelcoityEnded(float speed)
    {
        if (!hasBegun)
            return false;

        bool endCheck = speed < endThreshold;

        if (endCheck)
        {
            if(_debugComments) Debug.Log("Velocity ended");
            OnEnd.Invoke(this);
        }
        
        return endCheck;
    }

    public void Reset()
    {
        hasBegun = false;
    }
}
