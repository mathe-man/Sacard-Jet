using System.Numerics;
using Raylib_cs;
namespace SacardJet;

public class SacardJetEngine
{
    private readonly string Name = "SacardJet Engine";

    public readonly float G;
    public readonly float AirResistance;

    public List<Body> Bodies;

    //TODO add Sumaary comment to engine constructor
    public SacardJetEngine(string name = "SacardJet Engine", float g = 6.6743e-11f, float airResistance = 0f, List<Body>? bodies = null, bool initMessage = false)
    {
        Name = name;
        
        G = g;
        AirResistance = airResistance;
        Bodies = bodies ?? new List<Body>();
        
        if (initMessage)
        {Console.WriteLine($"SacardJetEngine '{Name}' initMessage, initialized with G={G}, AirResitance={AirResistance}, and {Bodies.Count} Bodies");}
    }

    /// <summary>
    /// Update method update the state of each bodies in the current bodies list of the instance
    /// </summary>
    /// <returns>Bodies list after the update</returns>
    public List<Body> Update()
    {        
        //Calculate the force and velocity of each objects
        foreach (var body in Bodies)
        {
            body.Force = Vector3.Zero;
            Vector3 acceleration = Vector3.Zero;

            foreach (var other in Bodies)
            {
                if (!body.Equals(other))
                {
                    
                    //Local variables
                    //Distance between body and othe
                    float d = Vector3.Distance(body.Position, other.Position);
                    float dx = other.Position.X - body.Position.X;
                    float dy = other.Position.Y - body.Position.Y;
                    float dz = other.Position.Z - body.Position.Z;
                    
                    //Force and force vector
                    float force = G * body.Mass * other.Mass / (d * d);
                    Vector3 forceVec = new Vector3(
                        force * (dx / d),
                        force * (dy / d),
                        force * (dz / d)
                    );
                    
                    forceVec.X = !float.IsNaN(forceVec.X) ? forceVec.X : 0;
                    forceVec.Y = !float.IsNaN(forceVec.Y) ? forceVec.Y : 0;
                    forceVec.Z = !float.IsNaN(forceVec.Z) ? forceVec.Z : 0;
                    
                    body.Force += forceVec;
                    body.Acceleration = body.Force / body.Mass;

                }
            }
        }
        
        
        //Update every position with the velocity
        foreach (var body in Bodies)
        {
            body.Position += body.Velocity;
        }
        
        
        return Bodies;
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


    //TODO add summary comment to Body constructor and his other methods
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
