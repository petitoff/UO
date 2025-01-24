using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/HitDecision")]
public class HitDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return CheckIfWasHit(controller);
    }

    private bool CheckIfWasHit(StateController controller)
    {
        bool wasHit = controller.healthComponent.CurrentHealth < controller.PreviousHealth;
        controller.PreviousHealth = controller.healthComponent.CurrentHealth;

        return wasHit;
    }
}