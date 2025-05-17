using Exiled.API.Features;
using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Ushio_Noa
{
    public class Config : IConfig
    {
        [Description("是否开启诺亚插件")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
    }
    public class Plugin : Plugin<Config>
    {
        private EventHandlers EventHandlers;
        public override void OnEnabled()
        {
            base.OnEnabled();
            Log.Info("Noa(诺亚)插件已启动 by九尾狐0513");
            EventHandlers = new EventHandlers();
            Exiled.Events.Handlers.Server.RoundStarted += EventHandlers.RoundStarted;
            Exiled.Events.Handlers.Player.Died += EventHandlers.PlayerDied;
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Server.RoundStarted -= EventHandlers.RoundStarted;
            Exiled.Events.Handlers.Player.Died -= EventHandlers.PlayerDied;
            EventHandlers = null;
        }
    }

}
