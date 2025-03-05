using UnityEngine;

public class QuitButton : CollapseToggle
{
    public override void Click()
    {
        TransparentWindow.QuitApplication();
    }



 
}
