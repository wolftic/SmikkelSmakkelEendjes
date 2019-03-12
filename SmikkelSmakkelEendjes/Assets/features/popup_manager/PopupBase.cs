using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBase : MonoBehaviour {

    public string PopupName = "";

    private void Awake()
    {
        PopupManager.Instance.RegisterPopup(this);
    }

    /// <summary>
    /// Gets activated before object is turned on.
    /// </summary>
    /// <param name="_object">data send with the popup</param>
	public virtual void CustomStart(object _object = null) 
    {
    }

    /// <summary>
    /// Gets activated after object is turned on.
    /// </summary>
    public virtual void Open()
    {
    }

    /// <summary>
    /// Gets called before object is turned off
    /// </summary>
    public virtual void Close() 
    {
        PopupManager.Instance.RegisterClosed(this);
    }
}
