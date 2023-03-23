using Extensions;
using ThunderRoad;

namespace Dismembratio;

public class Spell : SpellCastCharge {
    [ModOption("Slice Head",
                  "If this is enabled the dismemberment spell will dismember the head on cast.",
                  valueSourceName = "Slice Head",
                  defaultValueIndex = 1)]
    public static bool sliceHead = true;
    [ModOption("Slice Arms",
                  "If this is enabled the dismemberment spell will dismember both of the arms on cast.",
                  valueSourceName = "Slice Arms",
                  defaultValueIndex = 1)]
    public static bool sliceArms = true;
    [ModOption("Slice Legs",
                  "If this is enabled the dismemberment spell will dismember both of the legs on cast.",
                  valueSourceName = "Slice Legs",
                  defaultValueIndex = 1)]
    public static bool sliceLegs = true;

    public override void UpdateCaster() {
        base.UpdateCaster();
        if (!spellCaster.isFiring) return;
        foreach (var creature in Creature.allActive) {
            if (sliceHead) creature.Head()?.TrySlice();
            if (sliceArms) { creature.LeftArm()?.TrySlice(); creature.RightArm()?.TrySlice(); }
            if (sliceLegs) { creature.LeftLeg()?.TrySlice(); creature.RightLeg()?.TrySlice(); }
        }
    }
}