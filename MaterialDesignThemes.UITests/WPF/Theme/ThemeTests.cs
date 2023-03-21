using System.Reflection;
using System.Windows.Media;

namespace MaterialDesignThemes.UITests.WPF.Theme;

public partial class ThemeTests : TestBase
{
    public ThemeTests(ITestOutputHelper output)
        : base(output)
    { }

    [Fact]
    public async Task WhenUsingBuiltInThemeDictionary_AllBrushesApplied()
    {
        IVisualElement<WrapPanel> panel = await Initialize("""
            <materialDesign:BundledTheme BaseTheme="Inherit"
                ColorAdjustment="{materialDesign:ColorAdjustment}"
                PrimaryColor="DeepPurple"
                SecondaryColor="Lime" />
            """);

        await AssertAllThemeBrushesSet(panel);
    }

    private partial string GetXamlWrapPanel();
    private partial Task AssertAllThemeBrushesSet(IVisualElement<WrapPanel> panel);

    protected async Task<IVisualElement<WrapPanel>> Initialize(string themeDictionary)
    {
        string applicationResourceXaml = $"""
            <ResourceDictionary 
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes">
                <ResourceDictionary.MergedDictionaries>
                    {themeDictionary}

                    <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/Generic.xaml" />
                    <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml" />
                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>
            """;

        await App.Initialize(applicationResourceXaml,
            Path.GetFullPath("MaterialDesignColors.dll"),
            Path.GetFullPath("MaterialDesignThemes.Wpf.dll"),
            Assembly.GetExecutingAssembly().Location);
        return await App.CreateWindowWith<WrapPanel>(GetXamlWrapPanel());
    }
}
