using Raylib_cs;
using System.Numerics;

namespace SacardJet;

public class JetDrawer
{
    
    
    public static void Start()
    {

        Raylib.InitWindow(800, 600, "Raylib-cs 0 Example");
        Raylib.SetTargetFPS(60);

        // Définition d'une caméra 3D
        Camera3D camera = new Camera3D();
        camera.Position = new Vector3(10, 10, 10); // Position de la caméra
        camera.Target = new Vector3(0, 0, 0); // Point qu'elle regarde
        camera.Up = new Vector3(0, 1, 0); // Direction "vers le haut"
        camera.FovY = 320.0f; // Champ de vision en degrés
        camera.Projection = CameraProjection.Perspective; // Mode de projection

        while (!Raylib.WindowShouldClose())
        {
            

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Beige);

            // Commencer le mode 3D
            Raylib.BeginMode3D(camera);
    
            // Dessiner une grille
            Raylib.DrawGrid(10, 1.0f);
            Raylib.DrawSphereWires(Vector3.Zero, 3.01f, 100, 100, Color.Blue);
            Raylib.DrawSphere(Vector3.Zero, 3, Color.DarkBlue);
            
            
            Raylib.EndMode3D();
    
            Raylib.DrawText("Utilise ZQSD pour bouger la caméra", 10, 10, 20, Color.DarkBlue);
            UpdateCameraTransform(ref camera);
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();

    }

    private static void UpdateCameraTransform(ref Camera3D camera)
    {
        Vector3 forward = Vector3.Normalize(camera.Target - camera.Position) / 3;
        
        //Rotation
        if (Raylib.IsKeyDown(KeyboardKey.Up)) camera.Target.Y -= 0.3f;
        if (Raylib.IsKeyDown(KeyboardKey.Down)) camera.Target.Y += 0.3f;
        
        if (Raylib.IsKeyDown(KeyboardKey.Left)) camera.Target.X += 0.3f;
        if (Raylib.IsKeyDown(KeyboardKey.Right)) camera.Target.X -= 0.3f;
        
        //Position
        //Y axis
        if (Raylib.IsKeyDown(KeyboardKey.Space)) camera.Position.Y -= 0.3f;
        if (Raylib.IsKeyDown(KeyboardKey.LeftAlt)) camera.Position.Y += 0.3f;
       
        if (Raylib.IsKeyDown(KeyboardKey.W)) camera.Position += forward ;
        if (Raylib.IsKeyDown(KeyboardKey.S)) camera.Position -= forward ;
        
        
        if (Raylib.IsKeyDown(KeyboardKey.A)) camera.Position -= Vector3.Normalize(Vector3.Cross(forward, camera.Up));
        if (Raylib.IsKeyDown(KeyboardKey.D)) camera.Position += Vector3.Normalize(Vector3.Cross(forward, camera.Up));
        
    }       
}