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
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Documents;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace testapp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Exercise2 : Page
    {
        public Exercise2()
        {
            this.InitializeComponent();
            Result();
            ResultText();
        }        

        /// <summary>
        /// This method iterates from 1 to 200 and identifies when the number is divisible by: 3, 5 and both (3 & 5        
        /// Every time the stated above is true, adds a text to tbActualResult (3 = 'fizz', 5 = 'buzz', 3 & 5 = 'fizzbuzz'
        /// </summary>
        public void Result()
        {
            // iterate from 1 to 200 
            for (int i = 1; i < 200; i++)
            {
                // Checks if the number is divisible by 3, comparing if the result equals 0
                if (i % 3 == 0 && i % 5 == 0)
                {
                    tbActualResult.Text += "fizzbuzz ";
                }
                // Checks if the number is divisible by 3, comparing if the result equals 0
                else if (i % 3 == 0)
                {
                    tbActualResult.Text += "fizz ";
                }
                // Checks if the number is divisible by 5, comparing if the result equals 0
                else if (i % 5 == 0)
                {
                    tbActualResult.Text += "buzz ";
                }
            }
        }

        /// <summary>
        /// This method creats a richtextblock and add some text
        /// </summary>
        private void ResultText()
        {
            // Create a RichTextBlock, a Paragraph and a Run.
            RichTextBlock richTextBlock = new RichTextBlock();
            Paragraph paragraph = new Paragraph();
            Run run = new Run();

            // Customize some properties on the RichTextBlock.
            richTextBlock.IsTextSelectionEnabled = true;
            richTextBlock.TextWrapping = TextWrapping.Wrap;
            run.Text = @"public void Result()
{
    // iterate from 1 to 200 
    for (int i = 1; i < 200; i++)
    {
        // Checks if the number is divisible by 3, comparing if the result equals 0
        if (i % 3 == 0 && i % 5 == 0)
        {
            tbActualResult.Text += 'fizzbuzz ';
        }
        // Checks if the number is divisible by 3, comparing if the result equals 0
        else if (i % 3 == 0)
        {
            tbActualResult.Text += 'fizz ';
        }
        // Checks if the number is divisible by 5, comparing if the result equals 0
        else if (i % 5 == 0)
        {
            tbActualResult.Text += 'buzz ';
        }
    }
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
