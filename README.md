# AdvancedInterface
AdvancedInterface is a plugin designed to improve the player interface. The plugin provides useful information right in the game, showing players their current roles, number of viewers, number of kills and time elapsed since the start of the round.

## Configuration
### {port}-config.yml
```yml
AdvancedInterface:
# Is the plugin enabled?
  is_enabled: true
  # Are debug messages displayed?
  debug: false
  # Update interval for the hint in seconds.
  update_interval: 1
  # Server name to be displayed in the hint.
  server_name: '<b><u>Server Name</u></b>'
  # Round time format. Use placeholders: {0} - minutes, {1} - seconds.
  round_time_format: 'The round runs: {0} minutes, {1} seconds.'
  # Hint text format. Use placeholders: {0} - player role color, {1} - player nickname, {2} - player role, {3} - spectator count, {4} - kill count, {5} - server name, {6} - round time.
  hint_text: |2-

    <size=25><align=left><voffset=20><color={0}>👤</color> <color={0}>|</color> {1}</voffset>
    <color={0}>🎭</color> <color={0}>| Your role:</color> {2}
    <color={0}>👥</color> <color={0}>| They are watching you:</color> <color={0}>{3}</color>
    <color={0}>🔪</color> <color={0}>| Kills:</color> <color={0}>{4}</color></align></size>
    <size=20><align=center><voffset=-15em><u><pos=-700>{5}</pos></u></voffset>\n<pos=-700>{6}</pos></align></size>
```
### {port}-translations.yml
```yml
AdvancedInterface:
  class_d: '<color=orange>Class D</color>'
  scientist: '<color=#F0E827>Scientist</color>'
  facility_guard: '<color=#505050>Facility Guard</color>'
  chaos_conscript: '<color=#1F620A>Conscript - Chaos Insurgency</color>'
  chaos_marauder: '<color=#1F620A>Marauder - Chaos Insurgency</color>'
  chaos_repressor: '<color=#1F620A>Repressor - Chaos Insurgency</color>'
  chaos_rifleman: '<color=#1F620A>Rifleman - Chaos Insurgency</color>'
  ntf_private: '<color=#05B1C3>Private - Nine-Tailed Fox</color>'
  ntf_sergeant: '<color=#056AC3>Sergeant - Nine-Tailed Fox</color>'
  ntf_specialist: '<color=#056AC3>Specialist - Nine-Tailed Fox</color>'
  ntf_captain: '<color=#0B39EE>Captain - Nine-Tailed Fox</color>'
  scp173: '<color=red>SCP-173</color>'
  scp106: '<color=red>SCP-106</color>'
  scp049: '<color=red>SCP-049</color>'
  scp3114: "<color=red>SCP-3114 \U0001F480</color>"
  scp939: '<color=red>SCP-939</color>'
  scp0492: '<color=red>SCP-049-2</color>'
  scp079: '<color=red>SCP-079</color>'
  scp096: '<color=red>SCP-096</color>'
  tutorial: '<color=#ff00b0>Tutorial</color>'
```
