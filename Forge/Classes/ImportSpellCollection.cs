using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class ImportSpellCollection : PropertyChangedBase
    {
        private string _spellName;
        private string _school;
        private string _subSchool;
        private string _effect;
        private string _castingTime;
        private string _components;
        private string _range;
        private string _area;
        private string _targets;
        private string _duration;
        private string _savingThrow;
        private string _spellResistance;
        private string _description;
        private string _level;
        private string _shortDescription;
        private string _domain;

        public string SpellName
        {
            get { return _spellName; }
            set
            {
                if (_spellName != value)
                {
                    _spellName = value;
                    NotifyOfPropertyChange(() => SpellName);
                }
            }
        }
        public string School
        {
            get { return _school; }
            set
            {
                if (_school != value)
                {
                    _school = value;
                    NotifyOfPropertyChange(() => School);
                }
            }
        }
        public string SubSchool
        {
            get { return _subSchool; }
            set
            {
                if (_subSchool != value)
                {
                    _subSchool = value;
                    NotifyOfPropertyChange(() => SubSchool);
                }
            }
        }
        public string Effect
        {
            get { return _effect; }
            set
            {
                if (_effect != value)
                {
                    _effect = value;
                    NotifyOfPropertyChange(() => Effect);
                }
            }
        }
        public string CastingTime
        {
            get { return _castingTime; }
            set
            {
                if (_castingTime != value)
                {
                    _castingTime = value;
                    NotifyOfPropertyChange(() => CastingTime);
                }
            }
        }
        public string Components
        {
            get { return _components; }
            set
            {
                if (_components != value)
                {
                    _components = value;
                    NotifyOfPropertyChange(() => Components);
                }
            }
        }
        public string Range
        {
            get { return _range; }
            set
            {
                if (_range != value)
                {
                    _range = value;
                    NotifyOfPropertyChange(() => Range);
                }
            }
        }
        public string Area
        {
            get { return _area; }
            set
            {
                if (_area != value)
                {
                    _area = value;
                    NotifyOfPropertyChange(() => Area);
                }
            }
        }
        public string Targets
        {
            get { return _targets; }
            set
            {
                if (_targets != value)
                {
                    _targets = value;
                    NotifyOfPropertyChange(() => Targets);
                }
            }
        }
        public string Duration
        {
            get { return _duration; }
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    NotifyOfPropertyChange(() => Duration);
                }
            }
        }
        public string SavingThrow
        {
            get { return _savingThrow; }
            set
            {
                if (_savingThrow != value)
                {
                    _savingThrow = value;
                    NotifyOfPropertyChange(() => SavingThrow);
                }
            }
        }
        public string SpellResistance
        {
            get { return _spellResistance; }
            set
            {
                if (_spellResistance != value)
                {
                    _spellResistance = value;
                    NotifyOfPropertyChange(() => SpellResistance);
                }
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    NotifyOfPropertyChange(() => Description);
                }
            }
        }
        public string Level
        {
            get { return _level; }
            set
            {
                if (_level != value)
                {
                    _level = value;
                    NotifyOfPropertyChange(() => Level);
                }
            }
        }
        public string ShortDescription
        {
            get { return _shortDescription; }
            set
            {
                if (_shortDescription != value)
                {
                    _shortDescription = value;
                    NotifyOfPropertyChange(() => ShortDescription);
                }
            }
        }
        public string Domain
        {
            get { return _domain; }
            set
            {
                if (_domain != value)
                {
                    _domain = value;
                    NotifyOfPropertyChange(() => Domain);
                }
            }
        }
    }
}
