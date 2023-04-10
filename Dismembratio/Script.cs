using System.Linq;
using ThunderRoad;

namespace Dismembratio
{
    public class Script : ThunderScript
    {
        public override void ScriptEnable()
        {
            base.ScriptEnable();
            EventManager.onPossess += EventManager_onPossess;
        }

        private static void EventManager_onPossess(Creature creature, EventTime eventTime)
        {
            if (eventTime == EventTime.OnEnd && Player.currentCreature.container.contents.All(contents => contents.itemData.id != "SpellDismemberment"))
            {
                Player.currentCreature.container.AddContent("SpellDismemberment");
            }
        }

        public override void ScriptDisable()
        {
            base.ScriptDisable();
            EventManager.onPossess -= EventManager_onPossess;
        }
    }
}