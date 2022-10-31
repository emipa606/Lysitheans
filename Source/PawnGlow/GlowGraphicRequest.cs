using RimWorld;

namespace PawnGlow;

public class GlowGraphicRequest
{
    public readonly BodyTypeDef bodyType;

    public readonly PawnGlowProperties glowProperties;

    public GlowGraphicRequest(PawnGlowProperties glowProperties, BodyTypeDef bodyType)
    {
        this.glowProperties = glowProperties;
        this.bodyType = bodyType;
    }

    public override bool Equals(object obj)
    {
        bool result;
        if (this == obj)
        {
            result = true;
        }
        else
        {
            result = obj is GlowGraphicRequest glowGraphicRequest && bodyType == glowGraphicRequest.bodyType &&
                     glowProperties == glowGraphicRequest.glowProperties;
        }

        return result;
    }

    public override int GetHashCode()
    {
        return bodyType.GetHashCode() ^ glowProperties.GetHashCode();
    }
}