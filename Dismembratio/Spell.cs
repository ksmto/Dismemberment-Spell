using ThunderRoad;
using Extensions;

namespace Dismembratio;
public class Spell : SpellCastCharge {
    public override void UpdateCaster() {
        base.UpdateCaster();
        if (!spellCaster.isFiring) return;
        var creature = Player.currentCreature.GetClosestCreature();
        creature.SliceAllParts();
    }
}