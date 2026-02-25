namespace Trellcko.Gameplay.MiniGame
{
    public interface IMiniGame
    {
        MiniGameType MinigameType { get; }
        void StartGame();
        void FinishGame(bool success);
    }
}