﻿using System.Windows.Media;
using System.Windows.Media.Animation;
using MaterialDesignColors;
using MaterialDesignColors.ColorManipulation;

namespace MaterialDesignThemes.Wpf;

public static partial class ResourceDictionaryExtensions
{
    private const string CurrentThemeKey = nameof(MaterialDesignThemes) + "." + nameof(CurrentThemeKey);
    private const string ThemeManagerKey = nameof(MaterialDesignThemes) + "." + nameof(ThemeManagerKey);

    public static void SetTheme(this ResourceDictionary resourceDictionary, Theme theme)
        => SetTheme(resourceDictionary, theme, null);

    public static void SetTheme(this ResourceDictionary resourceDictionary, Theme theme, ColorAdjustment? colorAdjustment)
    {
        if (resourceDictionary is null) throw new ArgumentNullException(nameof(resourceDictionary));

        if (theme is Theme internalTheme)
        {
            colorAdjustment ??= internalTheme.ColorAdjustment;
            internalTheme.ColorAdjustment = colorAdjustment;
        }

        Color primaryLight = theme.PrimaryLight.Color;
        Color primaryMid = theme.PrimaryMid.Color;
        Color primaryDark = theme.PrimaryDark.Color;

        Color secondaryLight = theme.SecondaryLight.Color;
        Color secondaryMid = theme.SecondaryMid.Color;
        Color secondaryDark = theme.SecondaryDark.Color;

        if (colorAdjustment is { })
        {
            if (colorAdjustment.Colors.HasFlag(ColorSelection.Primary))
            {
                AdjustColors(theme.Paper, colorAdjustment, ref primaryLight, ref primaryMid, ref primaryDark);
            }
            if (colorAdjustment.Colors.HasFlag(ColorSelection.Secondary))
            {
                AdjustColors(theme.Paper, colorAdjustment, ref secondaryLight, ref secondaryMid, ref secondaryDark);
            }
        }

        SetSolidColorBrush(resourceDictionary, "PrimaryHueLightBrush", primaryLight);
        SetSolidColorBrush(resourceDictionary, "PrimaryHueLightForegroundBrush", theme.PrimaryLight.ForegroundColor ?? primaryLight.ContrastingForegroundColor());
        SetSolidColorBrush(resourceDictionary, "PrimaryHueMidBrush", primaryMid);
        SetSolidColorBrush(resourceDictionary, "PrimaryHueMidForegroundBrush", theme.PrimaryMid.ForegroundColor ?? primaryMid.ContrastingForegroundColor());
        SetSolidColorBrush(resourceDictionary, "PrimaryHueDarkBrush", primaryDark);
        SetSolidColorBrush(resourceDictionary, "PrimaryHueDarkForegroundBrush", theme.PrimaryDark.ForegroundColor ?? primaryDark.ContrastingForegroundColor());

        SetSolidColorBrush(resourceDictionary, "SecondaryHueLightBrush", secondaryLight);
        SetSolidColorBrush(resourceDictionary, "SecondaryHueLightForegroundBrush", theme.SecondaryLight.ForegroundColor ?? secondaryLight.ContrastingForegroundColor());
        SetSolidColorBrush(resourceDictionary, "SecondaryHueMidBrush", secondaryMid);
        SetSolidColorBrush(resourceDictionary, "SecondaryHueMidForegroundBrush", theme.SecondaryMid.ForegroundColor ?? secondaryMid.ContrastingForegroundColor());
        SetSolidColorBrush(resourceDictionary, "SecondaryHueDarkBrush", secondaryDark);
        SetSolidColorBrush(resourceDictionary, "SecondaryHueDarkForegroundBrush", theme.SecondaryDark.ForegroundColor ?? secondaryDark.ContrastingForegroundColor());

        SetSolidColorBrush(resourceDictionary, "MaterialDesignValidationErrorBrush", theme.ValidationError);
        resourceDictionary["MaterialDesignValidationErrorColor"] = theme.ValidationError;

        ApplyThemeColors(resourceDictionary, theme);

        if (resourceDictionary.GetThemeManager() is not ThemeManager themeManager)
        {
            resourceDictionary[ThemeManagerKey] = themeManager = new ThemeManager(resourceDictionary);
        }
        Theme oldTheme = resourceDictionary.GetTheme();
        resourceDictionary[CurrentThemeKey] = theme;

        themeManager.OnThemeChange(oldTheme, theme);
    }

    private static partial void ApplyThemeColors(ResourceDictionary resourceDictionary, Theme theme);

