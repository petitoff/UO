using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/HitDecision")]
public class HitDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return IfWasHit(controller);
    }

    private bool IfWasHit(StateController controller)
    {
        IHealth health = controller.GetComponent<IHealth>();

        if (health != null)
        {
            bool wasHit = health.CurrentHealth < controller.PreviousHealth;

            controller.PreviousHealth = health.CurrentHealth;

            return wasHit;
        }

        Debug.LogWarning("HitDecision: Nie znaleziono komponentu IHealth.");
        return false;
    }
}
