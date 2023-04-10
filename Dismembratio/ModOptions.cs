using ThunderRoad;

namespace Dismembratio
{
    public class ModOptions
    {
        [ModOptionButton]
        [ModOption("Slice Head",
                      "If this is enabled the dismemberment spell will dismember the head on cast.",
                      category = "Settings",
                      defaultValueIndex = 0,
                      valueSourceName = "EnabledDisabled",
                      order = 0,
                      saveValue = true)]
        public static bool SliceHead { get; set; }

        [ModOptionButton]
        [ModOption("Slice Hands",
                      "If this is enabled the dismemberment spell will dismember both of the hands on cast.",
                      category = "Settings",
                      defaultValueIndex = 1,
                      valueSourceName = "EnabledDisabled",
                      order = 1,
                      saveValue = true)]
        public static bool SliceHands { get; set; }

        [ModOptionButton]
        [ModOption("Slice Arms",
                      "If this is enabled the dismemberment spell will dismember both of the arms on cast.",
                      category = "Settings",
                      defaultValueIndex = 0,
                      valueSourceName = "EnabledDisabled",
                      order = 2,
                      saveValue = true)]
        public static bool SliceArms { get; set; }

        [ModOptionButton]
        [ModOption("Slice Legs",
                      "If this is enabled the dismemberment spell will dismember both of the legs on cast.",
                      category = "Settings",
                      defaultValueIndex = 0,
                      valueSourceName = "EnabledDisabled",
                      order = 3,
                      saveValue = true)]
        public static bool SliceLegs { get; set; }

        [ModOptionButton]
        [ModOption("Slice Feet",
                      "If this is enabled the dismemberment spell will dismember both of the feet on cast.",
                      category = "Settings",
                      defaultValueIndex = 1,
                      valueSourceName = "EnabledDisabled",
                      order = 4,
                      saveValue = true)]
        public static bool SliceFeet { get; set; }

        [ModOptionButton]
        [ModOption("Slice Random",
                      "If this is enabled the dismemberment spell will dismember both of the legs on cast.",
                      category = "Settings",
                      defaultValueIndex = 1,
                      valueSourceName = "EnabledDisabled",
                      order = 5,
                      saveValue = true)]
        public static bool SliceRandomPart { get; set; }

        public static ModOptionBool[] EnabledDisabled =
        {
        new ModOptionBool("Enabled", true),
        new ModOptionBool("Disabled", false)
    };
    }
}