using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class ScaleObject : MonoBehaviour
{
    [Tooltip("The Animation's Duration")]
    public float duration = 1f;
    
    public Vector3 targetScale;
    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = gameObject.transform.localScale;
    }
    public void ApplyTargetScale()
    {
        
        transform.DOScale(targetScale, duration);

    }

    public void ResetScale()
    {
        
        transform.DOScale(originalScale, duration);
        
    }
}
