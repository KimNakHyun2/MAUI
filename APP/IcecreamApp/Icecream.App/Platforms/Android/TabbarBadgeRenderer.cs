using Google.Android.Material.Badge;
using Google.Android.Material.BottomNavigation;
using Icecream.App.ViewModels;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icecream.App;

public class TabbarBadgeRenderer : ShellRenderer
{
    protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
    {
        //return base.CreateBottomNavViewAppearanceTracker(shellItem);
        return new BadgeShellBottomNavViewAppearanceTracker(this, shellItem);
    }

    class BadgeShellBottomNavViewAppearanceTracker : ShellBottomNavViewAppearanceTracker
    {
        private BadgeDrawable _badgeDrawable;
        public BadgeShellBottomNavViewAppearanceTracker(IShellContext shellContext, ShellItem shellItem) : base(shellContext, shellItem)
        {
        }

        public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            base.SetAppearance(bottomView, appearance);

            const int cartTabbarItemIndex = 1;
            _badgeDrawable = bottomView.GetOrCreateBadge(cartTabbarItemIndex);
            UpdateBadge(CartViewModel.TotalCartCount);
            CartViewModel.TotalCartCountChanged += CartViewModel_TotalCartCountChanged;
        }

        private void CartViewModel_TotalCartCountChanged(object? sender, int newTotalCartCount) => UpdateBadge(newTotalCartCount);

        private void UpdateBadge(int count)
        {
            if (count <= 0)
            {
                _badgeDrawable.SetVisible(false);
            }
            else 
            {
                _badgeDrawable.Number = count;
                _badgeDrawable.BackgroundColor = Colors.DeepPink.ToPlatform();
                _badgeDrawable.BadgeTextColor = Colors.White.ToPlatform();
                _badgeDrawable.SetVisible(true);
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            CartViewModel.TotalCartCountChanged -= CartViewModel_TotalCartCountChanged;
            base.Dispose(disposing);
        }
    }
}
