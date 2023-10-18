
using UnityEngine;

namespace Assets.Script.Interaction
{
    public interface IInteraction
    {
        bool IsInteractionWheel();
        void LookInteraction(GameObject who);
        void UseInteraction(GameObject who);
        void DefaultInteraction(GameObject who);
    }
}