using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheckController : Singleton<HitCheckController>
{
    private const float ROTATION_ANGLE = 45f;
    private const float ANGLE_DIFFERENCE = 90f;

    public bool CheckHit(Vector3 position, Vector3 size, out Collider2D[] colliders)
    {
        int layerMask = LayerMask.GetMask("Food");//LayerMask.NameToLayer("Food");

        colliders = Physics2D.OverlapBoxAll(position, size, 0f, layerMask);

        return (colliders.Length > 0);
    }
}
