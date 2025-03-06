using UnityEngine;

public class MouseMaterial : MonoBehaviour
{
   [SerializeField] private Material mat;
    [SerializeField] private Renderer rend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend.material = new Material(mat);
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.SetVector("_MousePos", TransparentWindow.GetMouseWorldPosition());
    }
}
