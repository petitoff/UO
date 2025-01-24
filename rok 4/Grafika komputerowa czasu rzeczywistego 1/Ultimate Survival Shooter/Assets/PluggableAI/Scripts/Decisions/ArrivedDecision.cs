using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ArrivedDecision")]
public class ArrivedDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return CheckIfArrived(controller);
    }

    private bool CheckIfArrived(StateController controller)
    {
        return controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance;
    }
}
