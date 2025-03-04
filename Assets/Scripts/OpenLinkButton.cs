using UnityEngine;

public class OpenLinkButton : MonoBehaviour, Clickable
{
    [SerializeField] private string Link;

    public void Click()
    {
        System.Diagnostics.Process.Start(Link);
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
