using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/RotDecision")]
public class RotDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return IsRotationComplete(controller);
    }

    private bool IsRotationComplete(StateController controller)
    {
        controller.navMeshAgent.isStopped = true;
        controller.navMeshAgent.updateRotation = false;

        if (controller.currentRotation >= 360f)
        {
            controller.navMeshAgent.isStopped = false;
            controller.navMeshAgent.updateRotation = true;
            return true;
        }

        return false;
    }
}