using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace PawnGlow
{
    // Token: 0x02000003 RID: 3
    [StaticConstructorOnStartup]
    public static class EffectTextures
    {
        // Token: 0x04000003 RID: 3
        private static readonly Dictionary<PawnGlowProperties, Graphic> headGraphicCache =
            new Dictionary<PawnGlowProperties, Graphic>();

        // Token: 0x04000004 RID: 4
        private static readonly Dictionary<PawnGlowProperties, Graphic> bodyGraphicCache =
            new Dictionary<PawnGlowProperties, Graphic>();

        // Token: 0x04000005 RID: 5
        private static readonly Dictionary<GlowGraphicRequest, Graphic> bodyGraphicHumanoidCache =
            new Dictionary<GlowGraphicRequest, Graphic>();

        // Token: 0x06000005 RID: 5 RVA: 0x00002108 File Offset: 0x00000308
        public static Graphic GetHeadGraphic(PawnGlowProperties properties)
        {
            Graphic result;
            if (headGraphicCache.ContainsKey(properties))
            {
                result = headGraphicCache[properties];
            }
            else
            {
                headGraphicCache[properties] = GraphicDatabase.Get<Graphic_Multi>(properties.headPath,
                    ShaderDatabase.MoteGlow, Vector2.one, properties.tintColor);
                result = headGraphicCache[properties];
            }

            return result;
        }

        // Token: 0x06000006 RID: 6 RVA: 0x0000216C File Offset: 0x0000036C
        public static Graphic GetBodyGraphic(PawnGlowProperties properties)
        {
            Graphic result;
            if (bodyGraphicCache.ContainsKey(properties))
            {
                result = bodyGraphicCache[properties];
            }
            else
            {
                bodyGraphicCache[properties] = GraphicDatabase.Get<Graphic_Multi>(properties.bodyPath,
                    ShaderDatabase.MoteGlow, Vector2.one, properties.tintColor);
                result = bodyGraphicCache[properties];
            }

            return result;
        }

        // Token: 0x06000007 RID: 7 RVA: 0x000021D0 File Offset: 0x000003D0
        public static Graphic GetHumanoidBodyGraphic(GlowGraphicRequest glowRequest)
        {
            Graphic result;
            if (bodyGraphicHumanoidCache.ContainsKey(glowRequest))
            {
                result = bodyGraphicHumanoidCache[glowRequest];
            }
            else
            {
                bodyGraphicHumanoidCache[glowRequest] = GraphicDatabase.Get<Graphic_Multi>(
                    glowRequest.glowProperties.bodyPath + "_" + glowRequest.bodyType, ShaderDatabase.MoteGlow,
                    Vector2.one, glowRequest.glowProperties.tintColor);
                result = bodyGraphicHumanoidCache[glowRequest];
            }

            return result;
        }
    }
}