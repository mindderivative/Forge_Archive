using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Tables
{
    [Database( Name = "ForgeDatabase")]
    public class ForgeDataContext : DataContext
    {
        public ForgeDataContext(SqlCeConnection connection) : base(connection) {}

        public Table<AFFIX> Affixes;
        public Table<BESTIARY> Bestiary;
        public Table<ENCOUNTER> Encounters;
        public Table<ENCOUNTER_PLOT> ENCOUNTER_PLOT;
        public Table<ENCOUNTER_BESTIARY> ENCOUNTER_BESTIARY;
        public Table<ENHANCEMENT> Enhancements;
        public Table<EVENT> Events;
        public Table<EVENT_NOTE> EVENT_NOTE;
        public Table<EVENT_PLOT> EVENT_PLOT;
        public Table<FACTION> Factions;
        public Table<FEAT> Feats;
        public Table<INFIX> Infixes;
        public Table<LANGUAGE> Languages;
        public Table<LAYER> Layers;
        public Table<MAP> Maps;
        public Table<PLAYER> Players;
        public Table<PLAYER_FACTION> PlayerFactions;
        public Table<PLAYER_LANGUAGE> PlayerLanguages;
        public Table<PLAYER_SKILL> PlayerSkills;
        public Table<PLOT> Plots;
        public Table<POSTFIX> Postfixes;
        public Table<PREFIX> Prefixes;
        public Table<PUSHPIN> PushPins;
        public Table<REGION> Regions;
        public Table<REGION_POINTS> REGION_POINTS;
        public Table<SKILL> Skills;
        public Table<SPELL> Spells;
        public Table<STORY> Stories;
        public Table<SUFFIX> Suffixes;
        public Table<UPDATED> Updated;
    }
}
