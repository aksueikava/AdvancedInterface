using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using MEC;
using PlayerRoles;
using AdvancedInterface.Enums;

namespace AdvancedInterface
{
    public class Plugin : Plugin<Config, Translations>
    {
        public override string Name => "AdvancedInterface";
        public override string Prefix => "AdvancedInterface";
        public override string Author => "aksueikava";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 11, 0);

        public static Plugin Instance;
        private EventHandler _eventHandler;
        private CoroutineHandle updateCoroutine;
        public DateTime roundStartTime;
        public bool roundStarted = false;
        public Dictionary<Player, int> playerKills = new Dictionary<Player, int>();

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();

            updateCoroutine = Timing.RunCoroutine(UpdateRoutine());
            Log.Debug("AdvancedInterface has been enabled.");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            UnregisterEvents();

            Timing.KillCoroutines(updateCoroutine);
            Log.Debug("AdvancedInterface has been disabled.");
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            _eventHandler = new EventHandler();

            Exiled.Events.Handlers.Server.RoundStarted += _eventHandler.OnRoundStarted;
            Exiled.Events.Handlers.Player.Died += _eventHandler.OnPlayerDied;
        }

        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= _eventHandler.OnRoundStarted;
            Exiled.Events.Handlers.Player.Died -= _eventHandler.OnPlayerDied;

            _eventHandler = null;
        }

        private string GetRoleColor(RoleTypeId role)
        {
            var translations = RoleTypeTranslations.GetTranslations(Translation);
            if (translations.TryGetValue(role, out var translatedRole))
            {
                var colorCodeMatch = System.Text.RegularExpressions.Regex.Match(translatedRole, @"<color=(.*?)>");
                if (colorCodeMatch.Success)
                {
                    return colorCodeMatch.Groups[1].Value;
                }
            }
            return "{cargoCor}";
        }

        private IEnumerator<float> UpdateRoutine()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(Config.UpdateInterval);

                if (roundStarted)
                {
                    TimeSpan elapsedTime = DateTime.Now - roundStartTime;
                    string roundTimeFormatted = string.Format(Config.RoundTimeFormat, elapsedTime.Minutes, elapsedTime.Seconds);
                    var translations = RoleTypeTranslations.GetTranslations(Translation);

                    foreach (var player in Player.List)
                    {
                        if (player.IsAlive)
                        {
                            string PlayerRole = translations.TryGetValue(player.Role.Type, out var translatedRole) ? translatedRole : player.Role.Type.ToString();
                            string cargoCor = GetRoleColor(player.Role.Type);
                            int spectatorCount = player.CurrentSpectatingPlayers.Where(spectator => spectator.Role.Type != RoleTypeId.Overwatch).Count();
                            int playerKillCount = playerKills.TryGetValue(player, out var kills) ? kills : 0;

                            string hintText = string.Format(Config.HintText, cargoCor, player.Nickname, PlayerRole, spectatorCount, playerKillCount, Config.ServerName, roundTimeFormatted);
                            player.ShowHint(hintText, 2.5f);
                        }
                    }
                }
            }
        }
    }
}