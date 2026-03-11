using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Kuwantima.Sandbox.Views.Pages
{
    public partial class DocumentsPage : UserControl
    {
        public DocumentsPage()
        {
            InitializeComponent();
        }

        private async void OnShowLicense(object? sender, RoutedEventArgs e)
        {
            var licenseText =
                """
                MIT License

                Copyright (c) 2025 Cole Larson

                Permission is hereby granted, free of charge, to any person obtaining a copy
                of this software and associated documentation files (the "Software"), to deal
                in the Software without restriction, including without limitation the rights
                to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                copies of the Software, and to permit persons to whom the Software is
                furnished to do so, subject to the following conditions:

                The above copyright notice and this permission notice shall be included in all
                copies or substantial portions of the Software.

                THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
                SOFTWARE.
                """;

            var dialog = new Window
            {
                Title = "MIT License",
                Width = 560,
                Height = 420,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Content = new Border
                {
                    Padding = new Avalonia.Thickness(24),
                    Child = new Grid
                    {
                        RowDefinitions = RowDefinitions.Parse("*,Auto"),
                        Children =
                        {
                            new ScrollViewer
                            {
                                Content = new SelectableTextBlock
                                {
                                    Text = licenseText,
                                    FontFamily = new Avalonia.Media.FontFamily("Cascadia Code,Consolas,Courier New"),
                                    FontSize = 12,
                                    TextWrapping = Avalonia.Media.TextWrapping.Wrap
                                }
                            },
                            new Button
                            {
                                Content = "Close",
                                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right,
                                Margin = new Avalonia.Thickness(0, 12, 0, 0),
                                [Grid.RowProperty] = 1
                            }
                        }
                    }
                }
            };

            // Wire close button
            if (dialog.Content is Border border
                && border.Child is Grid grid
                && grid.Children[1] is Button closeBtn)
            {
                closeBtn.Click += (_, _) => dialog.Close();
            }

            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel is Window owner)
                await dialog.ShowDialog(owner);
        }
    }
}
