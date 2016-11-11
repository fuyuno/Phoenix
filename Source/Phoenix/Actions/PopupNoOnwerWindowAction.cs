using System;
using System.Windows;

using Prism.Interactivity;
using Prism.Interactivity.InteractionRequest;

namespace Phoenix.Actions
{
    internal class PopupNoOnwerWindowAction : PopupWindowAction
    {
        protected override Window GetWindow(INotification notification)
        {
            Window wrapperWindow;

            if (WindowContent != null)
            {
                wrapperWindow = CreateWindow();

                if (wrapperWindow == null)
                    throw new NullReferenceException("CreateWindow cannot return null");

                // If the WindowContent does not have its own DataContext, it will inherit this one.
                wrapperWindow.DataContext = notification;
                wrapperWindow.Title = notification.Title;

                PrepareContentForWindow(notification, wrapperWindow);
            }
            else
            {
                wrapperWindow = CreateDefaultWindow(notification);
            }

            // If the user provided a Style for a Window we set it as the window's style.
            if (WindowStyle != null)
                wrapperWindow.Style = WindowStyle;

            // If the user has provided a startup location for a Window we set it as the window's startup location.
            if (WindowStartupLocation.HasValue)
                wrapperWindow.WindowStartupLocation = WindowStartupLocation.Value;

            return wrapperWindow;
        }
    }
}