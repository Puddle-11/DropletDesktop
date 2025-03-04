using UnityEngine;

public interface Clickable 
{
    public void Click();
    public void Release();
    public bool GetOrderable();
    public void UpdateOrder(int _increment);
    public int GetOrder();
    public void SetOrder(int _newOrder);

}
