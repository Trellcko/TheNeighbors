using System;

namespace Trellcko.Gameplay.MiniGame
{
    public interface IMiniGame
    {
        bool IsPlaying { get; }
        MiniGameType MinigameType { get; }
        void StartGame();
        void FinishGame(bool success);
        event Action<bool, IMiniGame> Finished;
        void ExitGame();
    }
}