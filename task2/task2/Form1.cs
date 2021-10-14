using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    public partial class Form1 : Form
    {
        private List<sudoku> _sudokus = new List<sudoku>();
        private Random _rng = new Random();
        private sudoku _currentQuiz = null;

        public Form1()
        {
            InitializeComponent();

            CreatePlayField();
            LoadSudokus();
            _currentQuiz = GetRandomQuiz();
            NewGame();
            
        }

        private void NewGame()
        {
            _currentQuiz = GetRandomQuiz();

            int counter = 0;
            foreach (var sf in mainPanel.Controls.OfType<SudokuField>())
            {
                sf.Value = int.Parse(_currentQuiz.Quiz[counter].ToString());
                sf.Active = sf.Value == 0;
                counter++;
            }
        }

        private sudoku GetRandomQuiz()
        {
            int randomNumber = _rng.Next(_sudokus.Count);
            return _sudokus[randomNumber];
        }

        private void LoadSudokus()
        {
            _sudokus.Clear();
            using (StreamReader sr = new StreamReader("sudoku.csv", Encoding.Default))
            {
                sr.ReadLine(); // Remove headers
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');

                    sudoku s = new sudoku();
                    s.Quiz = line[0];
                    s.Solution = line[1];
                    _sudokus.Add(s);
                }
            }
        }

        private void CreatePlayField()
        {
            int lineWidth = 5;

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    SudokuField sf = new SudokuField();
                    sf.Left = col * sf.Width + (int)(Math.Floor((double)(col / 3))) * lineWidth;
                    sf.Top = row * sf.Height + (int)(Math.Floor((double)(row / 3))) * lineWidth;
                    mainPanel.Controls.Add(sf);
                }
            }
        }
    }
}
