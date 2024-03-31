using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyDirection : BasicEnemy
{


    // Update is called once per frame
    protected override void Attack()
    {
        float distanceFromTarget = Vector2.Distance(transform.position, _target.transform.position);

        if (distanceFromTarget < maxRadius && distanceFromTarget > minRadius)
        {
            // Enemy animator calculations
            Vector2 distance = _target.transform.position - transform.position;
            animator.SetFloat("Horizontal", distance.x);
            animator.SetFloat("Vertical", distance.y);

        }
    }
}
