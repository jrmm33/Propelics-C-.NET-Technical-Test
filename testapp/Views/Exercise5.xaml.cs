using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
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
    public sealed partial class Exercise5 : Page
    {
        public Exercise5()
        {
            this.InitializeComponent();
            ResultText();
        }

        private void TxtString1_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbActualResult.Text = StringCompress(txtString1.Text).ToString();
        }

        /// <summary>
        /// This method recieves a strings orders it, counts reapeted chars and 
        /// displays the character along side of the number of times it appears
        /// in the string.
        /// </summary>
        /// <param name="s1"></param>
        /// <returns>StringBuilder</returns>
        public static StringBuilder StringCompress(string s1)
        {
            char currentChar = s1[0];
            char[] s1Char ;
            int count = 0;
            StringBuilder strResult = new StringBuilder();

            //if the string lenght is one returns the same text
            if (s1.Length <= 1)
                return new StringBuilder(s1);

            //Set all charecters to lowercase
            s1 = s1.ToLower();

            // Remove white spaces 
            s1 = Regex.Replace(s1, @"\s+", "");

            //Convert string to char array
            s1Char = s1.ToArray();

            //Loops and counts repeated characters
            for (int i = 0; i < s1.Length; i++)
            {
                //Compares the character with the next one in the string
                if (currentChar != s1Char[i])
                {
                    strResult.Append(currentChar.ToString()).Append(count++.ToString());
                    currentChar = s1[i];
                    count = 0;
                }
                else
                {
                    count++;
                }
                //if its the last character adds the last character and its 
                //count to the string
                if(i == s1.Length -1)
                {
                    strResult.Append(currentChar.ToString()).Append(count.ToString());
                }
            }

            return strResult;
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
            run.Text = @"public static StringBuilder StringCompress(string s1)
{
    char currentChar = s1[0];
    char[] s1Char ;
    int count = 0;
    StringBuilder strResult = new StringBuilder();

    //if the string lenght is one returns the same text
    if (s1.Length <= 1)
        return new StringBuilder(s1);

    //Set all charecters to lowercase
    s1 = s1.ToLower();

    // Remove white spaces 
    s1 = Regex.Replace(s1, @'\s + ', '');

    //Convert string to char array
    s1Char = s1.ToArray();

    //Loops and counts repeated characters
    for (int i = 0; i < s1.Length; i++)
    {
        //Compares the character with the next one in the string
        if (currentChar != s1Char[i])
        {
            strResult.Append(currentChar.ToString()).Append(count++.ToString());
            currentChar = s1[i];
            count = 0;
        }
        else
        {
            count++;
        }
        //if its the last character adds the last character and its 
        //count to the string
        if (i == s1.Length - 1)
        {
            strResult.Append(currentChar.ToString()).Append(count.ToString());
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
