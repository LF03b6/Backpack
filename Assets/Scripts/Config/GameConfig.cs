namespace Config
{
    public static class GameConfig
    {
        public struct Backpack
        {
            public const int SlotsPerRow = 10;
            public const int SlotsPerColumn = 7;

            /// <summary>标准情况下完整的格子数量</summary>
            public const int SlotsCountStandard = SlotsPerRow * SlotsPerColumn;
        }
    }
}