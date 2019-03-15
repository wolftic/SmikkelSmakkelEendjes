using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour {
    private Player player;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        player = transform.parent.GetComponent<Player>();
    }

    public void TriggerBite()
    {
        player.AnimationDoBite();
    }
}
