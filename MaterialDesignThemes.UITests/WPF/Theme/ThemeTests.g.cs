using System.Windows.Media;

namespace MaterialDesignThemes.UITests.WPF.Theme;

partial class ThemeTests
{
    private partial string GetXamlWrapPanel()
    {
        return """
        <WrapPanel>
          <WrapPanel.Resources>
            <Style TargetType="TextBlock">
              <Setter Property="Height" Value="50"/>
              <Setter Property="Width" Value="50"/>
            </Style>
          </WrapPanel.Resources>
          <TextBlock Text="Background" Background="{StaticResource MaterialDesign.Brush.Background}" />
          <TextBlock Text="Foreground" Background="{StaticResource MaterialDesign.Brush.Foreground}" />
          <TextBlock Text="ForegroundLight" Background="{StaticResource MaterialDesign.Brush.ForegroundLight}" />
          <TextBlock Text="ValidationError" Background="{StaticResource MaterialDesign.Brush.ValidationError}" />
          <TextBlock Text="Card.Background" Background="{StaticResource MaterialDesign.Brush.Card.Background}" />
          <TextBlock Text="Button.FlatClick" Background="{StaticResource MaterialDesign.Brush.Button.FlatClick}" />
          <TextBlock Text="Button.Ripple" Background="{StaticResource MaterialDesign.Brush.Button.Ripple}" />
          <TextBlock Text="Button.FlatRipple" Background="{StaticResource MaterialDesign.Brush.Button.FlatRipple}" />
          <TextBlock Text="SnackBar.Ripple" Background="{StaticResource MaterialDesign.Brush.SnackBar.Ripple}" />
          <TextBlock Text="SnackBar.Background" Background="{StaticResource MaterialDesign.Brush.SnackBar.Background}" />
          <TextBlock Text="SnackBar.MouseOver" Background="{StaticResource MaterialDesign.Brush.SnackBar.MouseOver}" />
          <TextBlock Text="CheckBox.Disabled" Background="{StaticResource MaterialDesign.Brush.CheckBox.Disabled}" />
          <TextBlock Text="CheckBox.Off" Background="{StaticResource MaterialDesign.Brush.CheckBox.Off}" />
          <TextBlock Text="Chip.Background" Background="{StaticResource MaterialDesign.Brush.Chip.Background}" />
          <TextBlock Text="DataGrid.ButtonPressed" Background="{StaticResource MaterialDesign.Brush.DataGrid.ButtonPressed}" />
          <TextBlock Text="DataGrid.ComboBoxSelected" Background="{StaticResource MaterialDesign.Brush.DataGrid.ComboBoxSelected}" />
          <TextBlock Text="DataGrid.RowHoverBackground" Background="{StaticResource MaterialDesign.Brush.DataGrid.RowHoverBackground}" />
          <TextBlock Text="DataGrid.Selected" Background="{StaticResource MaterialDesign.Brush.DataGrid.Selected}" />
          <TextBlock Text="DataGrid.ColumnHeaderForeground" Background="{StaticResource MaterialDesign.Brush.DataGrid.ColumnHeaderForeground}" />
          <TextBlock Text="TextBox.Border" Background="{StaticResource MaterialDesign.Brush.TextBox.Border}" />
          <TextBlock Text="TextBox.OutlineBorder" Background="{StaticResource MaterialDesign.Brush.TextBox.OutlineBorder}" />
          <TextBlock Text="TextBox.DisabledBackground" Background="{StaticResource MaterialDesign.Brush.TextBox.DisabledBackground}" />
          <TextBlock Text="TextBox.FilledBackground" Background="{StaticResource MaterialDesign.Brush.TextBox.FilledBackground}" />
          <TextBlock Text="TextBox.HoverBackground" Background="{StaticResource MaterialDesign.Brush.TextBox.HoverBackground}" />
          <TextBlock Text="TextBox.OutlineInactiveBorder" Background="{StaticResource MaterialDesign.Brush.TextBox.OutlineInactiveBorder}" />
          <TextBlock Text="GridSplitter.Background" Background="{StaticResource MaterialDesign.Brush.GridSplitter.Background}" />
          <TextBlock Text="Header.Foreground" Background="{StaticResource MaterialDesign.Brush.Header.Foreground}" />
          <TextBlock Text="ListView.Selected" Background="{StaticResource MaterialDesign.Brush.ListView.Selected}" />
          <TextBlock Text="ScrollBar.Foreground" Background="{StaticResource MaterialDesign.Brush.ScrollBar.Foreground}" />
          <TextBlock Text="ScrollBar.RepeatButtonBackground" Background="{StaticResource MaterialDesign.Brush.ScrollBar.RepeatButtonBackground}" />
          <TextBlock Text="Separator.Background" Background="{StaticResource MaterialDesign.Brush.Separator.Background}" />
          <TextBlock Text="ToolBar.Background" Background="{StaticResource MaterialDesign.Brush.ToolBar.Background}" />
          <TextBlock Text="ToolBar.Item.Background" Background="{StaticResource MaterialDesign.Brush.ToolBar.Item.Background}" />
          <TextBlock Text="ToolBar.Item.Foreground" Background="{StaticResource MaterialDesign.Brush.ToolBar.Item.Foreground}" />
          <TextBlock Text="ToolTip.Background" Background="{StaticResource MaterialDesign.Brush.ToolTip.Background}" />
        </WrapPanel>
        """;
    }
    private partial async Task AssertAllThemeBrushesSet(IVisualElement<WrapPanel> panel)
    {
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.Background");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"Background\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.Foreground");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"Foreground\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.ForegroundLight");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"ForegroundLight\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.ValidationError");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"ValidationError\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.Card.Background");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"Card.Background\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.Button.FlatClick");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"Button.FlatClick\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.Button.Ripple");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"Button.Ripple\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.Button.FlatRipple");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"Button.FlatRipple\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.SnackBar.Ripple");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"SnackBar.Ripple\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.SnackBar.Background");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"SnackBar.Background\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.SnackBar.MouseOver");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"SnackBar.MouseOver\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.CheckBox.Disabled");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"CheckBox.Disabled\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.CheckBox.Off");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"CheckBox.Off\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.Chip.Background");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"Chip.Background\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.DataGrid.ButtonPressed");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"DataGrid.ButtonPressed\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.DataGrid.ComboBoxSelected");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"DataGrid.ComboBoxSelected\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.DataGrid.RowHoverBackground");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"DataGrid.RowHoverBackground\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.DataGrid.Selected");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"DataGrid.Selected\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.DataGrid.ColumnHeaderForeground");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"DataGrid.ColumnHeaderForeground\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.TextBox.Border");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"TextBox.Border\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.TextBox.OutlineBorder");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"TextBox.OutlineBorder\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.TextBox.DisabledBackground");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"TextBox.DisabledBackground\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.TextBox.FilledBackground");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"TextBox.FilledBackground\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.TextBox.HoverBackground");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"TextBox.HoverBackground\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.TextBox.OutlineInactiveBorder");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"TextBox.OutlineInactiveBorder\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.GridSplitter.Background");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"GridSplitter.Background\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.Header.Foreground");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"Header.Foreground\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.ListView.Selected");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"ListView.Selected\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.ScrollBar.Foreground");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"ScrollBar.Foreground\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.ScrollBar.RepeatButtonBackground");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"ScrollBar.RepeatButtonBackground\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.Separator.Background");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"Separator.Background\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.ToolBar.Background");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"ToolBar.Background\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.ToolBar.Item.Background");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"ToolBar.Item.Background\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.ToolBar.Item.Foreground");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"ToolBar.Item.Foreground\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
        {
            IResource resource = await App.GetResource("MaterialDesign.Brush.ToolTip.Background");
            SolidColorBrush? brush = resource.GetAs<SolidColorBrush>();
            IVisualElement<TextBlock> textBlock = await panel.GetElement<TextBlock>("[Text=\"ToolTip.Background\"]");
            Color? textBlockBackground = await textBlock.GetBackgroundColor();
            Assert.Equal(brush?.Color, textBlockBackground);
        }
    }
}
