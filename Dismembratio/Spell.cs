using Extensions;
using System;
using ThunderRoad;

namespace Dismembratio;

public class Spell : SpellCastCharge
{
    public override void UpdateCaster()
    {
        base.UpdateCaster();
        var creature = Methods.GetClosestCreature();

        if (!spellCaster.isFiring || creature is null) return;

        if (ModOptions.SliceHead)
        {
            creature?.Kill();
            creature?.Head()?.TrySlice();
        }

        if (ModOptions.SliceHands)
        {
            creature?.Kill();
            creature?.LeftLeg()?.TrySlice();
            creature?.RightLeg()?.TrySlice();
        }

        if (ModOptions.SliceArms)
        {
            creature?.Kill();
            creature?.LeftHand()?.TrySlice();
            creature?.RightHand()?.TrySlice();
        }

        if (ModOptions.SliceLegs)
        {
            creature?.Kill();
            creature?.LeftLeg()?.TrySlice();
            creature?.RightLeg()?.TrySlice();
        }

        if (ModOptions.SliceFeet)
        {
            creature?.Kill();
            creature?.LeftFoot()?.TrySlice();
            creature?.RightFoot()?.TrySlice();
        }

        if (ModOptions.SliceRandomPart)
        {
            creature?.Kill();
            creature?.GetRandomPart()?.TrySlice();
        }

        if (ModOptions.SliceHead || ModOptions.SliceHands || ModOptions.SliceArms || ModOptions.SliceLegs || ModOptions.SliceFeet || ModOptions.SliceRandomPart) return;
        spellCaster.EndCast();

        switch (spellCaster.side)
        {
            case Side.Left:
                Methods.ShowMessage("You can not dismember enemies with the spell due to not having any dismemberment option turned on.",
                                    1,
                                    0,
                                    false,
                                    true,
                                    true,
                                    MessageAnchorType.HandRight);
                break;
            case Side.Right:
                Methods.ShowMessage("You can not dismember enemies with the spell due to not having any dismemberment option turned on.",
                                    1,
                                    0,
                                    false,
                                    true,
                                    true,
                                    MessageAnchorType.HandLeft);
                break;
        }
    }
}