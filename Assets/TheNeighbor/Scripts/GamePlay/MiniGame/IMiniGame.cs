using System;

namespace Trellcko.Gameplay.MiniGame
{
    public interface IMiniGame
    {
        MiniGameType MinigameType { get; }
        void StartGame();
        void FinishGame(bool success);
        event Action<bool, IMiniGame> Finished;
        void ExitGame();
    }
}