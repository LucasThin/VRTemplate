using UnityEngine;

/// <summary>
/// Spawn an object at a transform's position
/// </summary>
public class GenerateObject : MonoBehaviour
{
    [Tooltip("The object that will be generated")]
    public GameObject originalObject = null;

    [Tooltip("The transform where the object is generated")]
    public Transform generatePosition = null;

    public void Generate()
    {
        Instantiate(originalObject, generatePosition.position, generatePosition.rotation);
    }

    private void OnValidate()
    {
        if (!generatePosition)
            generatePosition = transform;
    }
}
