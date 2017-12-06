﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraphAlgorithms.Graphs;
using GraphAlgorithms.Graphs.Algorithms.AntColonyOptimization;

namespace GraphAlgorithms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            dGV_adjacMatrix.Columns.Clear();
        }

        private void button_addVertex_Click(object sender, EventArgs e)
        {
            GraphReaderWriter.addVertex(dGV_adjacMatrix);
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GraphReaderWriter.vertSeqToReadableForm(
                dGV_adjacMatrix,
                new ACOAlgorithm(
                    GraphReaderWriter.getAdjacancyMatrix(dGV_adjacMatrix),
                    tB_lengthFactor.Text == "" ? 1 : double.Parse(tB_lengthFactor.Text),
                    tB_evapFactor.Text == "" ? 0.2 : double.Parse(tB_evapFactor.Text),
                    tB_alfa.Text == "" ? 0.4 : double.Parse(tB_alfa.Text),
                    tB_beta.Text == "" ? 0.6 : double.Parse(tB_beta.Text))
                    .run()));

        }

        private void button_loadExample_Click(object sender, EventArgs e)
        {
            GraphReaderWriter.loadExample(dGV_adjacMatrix);
        }
    }
}
