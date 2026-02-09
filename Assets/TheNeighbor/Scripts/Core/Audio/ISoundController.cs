namespace Trellcko.Core.Audio
{
    public interface ISoundController
    {
        bool IsAmbiencPlaying { get; }
        Ambience CurrentAmbience { get; }
        void PlayAmbience(Ambience ambience);
        void PlayShockMoment(bool playAfterAmbien = false);
        void StopPlayingAmbience();
        void PlayMonsterSound(MonsterSound monsterSound);
    }
}