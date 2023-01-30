using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class MoveObject : MonoBehaviour
{
    [Tooltip("The Animation's Duration")]
    public float duration = 1f;
    
    [Tooltip("Insert an object with the position you want to target. It could be an empty object")]
    public GameObject targetPosition;
    private Vector3 originalPosition;
  
    private void Awake()
    {
        originalPosition = gameObject.transform.position;
    }
    public void MoveToTarget()
    {
        
        transform.DOMove(targetPosition.transform.position, duration);

    }

    public void MoveBackToOriginal()
    {
        
        transform.DOMove(originalPosition, duration);
        
    }
}
