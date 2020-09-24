using System.Security.Cryptography.X509Certificates;
using Godot;

namespace Casanova.core.types
{
    public class ParticleInfo
    {
        public Texture Texture;
        public Curve SizeCurve;
        public float Size;
        public float Velocity;
        public Vector2 Direction;
        public int Amount;
    }
    
    public abstract class Particles : CPUParticles2D
    {
        public ParticleInfo Info;
        public Vector2 Pos;
    }
}
