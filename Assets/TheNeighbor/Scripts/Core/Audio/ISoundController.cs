namespace Trellcko.Core.Audio
{
    public interface ISoundController
    {
        void PlayOst(Ost ost);
        void PlayShockMoment(bool playAfterAmbien = false);
        void StopPlayingAmbience();
        void PlayMonsterSound(MonsterSound monsterSound);
    }
}