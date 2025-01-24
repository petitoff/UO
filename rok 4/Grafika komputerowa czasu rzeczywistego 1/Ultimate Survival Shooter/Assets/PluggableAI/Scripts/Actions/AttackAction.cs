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
                // Check the distance between the tank and the player
                float distanceToPlayer = Vector3.Distance(controller.transform.position, hit.transform.position);
                Debug.Log($"AttackAction: Player in range! Distance: {distanceToPlayer}");

                // If the player is very close, ignore SphereCast and force a shot
                if (distanceToPlayer <= controller.enemyStats.lookSphereCastRadius + 1f)
                {
                    Debug.Log("AttackAction: Player very close, shooting.");
                    controller.tankShooting.Fire(controller.enemyStats.attackForce, controller.enemyStats.attackRate);
                    return;
                }

                // Standard countdown and shooting
                if (controller.CheckIfCountDownElapsed(controller.enemyStats.attackRate))
                {
                    Debug.Log("AttackAction: Countdown finished, calling Fire.");
                    controller.tankShooting.Fire(controller.enemyStats.attackForce, controller.enemyStats.attackRate);
                }
                else
                {
                    Debug.Log("AttackAction: Countdown still ongoing, cannot shoot.");
                }
            }
            else
            {
                Debug.Log($"AttackAction: Hit an object, but not the player. Tag: {hit.collider.tag}");
            }
        }
        else
        {
            // Additional close-range check in case SphereCast fails
            float fallbackDistance = Vector3.Distance(controller.transform.position, controller.chaseTarget.position);
            if (fallbackDistance <= controller.enemyStats.attackRange * 0.5f)
            {
                Debug.Log("AttackAction: Player very close, shooting (fallback).");
                controller.tankShooting.Fire(controller.enemyStats.attackForce, controller.enemyStats.attackRate);
            }
            else
            {
                Debug.Log("AttackAction: SphereCast didn't hit anything and player is too far.");
            }
        }
    }
}