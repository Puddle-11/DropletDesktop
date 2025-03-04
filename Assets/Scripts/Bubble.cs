using System.Collections;
using UnityEngine;
public class Bubble : MonoBehaviour
{
    public Toggle toggleButton;
    [SerializeField] private float lerpTime;
    private bool internalState;
    [SerializeField] private AnimationCurve lerpCurve;
    private float LastY;
    public float TargetY;
    private bool running;
    Coroutine currEnum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TargetY = ScreenAnchor.GetAnchorPosition(ScreenAnchor.AnchorDir.TopEdge).y + transform.localScale.y/2;
        currEnum = StartCoroutine(LerpPosition(lerpTime, new Vector3(transform.position.x, TargetY, transform.position.z), transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        if(internalState!= toggleButton.enabled)
        {
            internalState = toggleButton.enabled;
            if(internalState == false)
            {
                if (running)
                {
                    StopLerp();
                }
                else
                {
                    LastY = transform.position.y;

                }
               currEnum = StartCoroutine(LerpPosition(lerpTime, new Vector3(transform.position.x, TargetY, transform.position.z), transform.position));
            }
            else
            {
                if (running)
                {
                    StopLerp();
                }
                currEnum = StartCoroutine(LerpPosition(lerpTime, new Vector3(transform.position.x, LastY, transform.position.z), transform.position));
            }
        }
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
            transform.position = Vector3.Lerp(startingPosition, targetPosition, lerpCurve.Evaluate(timer/_time));
            yield return null;
        }
        running = false;
    }
}
