using UnityEngine;
using Verse;

namespace PawnGlow
{
    // Token: 0x02000005 RID: 5
    public class PawnGlowProperties : DefModExtension
    {
        // Token: 0x0400000F RID: 15
        public readonly float bodyOffsetY = 0.002f;

        // Token: 0x04000007 RID: 7
        public readonly string bodyPath = "";

        // Token: 0x0400000D RID: 13
        public readonly bool drawHead = true;

        // Token: 0x0400000C RID: 12
        public readonly bool drawHeadWhileDead = true;

        // Token: 0x0400000A RID: 10
        public readonly bool drawHeadWhileSleeping = true;

        // Token: 0x04000009 RID: 9
        public readonly bool drawnBody = true;

        // Token: 0x0400000B RID: 11
        public readonly bool drawNorthHead = true;

        // Token: 0x04000010 RID: 16
        public readonly float headOffsetY = 0.003f;

        // Token: 0x04000008 RID: 8
        public readonly string headPath = "";

        // Token: 0x0400000E RID: 14
        public Color tintColor = new Color(1f, 1f, 1f, 1f);
    }
}