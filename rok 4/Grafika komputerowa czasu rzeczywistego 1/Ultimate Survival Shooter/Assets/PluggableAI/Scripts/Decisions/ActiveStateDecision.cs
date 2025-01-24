using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ActiveState")]
public class ActiveStateDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return controller.chaseTarget.GetComponent<IHealth>().CurrentHealth > 0f;
    }
}