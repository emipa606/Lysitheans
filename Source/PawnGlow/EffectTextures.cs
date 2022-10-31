using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace PawnGlow;

[StaticConstructorOnStartup]
public static class EffectTextures
{
    private static readonly Dictionary<PawnGlowProperties, Graphic> headGraphicCache =
        new Dictionary<PawnGlowProperties, Graphic>();

    private static readonly Dictionary<PawnGlowProperties, Graphic> bodyGraphicCache =
        new Dictionary<PawnGlowProperties, Graphic>();

    private static readonly Dictionary<GlowGraphicRequest, Graphic> bodyGraphicHumanoidCache =
        new Dictionary<GlowGraphicRequest, Graphic>();

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
                $"{glowRequest.glowProperties.bodyPath}_{glowRequest.bodyType}", ShaderDatabase.MoteGlow,
                Vector2.one, glowRequest.glowProperties.tintColor);
            result = bodyGraphicHumanoidCache[glowRequest];
        }

        return result;
    }
}