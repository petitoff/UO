using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action
{
    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    private void Attack(StateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.attackRange, Color.red);

        // Check for a hit on the player using SphereCast
        if (Physics.SphereCast(controller.eyes.position, controller.enemyStats.lookSphereCastRadius,
                controller.eyes.forward, out hit, controller.enemyStats.attackRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                float distanceToPlayer = Vector3.Distance(controller.transform.position, hit.transform.position);
                
                if (distanceToPlayer <= controller.enemyStats.lookSphereCastRadius + 1f)
                {
                    controller.tankShooting.Fire(controller.enemyStats.attackForce, controller.enemyStats.attackRate);
                    return;
                }
                
                if (controller.CheckIfCountDownElapsed(controller.enemyStats.attackRate))
                {
                    controller.tankShooting.Fire(controller.enemyStats.attackForce, controller.enemyStats.attackRate);
                }
            }
        }
        else
        {
            float fallbackDistance = Vector3.Distance(controller.transform.position, controller.chaseTarget.position);
            if (fallbackDistance <= controller.enemyStats.attackRange * 0.5f)
            {
                controller.tankShooting.Fire(controller.enemyStats.attackForce, controller.enemyStats.attackRate);
            }
        }
    }
}