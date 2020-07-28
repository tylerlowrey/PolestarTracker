using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PolestarTracker.WPF.UI.AttachedProperties
{
    /**
     * Adapted from: https://stackoverflow.com/questions/7417739/make-wpf-window-draggable-no-matter-what-element-is-clicked/35945363#35945363
     * Poster: https://stackoverflow.com/users/107409/contango
     */
    class DragHelper
    {
         public static readonly DependencyProperty EnableDragProperty = DependencyProperty.RegisterAttached(
            "EnableDrag",
            typeof(bool),
            typeof(DragHelper),
            new PropertyMetadata(default(bool), OnLoaded));

        private static void OnLoaded(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var uiElement = dependencyObject as UIElement;
            if (uiElement == null || (dependencyPropertyChangedEventArgs.NewValue is bool) == false)
            {
                return;
            }

            if ((bool) dependencyPropertyChangedEventArgs.NewValue == true)
            {
                uiElement.MouseMove += UIElementOnMouseMove;
            }
            else
            {
                uiElement.MouseMove -= UIElementOnMouseMove;
            }

        }

        private static void UIElementOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            var uiElement = sender as UIElement;
            if (uiElement != null)
            {
                if (mouseEventArgs.LeftButton == MouseButtonState.Pressed)
                {
                    DependencyObject parent = uiElement;
                    int avoidInfiniteLoop = 0;
                    // Search up the visual tree to find the first parent window.
                    while ((parent is Window) == false)
                    {
                        parent = VisualTreeHelper.GetParent(parent);
                        avoidInfiniteLoop++;
                        if (avoidInfiniteLoop == 1000)
                        {
                            // Something is wrong - we could not find the parent window.
                            return;
                        }
                    }

                    var window = parent as Window;
                    window.DragMove();
                }
            }
        }

        public static void SetEnableDrag(DependencyObject element, bool value)
        {
            element.SetValue(EnableDragProperty, value);
        }

        public static bool GetEnableDrag(DependencyObject element)
        {
            return (bool) element.GetValue(EnableDragProperty);
        }
    }
}
