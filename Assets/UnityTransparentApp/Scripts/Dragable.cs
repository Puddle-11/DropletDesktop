using System.Net.Http.Headers;
using UnityEngine;

public class Dragable : MonoBehaviour, Clickable
{

    private bool held;
    private int order = -1;
    private Vector2 offset;
    public bool GetHeld()
    {
        return held;
    }
    public void Click()
    {
        offset = (Vector2)transform.position - TransparentWindow.GetMouseWorldPosition();
        held = true;
    }
    public void Release()
    {
        held = false;
    }
    public int GetOrder()
    {
        return order;
    }

    public bool GetOrderable()
    {
        return true;
    }

    public void SetOrder(int _newOrder)
    {
        order = _newOrder;
        transform.position = new Vector3(transform.position.x, transform.position.y, _newOrder);
    }
    public void UpdateOrder(int _increment)
    {
        SetOrder(order + _increment);
    }

    public void Update()
    {
        if (held)
        {
            
            transform.position = TransparentWindow.GetMouseWorldPosition() + offset;
        }
    }
}
