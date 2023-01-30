using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Calls functionality when a trigger occurs
/// </summary>

[RequireComponent(typeof(Rigidbody))]
public class OnTrigger : MonoBehaviour
{
    [Tooltip("Only the objects with this tag name can trigger this. Can be left blank.")]
    public string requiredTag = string.Empty;

    [Serializable] public class TriggerEvent : UnityEvent<Collider> { }

    [SerializeField] private bool _debugComments;
    private bool _onTriggerStayCalled = false;
    
    // When the object enters a collision
    public TriggerEvent OnEnter = new TriggerEvent();
    
    // When the object stays a collision
    public TriggerEvent OnStay = new TriggerEvent();

    // When the object exits a collision
    public TriggerEvent OnExit = new TriggerEvent();


    private void OnTriggerEnter(Collider other)
    {
        if (CanTrigger(other.gameObject))
        {
            if(_debugComments) Debug.Log($"{other} has entered the Trigger");
            OnEnter?.Invoke(other);
        }
            
    }

    private void OnTriggerStay(Collider other)
    {
        if (CanTrigger(other.gameObject))
        {
            if (!_onTriggerStayCalled)
            {
                Debug.Log($"{other} is staying in the Trigger");
                _onTriggerStayCalled = true;
            }
            
            OnStay?.Invoke(other);
        }
           
    }
    private void OnTriggerExit(Collider other)
    {
        if (CanTrigger(other.gameObject))
        {
            if(_debugComments) Debug.Log($"{other} has exited the Trigger");
            _onTriggerStayCalled = false;
            OnExit?.Invoke(other);
        }
            
    }

    private bool CanTrigger(GameObject otherGameObject)
    {
        if(requiredTag != string.Empty)
        {
            return otherGameObject.CompareTag(requiredTag);
        }
        else
        {
            return true;
        }
    }

    private void OnValidate()
    {
        if (TryGetComponent(out Collider collider))
            collider.isTrigger = true;

        if (TryGetComponent(out Rigidbody rigidbody))
            rigidbody.useGravity = false;
    }
}
