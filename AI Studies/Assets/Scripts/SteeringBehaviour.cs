using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour
{
    public abstract Vector2 Calculate(MovingEntity entity);

    public virtual void DrawGizmos() { }
}
