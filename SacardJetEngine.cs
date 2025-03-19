using System.Numerics;
using Raylib_cs;
namespace SacardJet;

public class SacardJetEngine
{
    private readonly string Name = "SacardJetEngine";

    public readonly float G;
    public readonly float AirResitance;
}


public class Body
{
    public Vector3 Position { get; set; }
    public Vector3 Velocity { get; set; }
    public Vector3 Acceleration { get; set; }
    public Vector3 Force { get; set; }
    
    public float Mass { get; set; }
    public float Radius { get; set; }
    
    public Vector3 Color { get; set; }
    
        
}
