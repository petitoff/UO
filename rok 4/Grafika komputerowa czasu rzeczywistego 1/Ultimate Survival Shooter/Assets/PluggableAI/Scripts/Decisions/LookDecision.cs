using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return CheckForPlayerVisibility(controller);
    }

    private bool CheckForPlayerVisibility(StateController controller)
    {
        if (!controller.eyes || !controller.enemyStats)
        {
            return false;
        }

        // Draw debug ray for visualization
        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.lookRange,
            Color.green);

        // Perform SphereCast to detect the player
        if (Physics.SphereCast(controller.eyes.position, controller.enemyStats.lookSphereCastRadius,
                controller.eyes.forward, out RaycastHit hit, controller.enemyStats.lookRange) &&
            hit.collider.CompareTag("Player"))
        {
            controller.chaseTarget = hit.transform;
            return true;
        }

        return false;
    }
}