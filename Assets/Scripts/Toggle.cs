using UnityEngine;

public class Toggle : MonoBehaviour, Clickable
{
    public bool enabled = false;
    public virtual void Click()
    {
        enabled = !enabled;
    }

    public int GetOrder()
    {
        return -1;
    }

    public bool GetOrderable()
    {
        return false;
    }

    public void Release()
    {
    }

    public void SetOrder(int _newOrder)
    {
    }

    public void UpdateOrder(int _increment)
    { 
    }

}
