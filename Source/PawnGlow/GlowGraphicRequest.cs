using RimWorld;

namespace PawnGlow
{
    // Token: 0x02000002 RID: 2
    public class GlowGraphicRequest
    {
        // Token: 0x04000002 RID: 2
        public readonly BodyTypeDef bodyType;

        // Token: 0x04000001 RID: 1
        public readonly PawnGlowProperties glowProperties;

        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public GlowGraphicRequest(PawnGlowProperties glowProperties, BodyTypeDef bodyType)
        {
            this.glowProperties = glowProperties;
            this.bodyType = bodyType;
        }

        // Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
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

        // Token: 0x06000003 RID: 3 RVA: 0x000020B8 File Offset: 0x000002B8
        public override int GetHashCode()
        {
            return bodyType.GetHashCode() ^ glowProperties.GetHashCode();
        }
    }
}