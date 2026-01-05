namespace Trellcko.Core.Audio
{
    public interface ISoundController
    {
        void PlayOst(Ost ost);
        void PlayShockMoment();
        void StopPlayingAmbience();
        void PlayMonsterSound(MonsterSound monsterSound);
    }
}