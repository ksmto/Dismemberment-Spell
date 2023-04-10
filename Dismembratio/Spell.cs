using Extensions;
using ThunderRoad;

namespace Dismembratio
{
    public class Spell : SpellCastCharge
    {
        public override void UpdateCaster()
        {
            base.UpdateCaster();
            foreach (Creature creatures in Creature.allActive)
            {
                if (spellCaster.isFiring)
                {
                    if (creatures != null)
                    {
                        if (ModOptions.SliceHead)
                        {
                            creatures.Kill();
                            creatures.SlicePart(RagdollPart.Type.Head);
                        }

                        if (ModOptions.SliceHands)
                        {
                            creatures.Kill();
                            creatures.SlicePart(RagdollPart.Type.LeftHand);
                            creatures.SlicePart(RagdollPart.Type.RightHand);
                        }

                        if (ModOptions.SliceArms)
                        {
                            creatures.Kill();
                            creatures.SlicePart(RagdollPart.Type.LeftArm);
                            creatures.SlicePart(RagdollPart.Type.RightArm);
                        }

                        if (ModOptions.SliceLegs)
                        {
                            creatures.Kill();
                            creatures.SlicePart(RagdollPart.Type.LeftLeg);
                            creatures.SlicePart(RagdollPart.Type.RightLeg);
                        }

                        if (ModOptions.SliceFeet)
                        {
                            creatures.Kill();
                            creatures.SlicePart(RagdollPart.Type.LeftFoot);
                            creatures.SlicePart(RagdollPart.Type.RightFoot);
                        }

                        if (ModOptions.SliceRandomPart)
                        {
                            creatures.Kill();
                            creatures.GetRandomPart()?.TrySlice();
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
}