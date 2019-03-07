using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheckController : Singleton<HitCheckController>
{
    private const float ROTATION_ANGLE = 45f;
    private const float ANGLE_DIFFERENCE = 90f;

    public bool CheckHit(int playerId, Vector3 position, out Collider2D[] colliders)
    {
        Quaternion rotation = Quaternion.AngleAxis(playerId * ANGLE_DIFFERENCE + ROTATION_ANGLE, Vector3.forward);

        Debug.Log("rotation: " + rotation);

        colliders = Physics2D.OverlapBoxAll(position, Vector3.one, playerId * ANGLE_DIFFERENCE + ROTATION_ANGLE, LayerMask.NameToLayer("Food"));

        return (colliders.Length > 0);
    }
}
