using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class MoveObject : MonoBehaviour
{
    [Tooltip("The Animation's Duration in seconds")]
    public float duration = 1f;
    
    [Tooltip("Copy paste a the target position of a game object by right clicking on the game object's transform, copy position or write your own")]
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

        switch (_easingType)
        {
            case EasingType.Linear:
                transform.DOMove(targetPosition, duration).SetEase(Ease.Linear);
                break;
            case EasingType.EaseIn:
                transform.DOMove(targetPosition, duration).SetEase(Ease.InCubic);
                break;
            case EasingType.EaseInAndOut:
                transform.DOMove(targetPosition, duration).SetEase(Ease.InOutQuint);
                break;
            case EasingType.EaseOut:
                transform.DOMove(targetPosition, duration).SetEase(Ease.OutCubic);
                break;
            default:
                transform.DOMove(targetPosition, duration).SetEase(Ease.Linear);
                break;
                
        }
    }

    public void MoveBackToOriginal(int i)
    {

        switch (_easingType)
        {
            case EasingType.Linear:
                transform.DOMove(originalPosition, duration).SetEase(Ease.Linear);
                break;
            case EasingType.EaseIn:
                transform.DOMove(originalPosition, duration).SetEase(Ease.InCubic);
                break;
            case EasingType.EaseInAndOut:
                transform.DOMove(originalPosition, duration).SetEase(Ease.InOutQuint);
                break;
            case EasingType.EaseOut:
                transform.DOMove(originalPosition, duration).SetEase(Ease.OutCubic);
                break;
            default:
                transform.DOMove(originalPosition, duration).SetEase(Ease.Linear);
                break;
        }
    }
}
