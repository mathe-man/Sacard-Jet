using System.Numerics;
using System;
using Raylib_cs;

namespace SacardJet;

internal static class Program
{
    private static void Main(string[] args)
    {
        SacardJetEngine engine = new SacardJetEngine();
        engine.Update();
    }
}
