using Unity.VisualScripting;
using UnityEngine;

public class ScreenAnchor : MonoBehaviour
{
    [SerializeField] private Vector2 position;
    [SerializeField] private AnchorDir anchor;

    public enum AnchorDir
    {
        LeftEdge,
        RightEdge,
        TopEdge,
        BottomEdge,

        TRCorner,
        TLCorner,
        BRCorner,
        BLCorner
    }
    void Awake()
    {
        transform.localPosition = GetAnchorPosition(anchor) + position;
    }

  
    public static Vector2 GetAnchorPosition(AnchorDir _anchor)
    {
        Vector2 minMaxY;
        Vector2 minMaxX;
        minMaxY = new Vector2(-Camera.main.orthographicSize, Camera.main.orthographicSize);
        minMaxX.y = Camera.main.aspect * -Camera.main.orthographicSize;
        minMaxX.x = -minMaxX.y;
        switch (_anchor)
        {
            case AnchorDir.LeftEdge:
                return new Vector2(minMaxX.y,0);
            case AnchorDir.RightEdge:
                return new Vector2(minMaxX.x, 0);
            case AnchorDir.TopEdge:
                return new Vector2(0, minMaxY.y);
            case AnchorDir.BottomEdge:
                return new Vector2(0, minMaxY.x);
            case AnchorDir.TRCorner:
                return new Vector2(minMaxX.x, minMaxY.y);
            case AnchorDir.TLCorner:
                return new Vector2(minMaxX.y, minMaxY.y);
            case AnchorDir.BRCorner:
                return new Vector2(minMaxX.y, minMaxY.x);
            case AnchorDir.BLCorner:
                return new Vector2(minMaxX.x, minMaxY.x);

        }
        return Vector2.zero;
    }
}
