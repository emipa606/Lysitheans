using HarmonyLib;
using UnityEngine;
using Verse;

namespace PawnGlow
{
    [HarmonyPatch(typeof(PawnRenderer), "RenderPawnInternal")]
    internal class PawnRenderer_RenderPawnInternal
    {
        // Token: 0x0600000A RID: 10 RVA: 0x00002368 File Offset: 0x00000568
        public static void Postfix(ref PawnRenderer __instance, Vector3 rootLoc,
            float angle, bool renderBody, Rot4 bodyFacing, RotDrawMode bodyDrawType, PawnRenderFlags flags)
        {
            var portrait = (flags & PawnRenderFlags.Portrait) != 0;
            var headStump = (flags & PawnRenderFlags.HeadStump) != 0;

            if (__instance == null)
            {
                return;
            }

            var pawn = HarmonyPatches.PawnRenderer_GetPawn_GetPawn(__instance);

            if (pawn?.def.GetModExtension<PawnGlowProperties>() == null)
            {
                return;
            }

            var quat = Quaternion.AngleAxis(angle, Vector3.up);
            if (pawn.def.GetModExtension<PawnGlowProperties>().drawnBody && renderBody)
            {
                rootLoc.y += 0.0078125f + pawn.def.GetModExtension<PawnGlowProperties>().bodyOffsetY;
                if (bodyDrawType != RotDrawMode.Dessicated)
                {
                    if (pawn.RaceProps.Humanlike)
                    {
                        var mesh = MeshPool.humanlikeBodySet.MeshAt(bodyFacing);
                        GenDraw.DrawMeshNowOrLater(mesh, rootLoc, quat,
                            EffectTextures
                                .GetHumanoidBodyGraphic(new GlowGraphicRequest(
                                    pawn.def.GetModExtension<PawnGlowProperties>(),
                                    pawn.story.bodyType)).MatAt(bodyFacing), portrait);
                    }
                    else
                    {
                        var mesh = __instance.graphics.nakedGraphic.MeshAt(bodyFacing);
                        GenDraw.DrawMeshNowOrLater(mesh, rootLoc, quat,
                            EffectTextures.GetBodyGraphic(pawn.def.GetModExtension<PawnGlowProperties>())
                                .MatAt(bodyFacing), portrait);
                    }
                }
            }

            var pawnAlive = true;
            if (!pawn.def.GetModExtension<PawnGlowProperties>().drawHeadWhileDead)
            {
                pawnAlive = !pawn.Dead;
            }

            var drawPortrait = true;
            if (!pawn.def.GetModExtension<PawnGlowProperties>().drawHeadWhileSleeping)
            {
                drawPortrait = portrait;
                if (!portrait)
                {
                    var jobs = pawn.jobs;

                    if (jobs?.curDriver != null)
                    {
                        drawPortrait = !pawn.jobs.curDriver.asleep;
                    }
                }
            }

            if (!(pawn.def.GetModExtension<PawnGlowProperties>().drawHead && pawn.RaceProps.Humanlike &&
                  !headStump &&
                  pawnAlive && drawPortrait))
            {
                return;
            }

            var vector2 = rootLoc;
            if (bodyFacing != Rot4.North)
            {
                vector2.y += 0.0281250011f;
                rootLoc.y += 0.0234375f;
            }
            else
            {
                vector2.y += 0.0234375f;
                rootLoc.y += 0.02734375f;
            }

            var vector3 = quat * __instance.BaseHeadOffsetAt(bodyFacing);
            var vector4 = vector2 + vector3 +
                          new Vector3(0f, pawn.def.GetModExtension<PawnGlowProperties>().headOffsetY, 0f);
            var mesh2 = MeshPool.humanlikeHeadSet.MeshAt(bodyFacing);
            if (bodyFacing == Rot4.North)
            {
                if (!pawn.def.GetModExtension<PawnGlowProperties>().drawNorthHead)
                {
                    GenDraw.DrawMeshNowOrLater(mesh2, vector4, quat,
                        EffectTextures.GetHeadGraphic(pawn.def.GetModExtension<PawnGlowProperties>())
                            .MatAt(bodyFacing),
                        portrait);
                }
            }
            else
            {
                GenDraw.DrawMeshNowOrLater(mesh2, vector4, quat,
                    EffectTextures.GetHeadGraphic(pawn.def.GetModExtension<PawnGlowProperties>()).MatAt(bodyFacing),
                    portrait);
            }
        }
    }
}