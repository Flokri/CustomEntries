using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomEntries
{
    /// <summary>
    /// a behaviour to validata a entered email string
    /// </summary>
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

        /// <summary>
        /// checks if the enterd email is valid
        /// </summary>
        /// <param name="email">the string contains the email address</param>
        /// <returns>if the entered email is valid</returns>
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
