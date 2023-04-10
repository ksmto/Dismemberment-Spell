using Extensions;
using ThunderRoad;

namespace Dismembratio
{
    public class Spell : SpellCastCharge
    {
        public override void UpdateCaster()
        {
            base.UpdateCaster();
            var creature = Methods.GetClosestCreature();

            if (spellCaster.isFiring)
            {
                if (creature != null)
                {
                    if (ModOptions.SliceHead)
                    {
                        creature.Kill();
                        creature.SlicePart(RagdollPart.Type.Head);
                    }

                    if (ModOptions.SliceHands)
                    {
                        creature.Kill();
                        creature.SlicePart(RagdollPart.Type.LeftHand);
                        creature.SlicePart(RagdollPart.Type.RightHand);
                    }

                    if (ModOptions.SliceArms)
                    {
                        creature.Kill();
                        creature.SlicePart(RagdollPart.Type.LeftArm);
                        creature.SlicePart(RagdollPart.Type.RightArm);
                    }

                    if (ModOptions.SliceLegs)
                    {
                        creature.Kill();
                        creature.SlicePart(RagdollPart.Type.LeftLeg);
                        creature.SlicePart(RagdollPart.Type.RightLeg);
                    }

                    if (ModOptions.SliceFeet)
                    {
                        creature.Kill();
                        creature.SlicePart(RagdollPart.Type.LeftFoot);
                        creature.SlicePart(RagdollPart.Type.RightFoot);
                    }

                    if (ModOptions.SliceRandomPart)
                    {
                        creature.Kill();
                        creature.GetRandomPart()?.TrySlice();
                    }

                    if (!ModOptions.SliceHead && !ModOptions.SliceHands && !ModOptions.SliceArms && !ModOptions.SliceLegs && !ModOptions.SliceFeet && !ModOptions.SliceRandomPart)
                    {
                        if (spellCaster != null)
                        {
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
                }
            }
        }
    }
}