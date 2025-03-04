using System.Runtime.CompilerServices;
using UnityEngine;

public class Sidebar : MonoBehaviour
{
    [SerializeField] private Toggle toggleButton;
    private bool internalState;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 targetPosition; 
  
    void Update()
    {
        if(internalState != toggleButton.enabled)
        {
            internalState = toggleButton.enabled;
        }
        UpdateTargetPosition();
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPosition.x, targetPosition.y, transform.position.z), moveSpeed * Time.deltaTime);
    }
    private void UpdateTargetPosition() 
    {
        if (internalState)
        {
            targetPosition = new Vector2(ScreenAnchor.GetAnchorPosition(ScreenAnchor.AnchorDir.RightEdge).x - transform.localScale.x / 2 + 0.1f, 0);
        }
        else
        {
            targetPosition = new Vector2(ScreenAnchor.GetAnchorPosition(ScreenAnchor.AnchorDir.RightEdge).x + transform.localScale.x, 0);
        }


    }
}
