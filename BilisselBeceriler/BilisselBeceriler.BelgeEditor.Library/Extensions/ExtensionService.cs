using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BilisselBeceriler.BelgeEditor.Library.Extensions
{
    public static class ExtensionService
    {
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static T FindChildByName<T>(DependencyObject parent, string childName) where T : DependencyObject
        {

            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                var childType = child as T;
                if (childType == null)
                {
                    foundChild = FindChildByName<T>(child, childName);

                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }

        public static T FindChildByTag<T>(DependencyObject parent, string tagName) where T : DependencyObject
        {

            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                var childType = child as T;
                if (childType == null)
                {
                    foundChild = FindChildByTag<T>(child, tagName);

                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(tagName))
                {
                    var frameworkElement = child as FrameworkElement;
                    if (frameworkElement != null && frameworkElement.Tag != null && frameworkElement.Tag.ToString().ToLower() == tagName.ToLower())
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }

        public static List<T> FindAllChildByTag<T>(DependencyObject parent, string tagName) where T : Shape
        {
            return FindVisualChildren<T>(parent).Where(item => item.Tag != null && item.Tag.ToString().ToLower() == tagName.ToLower()).ToList();
        }
        public static List<T> FindAllControlsByTag<T>(DependencyObject parent, string tagName) where T : Control
        {
            return FindVisualChildren<T>(parent).Where(item => item.Tag != null && item.Tag.ToString().ToLower() == tagName.ToLower()).ToList();
        }
        public static List<T> FindAllChildByTagContains<T>(DependencyObject parent, string tagName) where T : Shape
        {
            return FindVisualChildren<T>(parent).Where(item => item.Tag != null && item.Tag.ToString().ToLower().Contains(tagName.ToLower())).ToList();
        }
    }
}
