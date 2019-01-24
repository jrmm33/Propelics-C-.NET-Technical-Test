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
    public sealed partial class Exercise7 : Page
    {

        public Exercise7()
        {
            this.InitializeComponent();
            ResultText();
        }

        private void TxtString_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtString1.Text != "" && txtString2.Text != "")
            {
                if (IsDigitsOnly(txtString1.Text) && IsDigitsOnly(txtString2.Text))
                {
                    Tuple<int, int> swapResult = SwapIntegers(Convert.ToInt32(txtString1.Text), Convert.ToInt32(txtString2.Text));
                    tbOriginal.Text = "Original Integer1 = " + txtString1.Text +", Integer2 = " + txtString2.Text;
                    tbActualResult.Text = "Swaped Integer1 = " + swapResult.Item1 + ", Integer2 = " + swapResult.Item2;
                }
                else
                {
                    tbActualResult.Text = "The fields don't accept letters or special charecters";
                }
            }
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                try
                {
                    if (c < '0' || c > '9')
                        return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// This method gets two integers and swaps them by
        /// because it cannot use a temporary variable 
        /// this approach uses add and substracting
        /// </summary>
        /// <param name="integer1"></param>
        /// <param name="integer2"></param>
        /// <returns></returns>
        public static Tuple<int,int> SwapIntegers(int integer1, int integer2)
        {
            // Swap logic
            integer1 += integer2; //integer1 becomes the sum of both integer1 and integer2
            integer2 = integer1 - integer2; // integer2 has the swapped value of integer1
            integer1 -= integer2; // integer1 has the swapped value of ineger2
            return Tuple.Create(integer1, integer2);
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
            run.Text = @"public static Tuple<int,int> SwapIntegers(int integer1, int integer2)
{
    // Swap logic
    integer1 += integer2; //integer1 becomes the sum of both integer1 and integer2
    integer2 = integer1 - integer2; // integer2 has the swapped value of integer1
    integer1 -= integer2; // integer1 has the swapped value of ineger2
    return Tuple.Create(integer1, integer2);
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
