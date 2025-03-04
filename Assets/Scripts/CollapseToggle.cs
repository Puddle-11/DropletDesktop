using UnityEngine;
using System.Collections;

public class CollapseToggle : Toggle
{
    [SerializeField] private Toggle toggleObject;
    private bool internalState;
    [SerializeField] private float lerpTime;
    [SerializeField] private AnimationCurve lerpCurve;
    [SerializeField] public Vector3 close;
    [SerializeField] private Vector3 open;
    private bool running;
    Coroutine currEnum;
    private bool savedState;
    private void Update()
    {
        if (internalState != toggleObject.enabled)
        {
            internalState = toggleObject.enabled;
            if (!internalState)
            {
                //savedState = enabled;
               // enabled = false;

                if (running)
                {
                    StopLerp();
                }

                currEnum = StartCoroutine(LerpPosition(lerpTime, close, transform.localPosition));
            }
            else
            {
                //enabled = savedState;
                if (running)
                {
                    StopLerp();
                }
                currEnum = StartCoroutine(LerpPosition(lerpTime, open, transform.localPosition));
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currEnum = StartCoroutine(LerpPosition(lerpTime, close, transform.localPosition));
    }


    private void StopLerp()
    {
        StopCoroutine(currEnum);
        running = false;
    }

    private IEnumerator LerpPosition(float _time, Vector3 targetPosition, Vector3 startingPosition)
    {

        running = true;
        float timer = 0;
        while (timer < _time)
        {

            timer += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(startingPosition, targetPosition, lerpCurve.Evaluate(timer / _time));
            yield return null;
        }
        running = false;
    }
}
