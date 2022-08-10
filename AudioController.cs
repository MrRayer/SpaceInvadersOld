using System.Media;

namespace SpaceInvaders
{
    internal class AudioController
    {
        static SoundPlayer shot = new SoundPlayer(@"C:\csPractice\SpaceInvaders\sound\laser.wav");
        static SoundPlayer explosion = new SoundPlayer(@"C:\csPractice\SpaceInvaders\sound\explosion.wav");
        public static void Shot() { shot.Play(); }
        public static void Explosion() { explosion.Play(); }
    }
}
