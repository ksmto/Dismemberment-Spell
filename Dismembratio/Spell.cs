using Extensions;
using ThunderRoad;

namespace Dismembratio
{
    public class Spell : SpellCastCharge
    {
        [ModOption("Slice Head", "If this is enabled the dismemberment spell will dismember the head on cast.", category = "Settings", defaultValueIndex = 1, saveValue = true)]
        public static bool sliceHead = true;

        [ModOption("Slice Arms", "If this is enabled the dismemberment spell will dismember both of the arms on cast.", category = "Settings", defaultValueIndex = 1, saveValue = true)]
        public static bool sliceArms = true;

        [ModOption("Slice Legs", "If this is enabled the dismemberment spell will dismember both of the legs on cast.", category = "Settings", defaultValueIndex = 1, saveValue = true)]
        public static bool sliceLegs = true;

        [ModOption("Slice Random", "If this is enabled the dismemberment spell will dismember both of the legs on cast.", category = "Settings", defaultValueIndex = 0, saveValue = true)]
        public static bool sliceRandomPart = false;

        public override void UpdateCaster()
        {
            base.UpdateCaster();
            if (!spellCaster.isFiring) return;
            var creature = Methods.GetClosestCreature();

            if (sliceHead)
            {
                creature?.Kill();
                creature?.Head()?.TrySlice();
            }

            if (sliceArms)
            {
                creature?.Kill();
                creature?.LeftArm()?.TrySlice();
                creature?.RightArm()?.TrySlice();
            }

            if (sliceLegs)
            {
                creature?.Kill();
                creature?.LeftLeg()?.TrySlice();
                creature?.RightLeg()?.TrySlice();
            }

            if (sliceRandomPart)
            {
                creature?.Kill();
                creature?.GetRandomPart()?.TrySlice();
            }

            if (!sliceHead && !sliceArms && !sliceLegs && !sliceRandomPart)
            {
                spellCaster.EndCast();
                switch (spellCaster.side)
                {
                    case Side.Right:
                        Methods.ShowMessage("You can not dismember enemies with the spell due to not having any dismemberment option turned on.", 1, 0, false, true, true, MessageAnchorType.HandLeft);
                        break;
                    case Side.Left:
                        Methods.ShowMessage("You can not dismember enemies with the spell due to not having any dismemberment option turned on.", 1, 0, false, true, true, MessageAnchorType.HandRight);
                        break;
                }
            }
        }
    }
}