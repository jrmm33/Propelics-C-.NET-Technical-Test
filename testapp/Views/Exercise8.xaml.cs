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
    public sealed partial class Exercise8 : Page
    {
        private int[,] baseMatrix = { { 1, 2, 3 }, { 4, 0, 6 }, { 7, 8, 9 } };

        public Exercise8()
        {
            this.InitializeComponent();
        }

        private void TxtString1_Click(object sender, RoutedEventArgs e)
        {
            ReplaceWithZero(baseMatrix);
            showMatrix();
        }

        public void showMatrix()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 3)
                    {
                        tbActualResult.Text += baseMatrix[i, j].ToString() + "\r\n";
                    }
                    else
                    {
                        tbActualResult.Text += baseMatrix[i, j].ToString();
                    }
                }
            }
        }

        public void ReplaceWithZero(int[,] matrix)
        {
            int[] row = new int[3];
            int[] col = new int[3];
            int i, j;

            for (i = 0; i < 3; i++)
            {
                row[i] = 0;
            }


            for (i = 0; i < 3; i++)
            {
                col[i] = 0;
            }

            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        row[i] = 1;
                        col[j] = 1;
                    }
                }
            }

            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (row[i] == 1 || col[j] == 1)
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
        }        
    }

}
