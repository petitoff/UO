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
        IHealth health = controller.healthComponent;
        if (health != null)
        {
            // Debug.Log($"HPDecision: Current health = {health.CurrentHealth}, Escape threshold = {health.MaxHealth * 0.25f}");
            return health.CurrentHealth <= (health.MaxHealth * 0.25f);
        }

        Debug.LogWarning("HPDecision: IHealth component not found.");
        return false;
    }
}