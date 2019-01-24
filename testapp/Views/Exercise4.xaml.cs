using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class Exercise4 : Page
    {
        public Exercise4()
        {
            this.InitializeComponent();
            ResultText();
        }

        /// <summary>
        /// This method checks if two strings are a Anagram
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns>True or False</returns>
        public static bool AnagramCheck(string s1, string s2)
        {
            // If length of the strings is different they are not Anagrams
            if (s1.Length != s1.Length)
                return false;

            //Set all charecters to lowercase
            s1 = s1.ToLower();
            s2 = s2.ToLower();

            // Remove white spaces 
            s1 = Regex.Replace(s1, @"\s+", "");
            s2 = Regex.Replace(s2, @"\s+", "");

            // Sort the strings 
            s1 = String.Concat(s1.OrderBy(c => c));
            s2 = String.Concat(s2.OrderBy(c => c));

            // Compare sorted strings 
            for (int i = 0; i < s1.Length; i++)
            {
                // If one set of characters is not iqual, then they are not Anagrams
                if (s1[i] != s2[i])
                {
                    return false;
                }
            }
            //returns true if all characters match
            return true;
        }

        private void TxtString_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtString1.Text != "" && txtString2.Text != "")
            {
                if (AnagramCheck(txtString1.Text, txtString2.Text))
                    tbActualResult.Text = "This two words/frases ara a Anagram! :)";
                else
                    tbActualResult.Text = "This two words/frases ara not a Anagram :(";
            }
            else
            {
                tbActualResult.Text = "Need more info, one or both of the words/frases are empty";
            }
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
            run.Text = @"public static bool AnagramCheck(string s1, string s2)
{
    // If length of the strings is different they are not Anagrams
    if (s1.Length != s1.Length)
        return false;

    //Set all charecters to lowercase
    s1 = s1.ToLower();
    s2 = s2.ToLower();

    // Remove white spaces 
    s1 = Regex.Replace(s1, @'\s + ', '');
    s2 = Regex.Replace(s2, @'\s+', '');

    // Sort the strings 
    s1 = String.Concat(s1.OrderBy(c => c));
    s2 = String.Concat(s2.OrderBy(c => c));

    // Compare sorted strings 
    for (int i = 0; i < s1.Length; i++)
    {
        // If one set of characters is not iqual, then they are not Anagrams
        if (s1[i] != s2[i])
        {
            return false;
        }
    }
    //returns true if all characters match
    return true;
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
