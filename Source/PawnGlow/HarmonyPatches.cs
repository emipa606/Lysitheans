using System.Reflection;
using HarmonyLib;
using Verse;

namespace PawnGlow;

[StaticConstructorOnStartup]
public static class HarmonyPatches
{
    private static readonly FieldInfo int_PawnRenderer_GetPawn;

    static HarmonyPatches()
    {
        var harmonyInstance = new Harmony("chjees.pawnglow");
        var typeFromHandle = typeof(PawnRenderer);
        int_PawnRenderer_GetPawn = typeFromHandle.GetField("pawn",
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
        harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
    }

    public static Pawn PawnRenderer_GetPawn_GetPawn(PawnRenderer instance)
    {
        return (Pawn)int_PawnRenderer_GetPawn.GetValue(instance);
    }
}