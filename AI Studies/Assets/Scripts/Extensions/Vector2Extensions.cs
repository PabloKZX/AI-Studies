using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2Extensions
{
    public static Vector2 Perp(this Vector2 vector)
    {
        return new Vector2(vector.y, -vector.x);
    }
}
