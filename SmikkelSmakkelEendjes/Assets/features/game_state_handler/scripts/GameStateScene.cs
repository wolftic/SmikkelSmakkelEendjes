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
    }

    public virtual void Close()
    {
    }
}
