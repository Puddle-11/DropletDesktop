using UnityEngine;

public class DisplayToggle : MonoBehaviour, Clickable
{
    public int coroDisplay;
    public void Click()
    {

        TransparentWindow.UpdateCurrentWindow(coroDisplay);

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
