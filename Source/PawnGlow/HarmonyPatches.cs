using System.Reflection;
using HarmonyLib;
using Verse;

namespace PawnGlow
{
    // Token: 0x02000004 RID: 4
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        // Token: 0x04000006 RID: 6
        private static readonly FieldInfo int_PawnRenderer_GetPawn;

        // Token: 0x06000008 RID: 8 RVA: 0x00002258 File Offset: 0x00000458
        static HarmonyPatches()
        {
            var harmonyInstance = new Harmony("chjees.pawnglow");
            var typeFromHandle = typeof(PawnRenderer);
            int_PawnRenderer_GetPawn = typeFromHandle.GetField("pawn",
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
            //harmonyInstance.Patch(typeFromHandle.GetMethod("RenderPawnInternal",
            //        BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, CallingConventions.Any, new[]
            //        {
            //            typeof(Vector3),
            //            typeof(float),
            //            typeof(bool),
            //            typeof(Rot4),
            //            typeof(Rot4),
            //            typeof(RotDrawMode),
            //            typeof(bool),
            //            typeof(bool),
            //            typeof(bool)
            //        }, null), null,
            //    new HarmonyMethod(typeof(HarmonyPatches).GetMethod("Patch_PawnRenderer_RenderPawnInternal")));
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }

        // Token: 0x06000009 RID: 9 RVA: 0x00002344 File Offset: 0x00000544
        public static Pawn PawnRenderer_GetPawn_GetPawn(PawnRenderer instance)
        {
            return (Pawn) int_PawnRenderer_GetPawn.GetValue(instance);
        }
    }
}