    public static Theme GetTheme(this ResourceDictionary resourceDictionary)
    {
        if (resourceDictionary is null) throw new ArgumentNullException(nameof(resourceDictionary));
        if (resourceDictionary[CurrentThemeKey] is Theme theme)
        {
            return theme;
        }

        Color secondaryMid = GetColor(resourceDictionary, "SecondaryHueMidBrush");
        Color secondaryMidForeground = GetColor(resourceDictionary, "SecondaryHueMidForegroundBrush");

        if (!TryGetColor(resourceDictionary, "SecondaryHueLightBrush", out Color secondaryLight))
        {
            secondaryLight = secondaryMid.Lighten();
        }
        if (!TryGetColor(resourceDictionary, "SecondaryHueLightForegroundBrush", out Color secondaryLightForeground))
        {
            secondaryLightForeground = secondaryLight.ContrastingForegroundColor();
        }

        if (!TryGetColor(resourceDictionary, "SecondaryHueDarkBrush", out Color secondaryDark))
        {
            secondaryDark = secondaryMid.Darken();
        }
        if (!TryGetColor(resourceDictionary, "SecondaryHueDarkForegroundBrush", out Color secondaryDarkForeground))
        {
            secondaryDarkForeground = secondaryDark.ContrastingForegroundColor();
        }

        theme = new Theme
        {
            PrimaryLight = new ColorPair(GetColor(resourceDictionary, "PrimaryHueLightBrush"), GetColor(resourceDictionary, "PrimaryHueLightForegroundBrush")),
            PrimaryMid = new ColorPair(GetColor(resourceDictionary, "PrimaryHueMidBrush"), GetColor(resourceDictionary, "PrimaryHueMidForegroundBrush")),
            PrimaryDark = new ColorPair(GetColor(resourceDictionary, "PrimaryHueDarkBrush"), GetColor(resourceDictionary, "PrimaryHueDarkForegroundBrush")),

            SecondaryLight = new ColorPair(secondaryLight, secondaryLightForeground),
            SecondaryMid = new ColorPair(secondaryMid, secondaryMidForeground),
            SecondaryDark = new ColorPair(secondaryDark, secondaryDarkForeground),
        };
        LoadThemeColors(resourceDictionary, theme);
        return theme;
    }

    private static partial void LoadThemeColors(ResourceDictionary resourceDictionary, Theme theme);

    private static Color GetColor(ResourceDictionary resourceDictionary, params string[] keys)
    {
        foreach (string key in keys)
        {
            if (TryGetColor(resourceDictionary, key, out Color color))
            {
                return color;
            }
        }
        throw new InvalidOperationException($"Could not locate required resource with key(s) '{string.Join(", ", keys)}'");
    }

    private static bool TryGetColor(ResourceDictionary resourceDictionary, string key, out Color color)
    {
        if (resourceDictionary[key] is SolidColorBrush brush)
        {
            color = brush.Color;
            return true;
        }
        color = default;
        return false;
    }

    public static IThemeManager? GetThemeManager(this ResourceDictionary resourceDictionary)
    {
        if (resourceDictionary is null) throw new ArgumentNullException(nameof(resourceDictionary));
        return resourceDictionary[ThemeManagerKey] as IThemeManager;
    }

    internal static void SetSolidColorBrush(this ResourceDictionary sourceDictionary, string name, Color value)
    {
        if (sourceDictionary is null) throw new ArgumentNullException(nameof(sourceDictionary));
        if (name is null) throw new ArgumentNullException(nameof(name));

        sourceDictionary[name + "Color"] = value;

        if (sourceDictionary[name] is SolidColorBrush brush)
        {
            if (brush.Color == value) return;

            if (!brush.IsFrozen)
            {
                var animation = new ColorAnimation
                {
                    From = brush.Color,
                    To = value,
                    Duration = new Duration(TimeSpan.FromMilliseconds(300))
                };
                brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                return;
            }
        }

        var newBrush = new SolidColorBrush(value);
        newBrush.Freeze();
        sourceDictionary[name] = newBrush;
    }

    private static void AdjustColors(Color background, ColorAdjustment colorAdjustment, ref Color light, ref Color mid, ref Color dark)
    {
        double offset;
        switch (colorAdjustment.Contrast)
        {
            case Contrast.Low:
                if (background.IsLightColor())
                {
                    dark = dark.EnsureContrastRatio(background, colorAdjustment.DesiredContrastRatio, out offset);
                    if (Math.Abs(offset) > 0.0)
                    {
                        mid = mid.ShiftLightness(offset);
                        light = light.ShiftLightness(offset);
                    }
                }
                else
                {
                    light = light.EnsureContrastRatio(background, colorAdjustment.DesiredContrastRatio, out offset);
                    if (Math.Abs(offset) > 0.0)
                    {
                        mid = mid.ShiftLightness(offset);
                        dark = dark.ShiftLightness(offset);
                    }
                }
                break;
            case Contrast.Medium:
                mid = mid.EnsureContrastRatio(background, colorAdjustment.DesiredContrastRatio, out offset);
                if (Math.Abs(offset) > 0.0)
                {
                    dark = dark.ShiftLightness(offset);
                    light = light.ShiftLightness(offset);
                }
                break;
            case Contrast.High:
                if (background.IsLightColor())
                {
                    light = light.EnsureContrastRatio(background, colorAdjustment.DesiredContrastRatio, out offset);
                    if (Math.Abs(offset) > 0.0)
                    {
                        mid = mid.ShiftLightness(offset);
                        dark = dark.ShiftLightness(offset);
                    }
                }
                else
                {
                    dark = dark.EnsureContrastRatio(background, colorAdjustment.DesiredContrastRatio, out offset);
                    if (Math.Abs(offset) > 0.0)
                    {
                        light = light.ShiftLightness(offset);
                        mid = mid.ShiftLightness(offset);
                    }
                }
                break;
        }
    }

    private class ThemeManager : IThemeManager
    {
        private readonly ResourceDictionary _resourceDictionary;

        public ThemeManager(ResourceDictionary resourceDictionary)
            => _resourceDictionary = resourceDictionary ?? throw new ArgumentNullException(nameof(resourceDictionary));

        public event EventHandler<ThemeChangedEventArgs>? ThemeChanged;

        public void OnThemeChange(Theme oldTheme, Theme newTheme)
            => ThemeChanged?.Invoke(this, new ThemeChangedEventArgs(_resourceDictionary, oldTheme, newTheme));
    }
}
