using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;
public class MoveObjectBy : MonoBehaviour
{

    //public float endValue = 1f;
    [Tooltip("Copy paste a the target position of a game object by right clicking on the game object's transform, copy position or write your own")]
    private int mode = 1;
    public MoveBy moveBy;
    
    [Tooltip("The Animation's Duration in seconds")]
    public float speed = 1f;
    private Vector3 originalPosition;
    public enum MoveBy
    {
        left = 1,
        right = 2,
        forward = 3,
        back = 4,
        up = 5,
        down =6
    }
    private void Awake()
    {
      
        originalPosition = gameObject.transform.position;
        
    }

    public void MoveObject()
    {
        originalPosition = this.transform.position;

        switch (moveBy)
        {
            case MoveBy.left:
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                break;
            case MoveBy.right:
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                break;
            case MoveBy.up:
                transform.Translate(Vector3.up * Time.deltaTime * speed);
                break;
            case MoveBy.down:
                transform.Translate(Vector3.down * Time.deltaTime * speed);
                break;
            case MoveBy.forward:
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                break;
            case MoveBy.back:
                transform.Translate(Vector3.back * Time.deltaTime * speed);
                break;
            default:
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                break;
                
        }
    }

    
}
