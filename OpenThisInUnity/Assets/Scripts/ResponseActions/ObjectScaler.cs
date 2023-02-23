using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script scales an object based on the distance between two gameobjects.
public class ObjectScaler : MonoBehaviour
{
    public GameObject object1; // the first game object
    public GameObject object2; // the second game object

    public float scaleFactor = 1.0f; // the scaling factor

    private float initialDistance; // the initial distance between the two game objects
    private Vector3 initialScale; // the initial scale of the object

    void Start()
    {
        initialDistance = Vector3.Distance(object1.transform.position, object2.transform.position); // save the initial distance between the two game objects
        initialScale = transform.localScale; // save the initial scale of the object
    }

    void Update()
    {
        float currentDistance = Vector3.Distance(object1.transform.position, object2.transform.position); // get the current distance between the two game objects
        float scaleRatio = currentDistance / initialDistance; // calculate the scaling ratio based on the current distance and the initial distance

        transform.localScale = initialScale * scaleRatio * scaleFactor; // scale the object based on the scaling ratio and the scaling factor
    }
}