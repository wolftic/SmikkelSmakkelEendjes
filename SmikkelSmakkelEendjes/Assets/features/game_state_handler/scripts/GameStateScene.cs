using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScene : MonoBehaviour {
    public GameStateType Type;
    
    public virtual void CustomStart(object props = null) 
    {
    }

    public virtual void Open()
    {
        PopupManager.Instance.AddPopupToQueue(Popups.EXAMPLE_POPUP);
    }

    public virtual void Close()
    {
        PopupManager.Instance.ClosePopup(Popups.EXAMPLE_POPUP);
    }
}
