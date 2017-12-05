﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace GraphAlgorithms.Graphs
{
    class GraphReaderWriter
    {

        public static void addVertex(DataGridView dGV)
        {
            addColumnToDGV(dGV, "V" + +(dGV.Columns.Count + 1));
            addRowToDGV(dGV, "V" + +(dGV.Columns.Count));
            dGV.Rows[dGV.Rows.Count - 1]
                .Cells[dGV.Rows.Count - 1].Value = "-";
        }

        private static void addColumnToDGV(DataGridView dGV, string header)
        {
            dGV.Columns.Add("col" + (dGV.Columns.Count + 1), header);
        }

        private static void addRowToDGV(DataGridView dGV, string header)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.HeaderCell.Value = header;
            dGV.Rows.Add(row);
        }

        private static void addRowToDGV(DataGridView dGV, string header, params Object[] rowContent)
        {
            dGV.Rows.Add(rowContent);
            dGV.Rows[dGV.Rows.Count - 1].HeaderCell.Value = header;
        }

        public static int[,] getAdjacancyMatrix(DataGridView dGV)
        {
            int dim = dGV.Columns.Count;
            int[,] adjMatrix = new int[dim, dim];
            string cellVal;

            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    cellVal = (string)dGV.Rows[i].Cells[j].Value;

                    if (!int.TryParse(cellVal, out adjMatrix[i, j]))
                    {
                        adjMatrix[i, j] = -1;
                    }

                }
            }
            return adjMatrix;
        }

        public static void loadExample(DataGridView dGV)
        {
            addColumnToDGV(dGV, "A");
            addColumnToDGV(dGV, "B");
            addColumnToDGV(dGV, "C");
            addColumnToDGV(dGV, "D");
            addColumnToDGV(dGV, "F");
            addColumnToDGV(dGV, "G");

            addRowToDGV(dGV, "A", "-", "3", "", "", "6", "3");
            addRowToDGV(dGV, "B", "5", "-", "6", "", "", "3");
            addRowToDGV(dGV, "C", "", "2", "-", "2", "", "6");
            addRowToDGV(dGV, "D", "", "", "3", "-", "5", "2");
            addRowToDGV(dGV, "F", "5", "", "", "3", "-", "5");
            addRowToDGV(dGV, "G", "5", "5", "2", "3", "", "-");
        }
    }
}