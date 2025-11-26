using System;
using Trellcko.Gameplay.Interactable;

namespace Trellcko.Gameplay.QuestLogic
{
    public interface IInteractable
    {
        event Action Interacted;
        public InteractableOutline InteractableOutline { get; }
        bool IsInteractable { get; }
        bool TryInteract(out QuestItem getItem, QuestItem neededItem);
    }
}