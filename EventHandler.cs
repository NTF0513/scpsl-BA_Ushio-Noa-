using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System.Collections.Generic;

namespace Ushio_Noa
{
    public class EventHandlers
    {
        public static void RoundStarted()
        {
            foreach (Player player in Player.List)
            {
                if (Noa.Count < 1 && player.Role.Type == PlayerRoles.RoleTypeId.FacilityGuard)
                {
                    _Noa(player);
                }
            }
        }
        public static void _Noa(Player player)
        {
            Noa.Add(player);
            player.Health = 125f;
            player.MaxHealth = 125f;
            player.RankColor = "cyan";
            player.RankName = "生盐 诺亚";
            player.AddItem((ItemType)21);
            player.AddItem((ItemType)33);
            player.ShowHint("<color=#87CEEB>你是\n <color=#FFC0CB>生盐诺亚</color>\n 帮助警卫维持设施秩序 同时寻找逃出的小雪</color>", 5f);
        }
        public void PlayerDied(DiedEventArgs hub)
        {
            if (Noa.Contains(hub.Player))
            {
                Cassie.MessageTranslated("N O A is died", "<color=#87CEEB>诺亚:返回疗伤</color>");
                Noa.Remove(hub.Player);
                hub.Player.RankColor = null;
                hub.Player.RankName = null;
            }
        }
        public static List<Player> Noa = new List<Player>();
    }
}
