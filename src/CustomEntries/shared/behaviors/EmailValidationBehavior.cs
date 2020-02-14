using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomEntries
{
    public class EmailValidationBehavior : Behavior<ConfirmFloatingLabelEntry>
    {
        ConfirmFloatingLabelEntry _currentView;

        protected override void OnAttachedTo(ConfirmFloatingLabelEntry bindable)
        {
            base.OnAttachedTo(bindable);

            _currentView = bindable;

            bindable.TextChangedHandlerAsync += (sender, e) => OnEntryTextChanged(sender, e);
        }

        protected override void OnDetachingFrom(ConfirmFloatingLabelEntry bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.TextChangedHandlerAsync -= OnEntryTextChanged;
        }

        Task OnEntryTextChanged(object sender, EventArgs e)
        {
            var entry = (Entry)sender;

            if (entry.Text == null)
                return Task.CompletedTask;

            _currentView.IsValid = IsValidEmail(entry.Text);

            return Task.CompletedTask;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
