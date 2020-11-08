﻿using FormulaOneDllProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaOneFormProject {
    public partial class FormMain : Form {
        public FormMain() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            listBox1.Items.Clear();
            foreach (var d in Driver.GetDrivers().ToArray()) {
                listBox1.Items.Add(d.FullName);
            }
        }
    }
}
