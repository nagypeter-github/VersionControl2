﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    class SudokuField: Button
    {
        private bool _active;
        public bool Active
        {
            get { return _active; }
            set
            {
                _active = value;
                if (_active)
                    Font = new Font(FontFamily.GenericSansSerif, 12);
                else
                    Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            }
        }

        private void SudokuField_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Active) return;

            if (e.Button == MouseButtons.Left)
                Value++;
            if (e.Button == MouseButtons.Right)
                Value--;
        }

        public SudokuField()
        {
            Height = 30;
            Width = Height;
            BackColor = Color.White;
            Value = 0;
            MouseDown += SudokuField_MouseDown;
        }

       
        private int _value;
        public int Value
        {
            get { return _value; }
            set 
            {
                _value = value;
                if (_value < 0)
                    _value = 9;
                else if (_value > 9)
                    _value = 0;
                if (_value == 0)
                    Text = "";
                else
                    Text = _value.ToString();

            }

        }
        
    }
}
