using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using Forge.Classes;
using System.Windows.Controls;
using Caliburn.Micro;

namespace Forge.ViewModels
{
    public class IconPackViewModel : Screen
    {
        private readonly Lazy<IEnumerable<ForgePackIconKind>> _forgePackIconKinds;

        public IconPackViewModel()
        {
            _forgePackIconKinds = new Lazy<IEnumerable<ForgePackIconKind>>(() =>
                Enum.GetValues(typeof(ForgePackIconKind)).OfType<ForgePackIconKind>()
                    .OrderBy(k => k.ToString(), StringComparer.InvariantCultureIgnoreCase).ToList()
                );

        }

        private IEnumerable<ForgePackIconKind> _kinds;
        public IEnumerable<ForgePackIconKind> Kinds
        {
            get { return _kinds ?? (_kinds = _forgePackIconKinds.Value); }
            set
            {
                _kinds = value;
                NotifyOfPropertyChange(() => Kinds);
            }
        }

        public void Search(object obj)
        {
            var text = obj as string;
            if (string.IsNullOrWhiteSpace(text))
                Kinds = _forgePackIconKinds.Value;
            else
                Kinds =
                    _forgePackIconKinds.Value.Where(
                        x => x.ToString().IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }

        public void CopyToClipboard(object obj)
        {
            var kind = (ForgePackIconKind?)obj;
            Clipboard.SetText($"<FC:ForgePackIcon Kind=\"{kind}\" />");
        }

        public void Search_OnKeyDown(string sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Search(sender);
        }
    }
}
