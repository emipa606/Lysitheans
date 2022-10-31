using UnityEngine;
using Verse;

namespace PawnGlow;

public class PawnGlowProperties : DefModExtension
{
    public readonly float bodyOffsetY = 0.002f;

    public readonly string bodyPath = "";

    public readonly bool drawHead = true;

    public readonly bool drawHeadWhileDead = true;

    public readonly bool drawHeadWhileSleeping = true;

    public readonly bool drawnBody = true;

    public readonly bool drawNorthHead = true;

    public readonly float headOffsetY = 0.003f;

    public readonly string headPath = "";

    public Color tintColor = new Color(1f, 1f, 1f, 1f);
}