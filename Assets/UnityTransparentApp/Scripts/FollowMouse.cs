using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] private float zDepth;
    private void Update()
    {
        transform.position = TransparentWindow.GetMouseWorldPosition();
    }
}
