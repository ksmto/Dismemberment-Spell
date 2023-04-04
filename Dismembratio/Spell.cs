using Extensions;
using ThunderRoad;

namespace Dismembratio
{
    public class Spell : SpellCastCharge
    {
        [ModOption("Slice Head", "If this is enabled the dismemberment spell will dismember the head on cast.", category = "Settings", defaultValueIndex = 1, order = 0, saveValue = true)]
        public static bool SliceHead { get; set; }

        [ModOption("Slice Arms", "If this is enabled the dismemberment spell will dismember both of the arms on cast.", category = "Settings", defaultValueIndex = 1, order = 1, saveValue = true)]
        public static bool SliceArms { get; set; }

        [ModOption("Slice Legs", "If this is enabled the dismemberment spell will dismember both of the legs on cast.", category = "Settings", defaultValueIndex = 1, order = 2, saveValue = true)]
        public static bool SliceLegs { get; set; }

        [ModOption("Slice Random", "If this is enabled the dismemberment spell will dismember both of the legs on cast.", category = "Settings", defaultValueIndex = 0, order = 3, saveValue = true)]
        public static bool SliceRandomPart { get; set; }

        public override void UpdateCaster()
        {
            base.UpdateCaster();
            var creature = Methods.GetClosestCreature();

            if (spellCaster.isFiring)
            {
                if (SliceHead)
                {
                    creature?.Kill();
                    creature?.Head()?.TrySlice();
                }

                if (SliceArms)
                {
                    creature?.Kill();
                    creature?.LeftArm()?.TrySlice();
                    creature?.RightArm()?.TrySlice();
                }

                if (SliceLegs)
                {
                    creature?.Kill();
                    creature?.LeftLeg()?.TrySlice();
                    creature?.RightLeg()?.TrySlice();
                }

                if (SliceRandomPart)
                {
                    creature?.Kill();
                    creature?.GetRandomPart()?.TrySlice();
                }

                if (!SliceHead && !SliceArms && !SliceLegs && !SliceRandomPart)
                {
                    spellCaster.EndCast();

                    switch (spellCaster.side)
                    {
                        case Side.Left:
                            Methods.ShowMessage("You can not dismember enemies with the spell due to not having any dismemberment option turned on.", 1, 0, false, true, true, MessageAnchorType.HandRight);
                            break;
                        case Side.Right:
                            Methods.ShowMessage("You can not dismember enemies with the spell due to not having any dismemberment option turned on.", 1, 0, false, true, true, MessageAnchorType.HandLeft);
                            break;
                    }
                }
            }
        }
    }
}