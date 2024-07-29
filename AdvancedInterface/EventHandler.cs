using System;
using Exiled.Events.EventArgs.Player;

namespace AdvancedInterface
{
    public class EventHandler
    {
        public void OnRoundStarted()
        {
            Plugin.Instance.roundStartTime = DateTime.Now;
            Plugin.Instance.roundStarted = true;
        }

        public void OnPlayerDied(DiedEventArgs ev)
        {
            if (ev.Attacker != null && ev.Attacker != ev.Player)
            {
                if (!Plugin.Instance.playerKills.ContainsKey(ev.Attacker))
                {
                    Plugin.Instance.playerKills[ev.Attacker] = 0;
                }
                Plugin.Instance.playerKills[ev.Attacker]++;
            }
        }
    }
}