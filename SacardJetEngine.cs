using System.Numerics;
using Raylib_cs;
namespace SacardJet;

public class SacardJetEngine
{
    private readonly string Name = "SacardJet Engine";

    public readonly float G = 6.6743e-11f;
    public readonly float AirResitance = 0f;

    public List<Body> Bodies;

    public SacardJetEngine(string name = "SacardJet Engine", float g = 6.6743e-11f, float airResitance = 0f, List<Body>? bodies = null, bool initMessage = false)
    {
        Name = name;
        
        G = g;
        AirResitance = airResitance;
        Bodies = bodies ?? new List<Body>();
        
        if (initMessage)
        {Console.WriteLine($"SacardJetEngine '{Name}' initMessage, initialized with G={G}, AirResitance={AirResitance}, and {Bodies.Count} Bodies");}
    }

    /// <summary>
    /// Update method update the state of each bodies in the current bodies list of the instance
    /// </summary>
    /// <returns>Bodies list after the update</returns>
    public List<Body> Update()
    {        
    }
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


    public Body(Vector3 position, float radius, float mass, Vector3 velocity, Vector3 color)
    {
        if (radius <= 0 || mass <= 0)
        {
            throw new Exception("Body radius and mass must be greater than zero");
        }
        
        
        Position = position;
        Velocity = velocity;
        Force = new();
        
        Mass = mass;
        Radius = radius;
        
        Color = color;

    }
    
    public bool IsCollided(Body other) => Vector3.Distance(Position, other.Position) < Radius +  other.Radius;
    public static bool IsCollided(Body a, Body b) => a.IsCollided(b);

    public string StringInfo(string separator = ";")
    {
        //Info are: position, velocity, force, mass, radius
        string text = $"[position: {Position.X},{Position.Y},{Position.Z}]{separator}[velocity: {Velocity.X},{Velocity.Y},{Velocity.Z}]{separator}[force: {Force.X},{Force.Y},{Force.Z}]{separator}[mass: {Mass}]{separator}[radius: {Radius}]{separator}";
        return text;
    }
    
}
