using P5R.NoHoldupMusic.Template;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;

namespace P5R.NoHoldupMusic
{
    public class Mod : ModBase
    {
        private readonly IModLoader modLoader;
        private readonly IReloadedHooks? hooks;
        private readonly ILogger log;
        private readonly IMod owner;

        private readonly IModConfig modConfig;
        private readonly HoldupService _holdup;

        public Mod(ModContext context)
        {
            this.modLoader = context.ModLoader;
            this.hooks = context.Hooks;
            this.log = context.Logger;
            this.owner = context.Owner;
            this.modConfig = context.ModConfig;

            Project.Init(this.modConfig, this.modLoader, this.log, true);

            _holdup = new HoldupService();

            Project.Start();
        }

        #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Mod() { }
#pragma warning restore CS8618
        #endregion
    }
}