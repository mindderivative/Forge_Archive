-- Script Date: 1/14/2018 6:42 PM  - ErikEJ.SqlCeScripting version 3.5.2.74
-- Database information:
-- Database: C:\Users\Phil\Documents\Visual Studio 2017\Projects\Forge\Forge\ForgeDatabase.sqlite
-- ServerVersion: 3.19.3
-- DatabaseSize: 420 KB
-- Created: 11/13/2017 2:11 PM

-- User Table information:
-- Number of tables: 25
-- BESTIARY: -1 row(s)
-- ENCOUNTER: -1 row(s)
-- ENCOUNTER_BESTIARY: -1 row(s)
-- ENCOUNTER_PLOT: -1 row(s)
-- ENHANCEMENT: -1 row(s)
-- EVENT: -1 row(s)
-- EVENT_NOTE: -1 row(s)
-- EVENT_PLOT: -1 row(s)
-- FACTION: -1 row(s)
-- FEAT: -1 row(s)
-- LANGUAGE: -1 row(s)
-- LAYER: -1 row(s)
-- MAP: -1 row(s)
-- PLAYER: -1 row(s)
-- PLAYER_FACTION: -1 row(s)
-- PLAYER_LANGUAGE: -1 row(s)
-- PLAYER_SKILL: -1 row(s)
-- PLOT: -1 row(s)
-- PUSHPIN: -1 row(s)
-- REGION: -1 row(s)
-- REGION_POINTS: -1 row(s)
-- SKILL: -1 row(s)
-- SPELL: -1 row(s)
-- STORY: -1 row(s)
-- UPDATED: -1 row(s)

SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [STORY] (
  [StoryID] INTEGER  NOT NULL
, [StoryName] text NOT NULL
, [StoryAuthor] text NOT NULL
, [DateCreated] text NOT NULL
, [StoryType] text DEFAULT 'D&D, Pathfinder, Fantasy, SCI-FI' NOT NULL
, [StoryDescription] text DEFAULT 'Story Description' NOT NULL
, CONSTRAINT [sqlite_master_PK_STORY] PRIMARY KEY ([StoryID])
);
CREATE TABLE [UPDATED] (
  [UpdatedID] INTEGER  NOT NULL
, [StoryID] bigint  NOT NULL
, [DateLastUpdated] text NOT NULL
, [UpdateNote] text NOT NULL
, CONSTRAINT [sqlite_master_PK_UPDATED] PRIMARY KEY ([UpdatedID])
, FOREIGN KEY ([StoryID]) REFERENCES [STORY] ([StoryID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [SPELL] (
  [SpellID] INTEGER  NOT NULL
, [SpellName] text NOT NULL
, [School] text NULL
, [SubSchool] text NULL
, [Effect] text NULL
, [CastingTime] text NULL
, [Components] text NULL
, [Range] text NULL
, [Area] text NULL
, [Targets] text NULL
, [Duration] text NULL
, [SavingThrow] text NULL
, [SpellResistance] text NULL
, [Description] text NULL
, [Level] text NULL
, [ShortDescription] text NULL
, [Domain] text NULL
, CONSTRAINT [sqlite_master_PK_SPELL] PRIMARY KEY ([SpellID])
);
CREATE TABLE [SKILL] (
  [SkillID] INTEGER  NOT NULL
, [SkillName] text NOT NULL
, [SkillDescription] text NOT NULL
, CONSTRAINT [sqlite_master_PK_SKILL] PRIMARY KEY ([SkillID])
);
CREATE TABLE [PLOT] (
  [PlotID] INTEGER  NOT NULL
, [StoryID] bigint  NOT NULL
, [PlotName] text NOT NULL
, [PlotType] text NOT NULL
, [PlotNote] text NOT NULL
, CONSTRAINT [sqlite_master_PK_PLOT] PRIMARY KEY ([PlotID])
, FOREIGN KEY ([StoryID]) REFERENCES [STORY] ([StoryID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [PLAYER] (
  [PlayerID] INTEGER  NOT NULL
, [StoryID] bigint  NOT NULL
, [PlayerName] text NOT NULL
, [CharacterName] text NOT NULL
, [HitPoints] bigint  NOT NULL
, [Alignment] text NOT NULL
, [ArmorClass] bigint  NOT NULL
, [TouchAC] bigint  NOT NULL
, [FlatFootedAC] bigint  NOT NULL
, [CMD] bigint  NOT NULL
, [Fort] bigint  NOT NULL
, [Ref] bigint  NOT NULL
, [Will] bigint  NOT NULL
, [Str] bigint  NOT NULL
, [Dex] bigint  NOT NULL
, [Con] bigint  NOT NULL
, [Int] bigint  NOT NULL
, [Wis] bigint  NOT NULL
, [Cha] bigint  NOT NULL
, CONSTRAINT [sqlite_master_PK_PLAYER] PRIMARY KEY ([PlayerID])
, FOREIGN KEY ([StoryID]) REFERENCES [STORY] ([StoryID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [PLAYER_SKILL] (
  [PlayerSkillID] INTEGER  NOT NULL
, [PlayerID] bigint  NOT NULL
, [SkillID] bigint  NOT NULL
, [SkillRank] bigint  NOT NULL
, CONSTRAINT [sqlite_master_PK_PLAYER_SKILL] PRIMARY KEY ([PlayerSkillID])
, FOREIGN KEY ([SkillID]) REFERENCES [SKILL] ([SkillID]) ON DELETE NO ACTION ON UPDATE NO ACTION
, FOREIGN KEY ([PlayerID]) REFERENCES [PLAYER] ([PlayerID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [MAP] (
  [MapID] INTEGER  NOT NULL
, [StoryID] bigint  NOT NULL
, [ParentMapID] bigint  NULL
, [MapName] text DEFAULT 'Map Name' NOT NULL
, [MapPath] text NOT NULL
, [MapWidth] bigint  NOT NULL
, [MapHeight] bigint  NOT NULL
, [IsBaseMap] bigint  NOT NULL
, CONSTRAINT [sqlite_master_PK_MAP] PRIMARY KEY ([MapID])
, FOREIGN KEY ([ParentMapID]) REFERENCES [MAP] ([MapID]) ON DELETE CASCADE ON UPDATE CASCADE
, FOREIGN KEY ([StoryID]) REFERENCES [STORY] ([StoryID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [LAYER] (
  [LayerID] INTEGER  NOT NULL
, [MapID] bigint  NOT NULL
, [LayerName] text DEFAULT 'Layer Name' NOT NULL
, [LayerZIndex] bigint DEFAULT 0  NOT NULL
, CONSTRAINT [sqlite_master_PK_LAYER] PRIMARY KEY ([LayerID])
, FOREIGN KEY ([MapID]) REFERENCES [MAP] ([MapID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [PUSHPIN] (
  [PushPinID] INTEGER  NOT NULL
, [LayerID] bigint  NOT NULL
, [PushPinTop] bigint  NOT NULL
, [PushPinLeft] bigint  NOT NULL
, [PushPinName] text DEFAULT 'Point Name' NOT NULL
, [PushPinColor] text DEFAULT '#FFFFFFFF' NOT NULL
, [MapID] bigint  NULL
, [EncounterID] bigint  NULL
, [EventID] bigint  NULL
, CONSTRAINT [sqlite_master_PK_PUSHPIN] PRIMARY KEY ([PushPinID])
, FOREIGN KEY ([LayerID]) REFERENCES [LAYER] ([LayerID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [REGION] (
  [RegionID] INTEGER  NOT NULL
, [LayerID] bigint  NOT NULL
, [RegionName] text DEFAULT 'Region Name' NOT NULL
, [RegionColor] text DEFAULT '#FFFFFFFF' NOT NULL
, [EncounterID] bigint  NULL
, [EventID] bigint  NULL
, [MapID] bigint  NULL
, CONSTRAINT [sqlite_master_PK_REGION] PRIMARY KEY ([RegionID])
, FOREIGN KEY ([LayerID]) REFERENCES [LAYER] ([LayerID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [REGION_POINTS] (
  [RegionPointsID] INTEGER  NOT NULL
, [RegionID] bigint  NOT NULL
, [RegionTop] bigint  NOT NULL
, [RegionLeft] bigint  NOT NULL
, CONSTRAINT [sqlite_master_PK_REGION_POINTS] PRIMARY KEY ([RegionPointsID])
, FOREIGN KEY ([RegionID]) REFERENCES [REGION] ([RegionID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [LANGUAGE] (
  [LanguageID] INTEGER  NOT NULL
, [LanguageName] text NOT NULL
, [LanguageDescription] text NOT NULL
, CONSTRAINT [sqlite_master_PK_LANGUAGE] PRIMARY KEY ([LanguageID])
);
CREATE TABLE [PLAYER_LANGUAGE] (
  [PlayerLanguageID] INTEGER  NOT NULL
, [PlayerID] bigint  NOT NULL
, [LanguageID] bigint  NOT NULL
, CONSTRAINT [sqlite_master_PK_PLAYER_LANGUAGE] PRIMARY KEY ([PlayerLanguageID])
, FOREIGN KEY ([LanguageID]) REFERENCES [LANGUAGE] ([LanguageID]) ON DELETE NO ACTION ON UPDATE NO ACTION
, FOREIGN KEY ([PlayerID]) REFERENCES [PLAYER] ([PlayerID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [FEAT] (
  [FeatID] INTEGER  NOT NULL
, [FeatName] text NOT NULL
, [FeatDescription] text NULL
, [FeatBenefit] text NULL
, [FeatPrerequisites] text NULL
, [FeatSpecial] text NULL
, [FeatType] text NOT NULL
, [FeatNormal] text NULL
, CONSTRAINT [sqlite_master_PK_FEAT] PRIMARY KEY ([FeatID])
);
CREATE TABLE [FACTION] (
  [FactionID] INTEGER  NOT NULL
, [FactionName] text NOT NULL
, [FactionDescription] text NOT NULL
, CONSTRAINT [sqlite_master_PK_FACTION] PRIMARY KEY ([FactionID])
);
CREATE TABLE [PLAYER_FACTION] (
  [PlayerFactionID] INTEGER  NOT NULL
, [PlayerID] bigint  NOT NULL
, [FactionID] bigint  NOT NULL
, [FactionPoints] bigint DEFAULT 0  NOT NULL
, CONSTRAINT [sqlite_master_PK_PLAYER_FACTION] PRIMARY KEY ([PlayerFactionID])
, FOREIGN KEY ([PlayerID]) REFERENCES [PLAYER] ([PlayerID]) ON DELETE CASCADE ON UPDATE CASCADE
, FOREIGN KEY ([FactionID]) REFERENCES [FACTION] ([FactionID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [EVENT] (
  [EventID] INTEGER  NOT NULL
, [StoryID] bigint  NOT NULL
, [EventName] text DEFAULT 'Event Name' NOT NULL
, CONSTRAINT [sqlite_master_PK_EVENT] PRIMARY KEY ([EventID])
, FOREIGN KEY ([StoryID]) REFERENCES [STORY] ([StoryID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [EVENT_PLOT] (
  [EventPlotID] INTEGER  NOT NULL
, [EventID] bigint  NOT NULL
, [PlotID] bigint  NOT NULL
, CONSTRAINT [sqlite_master_PK_EVENT_PLOT] PRIMARY KEY ([EventPlotID])
, FOREIGN KEY ([EventID]) REFERENCES [EVENT] ([EventID]) ON DELETE CASCADE ON UPDATE CASCADE
, FOREIGN KEY ([PlotID]) REFERENCES [PLOT] ([PlotID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [EVENT_NOTE] (
  [EventNoteID] INTEGER  NOT NULL
, [EventID] bigint  NOT NULL
, [EventNoteName] text DEFAULT 'Note Name' NOT NULL
, [EventNote] text NOT NULL
, [EventNoteDate] text NULL
, CONSTRAINT [sqlite_master_PK_EVENT_NOTE] PRIMARY KEY ([EventNoteID])
, FOREIGN KEY ([EventID]) REFERENCES [EVENT] ([EventID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [ENHANCEMENT] (
  [EnhancementID] INTEGER  NOT NULL
, [EnhName] text NOT NULL
, [EnhDescription] text NOT NULL
, [EnhBonus] text NOT NULL
, CONSTRAINT [sqlite_master_PK_ENHANCEMENT] PRIMARY KEY ([EnhancementID])
);
CREATE TABLE [ENCOUNTER] (
  [EncounterID] INTEGER  NOT NULL
, [StoryID] bigint  NOT NULL
, [EncounterName] text NOT NULL
, [EncounterType] text NOT NULL
, CONSTRAINT [sqlite_master_PK_ENCOUNTER] PRIMARY KEY ([EncounterID])
, FOREIGN KEY ([StoryID]) REFERENCES [STORY] ([StoryID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [ENCOUNTER_PLOT] (
  [EncounterPlotID] INTEGER  NOT NULL
, [EncounterID] bigint  NOT NULL
, [PlotID] bigint  NOT NULL
, CONSTRAINT [sqlite_master_PK_ENCOUNTER_PLOT] PRIMARY KEY ([EncounterPlotID])
, FOREIGN KEY ([PlotID]) REFERENCES [PLOT] ([PlotID]) ON DELETE CASCADE ON UPDATE CASCADE
, FOREIGN KEY ([EncounterID]) REFERENCES [ENCOUNTER] ([EncounterID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [BESTIARY] (
  [BeastID] INTEGER  NOT NULL
, [Name] text NOT NULL
, [CR] real NOT NULL
, [XP] bigint  NULL
, [Race] text NULL
, [Class1] text NULL
, [Class1Level] bigint  NULL
, [Class2] text NULL
, [Class2Level] bigint  NULL
, [Alignment] text NULL
, [Size] text NULL
, [Type] text NULL
, [SubType1] text NULL
, [SubType2] text NULL
, [SubType3] text NULL
, [SubType4] text NULL
, [SubType5] text NULL
, [SubType6] text NULL
, [AC] bigint  NULL
, [ACTouch] bigint  NULL
, [ACFlatFooted] bigint  NULL
, [HP] bigint  NULL
, [HD] text NULL
, [Fort] text NULL
, [Ref] text NULL
, [Will] text NULL
, [Melee] text NULL
, [Ranged] text NULL
, [Reach] text NULL
, [Str] text NULL
, [Dex] text NULL
, [Con] text NULL
, [Int] text NULL
, [Wis] text NULL
, [Cha] text NULL
, [Feats] text NULL
, [Skills] text NULL
, [RacialMods] text NULL
, [Languages] text NULL
, [SQ] text NULL
, [Environment] text NULL
, [Organization] text NULL
, [Treasure] text NULL
, [Group] text NULL
, [Gear] text NULL
, [OtherGear] text NULL
, [Speed] text NULL
, CONSTRAINT [sqlite_master_PK_BESTIARY] PRIMARY KEY ([BeastID])
);
CREATE TABLE [ENCOUNTER_BESTIARY] (
  [EncounterBestiaryID] INTEGER  NOT NULL
, [EncounterID] bigint  NOT NULL
, [BeastID] bigint  NOT NULL
, CONSTRAINT [sqlite_master_PK_ENCOUNTER_BESTIARY] PRIMARY KEY ([EncounterBestiaryID])
, FOREIGN KEY ([EncounterID]) REFERENCES [ENCOUNTER] ([EncounterID]) ON DELETE CASCADE ON UPDATE CASCADE
, FOREIGN KEY ([BeastID]) REFERENCES [BESTIARY] ([BeastID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE UNIQUE INDEX [sqlite_autoindex_STORY_1] ON [STORY] ([StoryID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_UPDATED_1] ON [UPDATED] ([UpdatedID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_SPELL_1] ON [SPELL] ([SpellID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_SKILL_1] ON [SKILL] ([SkillID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_PLOT_1] ON [PLOT] ([PlotID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_PLAYER_1] ON [PLAYER] ([PlayerID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_PLAYER_SKILL_1] ON [PLAYER_SKILL] ([PlayerSkillID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_MAP_1] ON [MAP] ([MapID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_LAYER_1] ON [LAYER] ([LayerID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_PUSHPIN_1] ON [PUSHPIN] ([PushPinID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_REGION_1] ON [REGION] ([RegionID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_REGION_POINTS_1] ON [REGION_POINTS] ([RegionPointsID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_LANGUAGE_1] ON [LANGUAGE] ([LanguageID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_PLAYER_LANGUAGE_1] ON [PLAYER_LANGUAGE] ([PlayerLanguageID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_FEAT_1] ON [FEAT] ([FeatID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_FACTION_1] ON [FACTION] ([FactionID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_PLAYER_FACTION_1] ON [PLAYER_FACTION] ([PlayerFactionID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_EVENT_1] ON [EVENT] ([EventID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_EVENT_PLOT_1] ON [EVENT_PLOT] ([EventPlotID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_EVENT_NOTE_1] ON [EVENT_NOTE] ([EventNoteID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_ENHANCEMENT_1] ON [ENHANCEMENT] ([EnhancementID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_ENCOUNTER_1] ON [ENCOUNTER] ([EncounterID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_ENCOUNTER_PLOT_1] ON [ENCOUNTER_PLOT] ([EncounterPlotID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_BESTIARY_1] ON [BESTIARY] ([BeastID] ASC);
CREATE UNIQUE INDEX [sqlite_autoindex_ENCOUNTER_BESTIARY_1] ON [ENCOUNTER_BESTIARY] ([EncounterBestiaryID] ASC);
COMMIT;

