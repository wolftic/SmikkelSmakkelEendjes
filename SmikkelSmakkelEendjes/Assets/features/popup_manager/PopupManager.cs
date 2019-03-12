using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : Singleton<PopupManager> {
    private List<PopupBase> _popups = new List<PopupBase>();
    private List<PopupBase> _queue = new List<PopupBase>();
    
    /// <summary>
    /// Register a popup for availability.
    /// </summary>
    /// <param name="popup"></param>
    public void RegisterPopup(PopupBase popup) 
    {
        _popups.Add(popup);
        popup.gameObject.SetActive(false);
    }

    /// <summary>
    /// Register that this popup has been closed.
    /// </summary>
    /// <param name="popup"></param>
    public void RegisterClosed(PopupBase popup)
    {
        popup.gameObject.SetActive(false);
    }
    
    /// <summary>
    /// Find and open popup
    /// </summary>
    /// <param name="popupname">name of popup</param>
    /// <param name="_object">data</param>
    public void AddPopupToQueue(string popupname, object _object = null) 
    {
        PopupBase popup = GetPopupByName(popupname);
        
        if (popup == null) 
        {
            Debug.LogWarning("Couldn't find and add popup: " + popupname + " to queue.");            
            return;
        }

        AddPopupToQueue(popup);
    }

    /// <summary>
    /// Open popup
    /// </summary>
    /// <param name="popup">popup</param>
    /// <param name="_object">data</param>
    public void AddPopupToQueue(PopupBase popup, object _object = null) 
    {
        _queue.Add(popup);
        popup.CustomStart(_object);

        popup.gameObject.SetActive(true);
        
        popup.Open();
    }

    /// <summary>
    /// Find and force close popup
    /// </summary>
    /// <param name="popupname">name</param>
    public void ClosePopup(string popupname) 
    {
        PopupBase popup = null;

        for (int i = 0; i < _queue.Count; i++) 
        {
            if (_queue[i].PopupName == popupname) popup = _queue[i];
        }

        if (popup == null) return;

        ClosePopup(popup);
    }

    /// <summary>
    /// Force close popup
    /// </summary>
    /// <param name="popup">popup</param>
    public void ClosePopup(PopupBase popup) 
    {
        popup.Close();
        _queue.Remove(popup);
    }

    /// <summary>
    /// Close last opened popup
    /// </summary>
    public void CloseLastPopup()
    {
        if (_queue.Count == 0) return;

        PopupBase popup = GetLastPopup();

        ClosePopup(popup);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            CloseLastPopup();
        }
    }

    private PopupBase GetLastPopup() 
    {
        for (int i = _queue.Count - 1; i >= 0; i--)
        {
            if (_queue[i] != null) return _queue[i];
        }

        return null;
    }

    private PopupBase GetPopupByName(string name) 
    {
        for (int i = 0; i < _popups.Count; i++) 
        {
            if (_popups[i].PopupName == name) return _popups[i];
        }

        return null;
    }
}
