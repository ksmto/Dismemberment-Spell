using Extensions;
using ThunderRoad;

namespace Dismembratio;

public class Spell : SpellCastCharge {
    [ModOption(name = "Slice Head",
                  tooltip = "If this is enabled the dismemberment spell will dismember the head on cast.",
                  category = "Dismemberment Spell: Sliceables")]
    public bool sliceHead = true;
    [ModOption(name = "Slice Arms",
                  tooltip = "If this is enabled the dismemberment spell will dismember both of the arms on cast.",
                  category = "Dismemberment Spell: Sliceables")]
    public bool sliceArms = true;
    [ModOption(name = "Slice Legs", 
                  tooltip = "If this is enabled the dismemberment spell will dismember both of the legs on cast.",
                  category = "Dismemberment Spell: Sliceables")]
    public bool sliceLegs = true;

    public override void UpdateCaster() {
        base.UpdateCaster();
        var closestCreature = Methods.GetClosestCreature();
        if (!spellCaster.isFiring || closestCreature is null) return;
        if (sliceHead) closestCreature.Head()?.TrySlice();
        if (sliceArms) {
            closestCreature.LeftArm().TrySlice();
            closestCreature.RightArm().TrySlice();
        }
        if (!sliceLegs) return;
        closestCreature.LeftLeg().TrySlice();
        closestCreature.RightLeg().TrySlice();
    }
}