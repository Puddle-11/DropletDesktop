using UnityEngine;

public class FillScreen : MonoBehaviour
{
    public float factor;
    [SerializeField] private Toggle toggleButton;
    [SerializeField] private MeshRenderer mr;
    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        mr.enabled = toggleButton.enabled;
        transform.position = new Vector3( Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);
        transform.localScale = new Vector3(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize, 1) * factor;
    }

}
