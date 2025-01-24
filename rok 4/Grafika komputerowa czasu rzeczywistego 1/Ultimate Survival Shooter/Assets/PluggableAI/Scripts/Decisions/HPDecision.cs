using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/HPDecision")]
public class HPDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return CheckHealth(controller);
    }

    private bool CheckHealth(StateController controller)
    {
        return controller.healthComponent.CurrentHealth <= (controller.healthComponent.MaxHealth * 0.25f);
    }
}