using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class RotateObject : MonoBehaviour
{
    [Tooltip("The Animation's Duration")]
    public float duration = 1f;
    
    [Tooltip("Insert an object with the rotation you want to target. It could be an empty object")]
    public GameObject targetRotation;
    private Vector3 originalRotation;
    
    private void Awake()
    {
        originalRotation = gameObject.transform.rotation.eulerAngles;
    }
    public void Rotate()
    {
        
        transform.DORotate(targetRotation.transform.rotation.eulerAngles, duration);

    }

    public void RotateBack()
    {
        
        transform.DORotate(originalRotation, duration);
        
    }
}
