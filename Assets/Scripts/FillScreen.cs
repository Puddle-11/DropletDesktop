using UnityEngine;

public class FillScreen : MonoBehaviour
{
    public float factor;
    private void Update()
    {
        transform.position = Camera.main.transform.position + Vector3.forward * 1;
        transform.localScale = new Vector3(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize, 1) * factor;
    }

}
