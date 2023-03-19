using System.Reflection;

namespace MaterialDesignThemes.UITests.WPF.Theme;

public partial class ThemeTests : TestBase
{
    public ThemeTests(ITestOutputHelper output)
        : base(output)
    { }

    public async void WhenUsingBuiltInThemeDictionary_AllBrushesApplied()
    {
        IVisualElement<WrapPanel> panel = await Initialize("""
            <materialDesign:BundledTheme BaseTheme="Inherit"
                ColorAdjustment="{materialDesign:ColorAdjustment}"
                PrimaryColor="DeepPurple"
                SecondaryColor="Lime" />
            """);
    }

    protected async Task<IVisualElement<WrapPanel>> Initialize(string themeDictionary)
    {
        string applicationResourceXaml = $"""
            <ResourceDictionary 
                xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
                xmlns:materialDesign=""http://materialdesigninxaml.net/winfx/xaml/themes"">
                <ResourceDictionary.MergedDictionaries>
                    {themeDictionary}

                    <ResourceDictionary Source=""pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/Generic.xaml"" />
                    <ResourceDictionary Source=""pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml"" />
                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>
            """;

        await App.Initialize(applicationResourceXaml,
            Path.GetFullPath("MaterialDesignColors.dll"),
            Path.GetFullPath("MaterialDesignThemes.Wpf.dll"),
            Assembly.GetExecutingAssembly().Location);
        return await App.CreateWindowWith<WrapPanel>("");
    }
}
