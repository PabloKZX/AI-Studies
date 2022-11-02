using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : SteeringBehaviour
{
    [SerializeField] float _maxDistanceToTarget = 5f;
    [SerializeField] GameObject _target;

    MovingEntity _entity;

    public override Vector2 Calculate(MovingEntity entity)
    {
        _entity = entity;
        if(Vector2.Distance(entity.transform.position, _target.transform.position) > _maxDistanceToTarget)
        {
            return Vector2.zero;
        }

        Vector2 desiredVelocity = (entity.transform.position - _target.transform.position).normalized * entity.maxSpeed;
        return desiredVelocity - entity.velocity;
    }

    public override void DrawGizmos()
    {
        if(!_target || !_entity)
        {
            return;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_target.transform.position, 0.5f);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_entity.transform.position, _maxDistanceToTarget);
    }
}
