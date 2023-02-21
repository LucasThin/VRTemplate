using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Within a range in seconds, call an event, continues for lifetime of object.
/// </summary>
public class OnTimedDelay : MonoBehaviour
{
    [SerializeField] private bool _debugComments;
    [Tooltip("Write in seconds, how long you want the delay to be")]
    public float TimeDelay = 1.0f;

    // Called once the wait is over
    public UnityEvent OnIntervalElapsed = new UnityEvent();

    private void Start()
    {
        StartCoroutine(IntervalRoutine());
    }

    private IEnumerator IntervalRoutine()
    {
        if(_debugComments) Debug.Log($"random timed delay is {TimeDelay}");
        yield return new WaitForSeconds(TimeDelay);

        PlayEvent();
        StartCoroutine(IntervalRoutine());
    }

    private void PlayEvent()
    {
        if(_debugComments)Debug.Log("Timed delay has Elapsed");
        OnIntervalElapsed.Invoke();
    }
}