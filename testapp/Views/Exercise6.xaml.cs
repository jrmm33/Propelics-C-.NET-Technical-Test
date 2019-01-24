using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace testapp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Exercise6 : Page
    {
        public Exercise6()
        {
            this.InitializeComponent();
            ResultText();
        }

        private void TxtString1_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbActualResult.Text = ReverseString(txtString1.Text);
        }

        /// <summary>
        /// This method recieve a strings iterates between its characters and
        /// reverse the order
        /// </summary>
        /// <param name="string1"></param>
        /// <returns>string</returns>
        public static string ReverseString(string string1)
        {
            char[] chars = string1.ToCharArray();

            //sets two counters one that will go from start to finish
            //the other one goes from finish to last
            for (int i = 0, j = string1.Length - 1; i < j; i++, j--)
            {
                chars[i] = string1[j];
                chars[j] = string1[i];
            }
            return new string(chars);
        }

        private void ResultText()
        {
            // Create a RichTextBlock, a Paragraph and a Run.
            RichTextBlock richTextBlock = new RichTextBlock();
            Paragraph paragraph = new Paragraph();
            Run run = new Run();

            // Customize some properties on the RichTextBlock.
            richTextBlock.IsTextSelectionEnabled = true;
            richTextBlock.TextWrapping = TextWrapping.Wrap;
            run.Text = @"public static string ReverseString(string string1)
{
    char[] chars = string1.ToCharArray();

    //sets two counters one that will go from start to finish
    //the other one goes from finish to last
    for (int i = 0, j = string1.Length - 1; i < j; i++, j--)
    {
        chars[i] = string1[j];
        chars[j] = string1[i];
    }
    return new string(chars);
}
            ";
            richTextBlock.TextAlignment = TextAlignment.Left;

            // Add the Run to the Paragraph, the Paragraph to the RichTextBlock.
            paragraph.Inlines.Add(run);
            richTextBlock.Blocks.Add(paragraph);

            // Add the RichTextBlock to the visual tree (assumes stackPanel is decalred in XAML).
            grdResultText.Children.Add(richTextBlock);
        }        
    }
}
