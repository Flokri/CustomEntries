using System;
using System.Collections.Generic;
using System.Text;
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

            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(ConfirmFloatingLabelEntry bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            if (entry.Text == null)
                return;

            _currentView.IsValid = IsValidEmail(entry.Text);
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
