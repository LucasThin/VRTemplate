using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class MoveObject : MonoBehaviour
{
    [Tooltip("The Animation's Duration")]
    public float duration = 1f;
    
    [Tooltip("Insert an object with the position you want to target. It could be an empty object")]
    public Vector3 targetPosition;
    private Vector3 originalPosition;
    public EasingType _easingType;
    private int mode = 1;
    public enum EasingType
    {
        Linear = 1,
        EaseIn = 2,
        EaseInAndOut = 3,
        EaseOut = 4
        
    }
    private void Awake()
    {
        originalPosition = gameObject.transform.position;

        
    }

    public void MoveToTarget()
    {
        if (_easingType == EasingType.Linear)
        {
            transform.DOMove(targetPosition, duration).SetEase(Ease.Linear);
        }
        
        if (_easingType == EasingType.EaseIn)
        {
            transform.DOMove(targetPosition, duration).SetEase(Ease.InCubic);
        }

        if (_easingType == EasingType.EaseInAndOut)
        {
            transform.DOMove(targetPosition, duration).SetEase(Ease.InOutQuint);
        }

        if (_easingType == EasingType.EaseOut)
        {
            transform.DOMove(targetPosition, duration).SetEase(Ease.OutCubic);
            
        }
    }

    public void MoveBackToOriginal(int i)
    {
        if (_easingType == EasingType.Linear)
        {
            transform.DOMove(originalPosition, duration).SetEase(Ease.Linear);
        }
        
        if (_easingType == EasingType.EaseIn)
        {
            transform.DOMove(originalPosition, duration).SetEase(Ease.InCubic);
        }

        if (_easingType == EasingType.EaseInAndOut)
        {
            transform.DOMove(originalPosition, duration).SetEase(Ease.InOutQuint);
        }

        if (_easingType == EasingType.EaseOut)
        {
            transform.DOMove(originalPosition, duration).SetEase(Ease.OutCubic);
            
        }
    }
}
