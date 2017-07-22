using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
//using Microsoft.Office.Interop.Excel;

namespace GlobleLibrary
{
   public class Common
    {
        #region Message
        public static void MessageUpdate()
        {
            MessageBox.Show("Record Update Sucessfully");
        }
        public static void MessageSave()
        {
            MessageBox.Show("Record Save Sucessfully");
        }
        public static void MessageDelete()
        {
            MessageBox.Show("Record Delete Sucessfully");
        }
        public static void MessageAlert(string msg)
        {
            MessageBox.Show(msg);
        }
        public static bool MessageConfim(string msg)
        {
            string str = MessageBox.Show(msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();
            if (str.Equals("Yes"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Style
        public void SetStyle(Form Form1)
        {
            if (Form1.AccessibleName == "SetStyle1")
            {
                Form1.WindowState = FormWindowState.Normal;
                //Form1.FormBorderStyle = FormBorderStyle.None;
                //Form1.StartPosition = FormStartPosition.CenterParent;
                Form1.ControlBox = false;
            }
            SetControlStyle(Form1);
            
        }
        public void SetControlStyle(Control ParentControl)
        {
            foreach (Control ctr in ParentControl.Controls)
            {
                #region Panel Style
                if (ctr.GetType().Equals(typeof(Panel)))
                {
                    ctr.BackColor = System.Drawing.Color.DarkSlateBlue;
                    if (ctr.AccessibleName == "SetStyle1")
                    {
                        ctr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
                    }
                    if (ctr.AccessibleName == "StyleWhite")
                    {
                        ctr.BackColor = System.Drawing.Color.White;
                    }
                    if (ctr.AccessibleName == "StyleRosyBrown")
                    {
                        ctr.BackColor = System.Drawing.Color.RosyBrown;
                    }
                    if (ctr.AccessibleName == "StylePlum")
                    {
                        ctr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(222)))), ((int)(((byte)(200)))));
                    }
                    if (ctr.AccessibleName == "SetDarkSeaGreen")
                    {
                        ctr.BackColor = System.Drawing.Color.DarkSeaGreen;
                    }
                    if (ctr.AccessibleName == "StyleTransparent")
                    {
                        ctr.BackColor = System.Drawing.Color.Transparent; 
                    }
                    if (ctr.AccessibleName == "MediumAquamarine")
                    {
                        ctr.BackColor = System.Drawing.Color.MediumAquamarine; 
                    }
                    if (ctr.AccessibleName == "SteelBlue")
                    {
                        ctr.BackColor = System.Drawing.Color.SteelBlue; 
                    }
                    
                    
                }
                #endregion
                #region Button Style
                if (ctr.GetType().Equals(typeof(Button)))
                {
                    if (ctr.AccessibleName == "SetStyle1")
                    {
                        ctr.BackColor = System.Drawing.Color.DarkOliveGreen;
                        ctr.ForeColor = System.Drawing.Color.White;
                        ctr.Margin = new System.Windows.Forms.Padding(2);
                        //ctr.Size = new System.Drawing.Size(80, 28);
                    }
                    if (ctr.AccessibleName == "SetStyle2")
                    {
                        ctr.BackColor = System.Drawing.Color.DarkSlateBlue;
                        ctr.ForeColor = System.Drawing.Color.White;
                        ctr.Margin = new System.Windows.Forms.Padding(2);
                        ctr.Size = new System.Drawing.Size(80, 28);
                    }
                    if (ctr.AccessibleName == "SteelBlue")
                    {
                        ctr.Font = new System.Drawing.Font("Arial", 10F);
                        ctr.BackColor = System.Drawing.Color.SteelBlue;
                        ctr.ForeColor = System.Drawing.Color.White;
                        ctr.Margin = new System.Windows.Forms.Padding(2);
                        //ctr.Size = new System.Drawing.Size(75, 28);
                    }
                    if (ctr.AccessibleName == "SetMaroon")
                    {
                        ctr.Font = new System.Drawing.Font("Arial", 10F);
                        ctr.BackColor = System.Drawing.Color.Maroon;
                        ctr.ForeColor = System.Drawing.Color.White;
                        ctr.Margin = new System.Windows.Forms.Padding(2);
                        //ctr.Size = new System.Drawing.Size(80, 28);
                    }
                }
                #endregion
                #region ComboBox Style
                if (ctr.GetType().Equals(typeof(ComboBox)))
                {
                    if (ctr.AccessibleName == "SetStyle1")
                    {
                        ctr.BackColor = System.Drawing.SystemColors.WindowFrame;
                        ctr.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        ctr.ForeColor = System.Drawing.Color.Transparent;
                        ctr.Margin = new System.Windows.Forms.Padding(2);
                    }
                    if (ctr.AccessibleName == "SetStyle2")
                    {
                        ctr.BackColor = System.Drawing.Color.Teal;
                        ctr.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        ctr.ForeColor = System.Drawing.Color.White;
                        ctr.Margin = new System.Windows.Forms.Padding(2);
                        //ctr.Size = new System.Drawing.Size(80, 28);
                    }
                }
                #endregion
                #region Datagridview Style
                if (ctr.GetType().Equals(typeof(DataGridView)))
                {
                    if (ctr.AccessibleName == "SetStyle1")
                    {
                        DataGridView ctr1 = (DataGridView)ctr;
                        ctr1.AllowUserToAddRows = false;
                        ctr1.AllowUserToDeleteRows = false;
                        ctr1.AllowUserToOrderColumns = true;
                        ctr1.BackgroundColor = System.Drawing.Color.DarkGray;
                        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
                        ctr1.ColumnHeadersHeight = 60;
                        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
                        ctr1.GridColor = System.Drawing.Color.Black;
                        ctr1.MultiSelect = false;
                        ctr1.ReadOnly = true;
                        ctr1.RowHeadersVisible = false;
                        //ctr1.RowTemplate.ReadOnly = true;
                        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                        ctr1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        ctr1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
                        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
                        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();

                        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson;
                        dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
                        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BlueViolet;
                        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
                        ctr1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

                        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                        dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                        ctr1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;

                        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon;
                        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
                        dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
                        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon;
                        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle3;
                    }
                    if (ctr.AccessibleName == "WeekEndStyle")
                    {
                        DataGridView ctr1 = (DataGridView)ctr;
                        ctr1.AllowUserToAddRows = false;
                        ctr1.AllowUserToDeleteRows = false;
                        ctr1.AllowUserToOrderColumns = true;
                        ctr1.BackgroundColor = System.Drawing.Color.DarkGray;
                        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
                        ctr1.ColumnHeadersHeight = 60;
                        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
                        ctr1.GridColor = System.Drawing.Color.DarkCyan;
                        ctr1.MultiSelect = false;
                        ctr1.ReadOnly = false;
                        ctr1.RowHeadersVisible = false;
                        //ctr1.RowTemplate.ReadOnly = true;
                        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                        ctr1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        ctr1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
                        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
                        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();

                        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson;
                        dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
                        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BlueViolet;
                        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
                        ctr1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

                        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                        dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                        ctr1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;

                        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGreen;
                        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
                        dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
                        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon;
                        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle3;
                    }
                    if (ctr.AccessibleName == "SetStyle2")
                    {
                        DataGridView ctr1 = (DataGridView)ctr;
                        ctr1.AllowUserToAddRows = false;
                        ctr1.AllowUserToDeleteRows = false;
                        ctr1.AllowUserToOrderColumns = true;
                        ctr1.BackgroundColor = System.Drawing.Color.DarkGray;
                        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
                        ctr1.ColumnHeadersHeight = 100;
                        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
                        ctr1.GridColor = System.Drawing.Color.Black;
                        ctr1.MultiSelect = false;
                        ctr1.ReadOnly = false;
                        ctr1.RowHeadersVisible = false;
                        //ctr1.RowTemplate.ReadOnly = true;
                        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                        ctr1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        ctr1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
                        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
                        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();

                        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson;
                        dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
                        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BlueViolet;
                        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
                        //dataGridViewCellStyle1.hei
                        ctr1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

                        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                        dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                        ctr1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;

                        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon;
                        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
                        dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
                        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon;
                        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle3;
                    }
                    if (ctr.AccessibleName == "rowSelection3")
                    {
                        DataGridView ctr1 = (DataGridView)ctr;
                        ctr1.AllowUserToAddRows = false;
                        ctr1.AllowUserToDeleteRows = false;
                        ctr1.AllowUserToOrderColumns = true;
                        ctr1.BackgroundColor = System.Drawing.Color.DarkGray;
                        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
                        ctr1.ColumnHeadersHeight = 60;
                        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
                        ctr1.GridColor = System.Drawing.Color.Black;
                        ctr1.MultiSelect = false;
                        ctr1.ReadOnly = true;
                        ctr1.RowHeadersVisible = false;
                        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                        ctr1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        ctr1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
                        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkGreen;
                        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle1;
                    }
                    if (ctr.AccessibleName == "CellSelection1")
                    {
                        DataGridView ctr1 = (DataGridView)ctr;
                        ctr1.AllowUserToAddRows = false;
                        ctr1.AllowUserToDeleteRows = false;
                        ctr1.AllowUserToOrderColumns = true;
                        ctr1.BackgroundColor = System.Drawing.Color.DarkGray;
                        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
                        ctr1.ColumnHeadersHeight = 60;
                        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
                        ctr1.GridColor = System.Drawing.Color.Black;
                        ctr1.MultiSelect = false;
                        //ctr1.ReadOnly = true;
                        ctr1.RowHeadersVisible = false;
                        //ctr1.RowTemplate.ReadOnly = true;
                        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                        ctr1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        ctr1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
                        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Purple;
                        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle1;
                    }
                   
                }
                #endregion
                #region Label Style
                if (ctr.GetType().Equals(typeof(Label)))
                {
                    if (ctr.AccessibleName == "SetStyle1")
                    {
                        ctr.ForeColor = System.Drawing.Color.Gold;
                    }
                    if (ctr.AccessibleName == "SetStyle2")
                    {
                        ctr.ForeColor = System.Drawing.Color.PaleGoldenrod;
                    }
                    if (ctr.AccessibleName == "SetStyle3")
                    {
                        ctr.ForeColor = System.Drawing.Color.Turquoise;
                    }
                    if (ctr.AccessibleName == "MaroonColor")
                    {
                        ctr.ForeColor = System.Drawing.Color.Maroon;
                    }
                    if (ctr.AccessibleName == "LightSalmonColor")
                    {
                        ctr.ForeColor = System.Drawing.Color.LightSalmon;
                    }
                    if (ctr.AccessibleName == "WhiteColor")
                    {
                        ctr.ForeColor = System.Drawing.Color.White;
                    }
                    if (ctr.AccessibleName == "BlackColor")
                    {
                        ctr.ForeColor = System.Drawing.Color.Black;
                    }
                    if (ctr.AccessibleName == "heading")
                    {
                        ctr.ForeColor = System.Drawing.Color.White;
                        ctr.Size = new System.Drawing.Size(58, 22);
                    }
                    if (ctr.AccessibleName != "SetStyle2" && ctr.AccessibleName != "SetStyle1" && ctr.AccessibleName != "SetStyle3")
                    {
                        ctr.ForeColor = System.Drawing.Color.White;
                    }

                }
                #endregion
                #region GroupBox style
                if (ctr.GetType().Equals(typeof(GroupBox)))
                {
                    if (ctr.AccessibleName != "NoStyle")
                    {
                        ctr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        ctr.ForeColor = System.Drawing.Color.PaleTurquoise;
                    }
                }
                #endregion
                #region RadioButton style
                if (ctr.GetType().Equals(typeof(RadioButton)))
                {
                    if (ctr.AccessibleName != "NoStyle")
                    {
                        ctr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        ctr.ForeColor = System.Drawing.Color.White;
                    }


                }
                #endregion
                #region RadioButton style
                if (ctr.GetType().Equals(typeof(CheckBox)))
                {
                    if (ctr.AccessibleName != "NoStyle")
                    {
                        ctr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        ctr.ForeColor = System.Drawing.Color.White;
                    }


                }
                #endregion
                #region Children Style
                if (ctr.HasChildren)
                {
                    SetControlStyle(ctr);
                }
                #endregion
            }
            //#region GroupBox style
            //if (ctr.GetType().Equals(typeof(GroupBox)))
            //{
            //    if (ctr.AccessibleName != "NoStyle")
            //    {
            //        ctr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        ctr.ForeColor = System.Drawing.Color.Chartreuse;
            //    }


            //}
            //#endregion
            //#region RadioButton style
            //if (ctr.GetType().Equals(typeof(RadioButton)))
            //{
            //    if (ctr.AccessibleName != "NoStyle")
            //    {
            //        ctr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        ctr.ForeColor = System.Drawing.Color.White;
            //    }


            //}
            //#endregion
            //#region RadioButton style
            //if (ctr.GetType().Equals(typeof(CheckBox)))
            //{
            //    if (ctr.AccessibleName != "NoStyle")
            //    {
            //        ctr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        ctr.ForeColor = System.Drawing.Color.LightSalmon;
            //    }


            //}
            //#endregion
            //#region Panel Style
            //if (ctr.GetType().Equals(typeof(Panel)))
            //{
            //    ctr.BackColor = System.Drawing.Color.Black;
            //}
            //#endregion
            //#region Button Style
            //if (ctr.GetType().Equals(typeof(Button)))
            //{
            //    if (ctr.AccessibleName == "SetStyle1")
            //    {
            //        ctr.Font = new System.Drawing.Font("Arial", 10F); 
            //        ctr.BackColor = System.Drawing.Color.Maroon;
            //        ctr.ForeColor = System.Drawing.Color.White;
            //        ctr.Margin = new System.Windows.Forms.Padding(2);
            //        //ctr.Size = new System.Drawing.Size(80, 28);
            //    }
            //    if (ctr.AccessibleName == "SetStyle2")
            //    {
            //        ctr.Font = new System.Drawing.Font("Arial", 10F); 
            //        ctr.BackColor = System.Drawing.Color.BurlyWood;
            //        ctr.ForeColor = System.Drawing.Color.Black;
            //        ctr.Margin = new System.Windows.Forms.Padding(2);
            //       // ctr.Size = new System.Drawing.Size(80, 28);
            //    }
            //    if (ctr.AccessibleName == "SetStyle3")
            //    {
            //        ctr.Font = new System.Drawing.Font("Arial", 10F); 
            //        ctr.BackColor = System.Drawing.Color.DarkSeaGreen;
            //        ctr.ForeColor = System.Drawing.Color.White;
            //        ctr.Margin = new System.Windows.Forms.Padding(2);
            //        // ctr.Size = new System.Drawing.Size(80, 28);
            //    }
            //}
            //#endregion 
            //#region ComboBox Style
            //if (ctr.GetType().Equals(typeof(ComboBox)))
            //{
            //    if (ctr.AccessibleName == "SetStyle1")
            //    {
            //        ctr.BackColor = System.Drawing.SystemColors.WindowFrame;
            //        ctr.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        ctr.ForeColor = System.Drawing.Color.Transparent;
            //        ctr.Margin = new System.Windows.Forms.Padding(2);
            //    }
            //    if (ctr.AccessibleName == "SetStyle2")
            //    {
            //        ctr.BackColor = System.Drawing.Color.Teal;
            //        ctr.ForeColor = System.Drawing.Color.White;
            //        ctr.Margin = new System.Windows.Forms.Padding(2);
            //        //ctr.Size = new System.Drawing.Size(80, 28);
            //    }
            //}
            //#endregion 
            //#region Datagridview Style 
            //if (ctr.GetType().Equals(typeof(DataGridView)))
            //{
            //    if (ctr.AccessibleName == "SetStyle1")
            //    {
            //        DataGridView ctr1 = (DataGridView)ctr;
            //        ctr1.AllowUserToAddRows = false;
            //        ctr1.AllowUserToDeleteRows = false;
            //        ctr1.AllowUserToOrderColumns = true;
            //        ctr1.BackgroundColor = System.Drawing.Color.DarkGray;
            //        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            //        ctr1.ColumnHeadersHeight = 60;
            //        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
            //        ctr1.GridColor = System.Drawing.Color.Black;
            //        ctr1.MultiSelect = false;
            //        ctr1.ReadOnly = true;
            //        ctr1.RowHeadersVisible = false;
            //        //ctr1.RowTemplate.ReadOnly = true;
            //        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            //        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            //        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();

            //        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //        dataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson;
            //        dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            //        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BlueViolet;
            //        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.NotSet;
            //        ctr1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            //        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //        dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;

            //        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon;
            //        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            //        dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
            //        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon;
            //        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            //    }
            //    if (ctr.AccessibleName == "WeekEndStyle")
            //    {
            //        DataGridView ctr1 = (DataGridView)ctr;
            //        ctr1.AllowUserToAddRows = false;
            //        ctr1.AllowUserToDeleteRows = false;
            //        ctr1.AllowUserToOrderColumns = true;
            //        ctr1.BackgroundColor = System.Drawing.Color.DarkGray;
            //        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            //        ctr1.ColumnHeadersHeight = 60;
            //        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
            //        ctr1.GridColor = System.Drawing.Color.DarkCyan;
            //        ctr1.MultiSelect = false;
            //        ctr1.ReadOnly = false;
            //        ctr1.RowHeadersVisible = false;
            //        //ctr1.RowTemplate.ReadOnly = true;
            //        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.SelectionMode = DataGridViewSelectionMode.CellSelect;

            //        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            //        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            //        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();

            //        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //        dataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson;
            //        dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            //        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BlueViolet;
            //        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.NotSet;
            //        ctr1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            //        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //        dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;

            //        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGreen;
            //        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            //        dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
            //        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon;
            //        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            //    }
            //    if (ctr.AccessibleName == "SetStyle2")
            //    {
            //        DataGridView ctr1 = (DataGridView)ctr;
            //        ctr1.AllowUserToAddRows = false;
            //        ctr1.AllowUserToDeleteRows = false;
            //        ctr1.AllowUserToOrderColumns = true;
            //        ctr1.BackgroundColor = System.Drawing.Color.DarkGray;
            //        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            //        ctr1.ColumnHeadersHeight = 100;
            //        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
            //        ctr1.GridColor = System.Drawing.Color.Black;
            //        ctr1.MultiSelect = false;
            //        ctr1.ReadOnly = false;
            //        ctr1.RowHeadersVisible = false;
            //        //ctr1.RowTemplate.ReadOnly = true;
            //        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.SelectionMode = DataGridViewSelectionMode.CellSelect;

            //        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            //        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            //        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();

            //        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //        dataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson;
            //        dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            //        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BlueViolet;
            //        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.NotSet;
            //        //dataGridViewCellStyle1.hei
            //        ctr1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            //        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //        dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;

            //        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon;
            //        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            //        dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
            //        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon;
            //        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            //    }
            //    if (ctr.AccessibleName == "DefaultStyle")
            //    {
            //        DataGridView ctr1 = (DataGridView)ctr;
            //        ctr1.AllowUserToAddRows = false;
            //        ctr1.AllowUserToDeleteRows = false;
            //        ctr1.AllowUserToOrderColumns = true;
            //        ctr1.BackgroundColor = System.Drawing.Color.DarkGray;
            //        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            //        ctr1.ColumnHeadersHeight = 60;
            //        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
            //        ctr1.GridColor = System.Drawing.Color.Black;
            //        ctr1.MultiSelect = false;
            //        ctr1.ReadOnly = true;
            //        ctr1.RowHeadersVisible = false;
            //        //ctr1.RowTemplate.ReadOnly = true;
            //        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            //        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Purple;
            //        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            //    }
            //    if (ctr.AccessibleName == "DefaultStyle2")
            //    {
            //        DataGridView ctr1 = (DataGridView)ctr;
            //        ctr1.AllowUserToAddRows = false;
            //        ctr1.AllowUserToDeleteRows = false;
            //        ctr1.AllowUserToOrderColumns = true;
            //        ctr1.BackgroundColor = System.Drawing.Color.AliceBlue;
            //        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            //        ctr1.ColumnHeadersHeight = 30;
            //        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
            //        ctr1.GridColor = System.Drawing.Color.Black;
            //        ctr1.MultiSelect = false;
            //        ctr1.ReadOnly = true;
            //        ctr1.RowHeadersVisible = false;
            //        //ctr1.RowTemplate.ReadOnly = true;
            //        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            //        ctr1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            //        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkCyan;
            //        dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            //        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            //    }


            //}
            //#endregion                                            
            //#region Children Style
            //if (ctr.HasChildren)
            //{
            //    SetControlStyle(ctr);
            //}
            //#endregion
            //#region Label Style
            //if (ctr.GetType().Equals(typeof(Label)))
            //{
            //    if (ctr.AccessibleName == "SetStyle1")
            //    {
            //        ctr.ForeColor = System.Drawing.Color.Gold;
            //    }
            //    if (ctr.AccessibleName == "SetStyle2")
            //    {
            //        ctr.ForeColor = System.Drawing.Color.LightSalmon;                       
            //    }
            //    if (ctr.AccessibleName == "SetStyle3")
            //    {
            //        ctr.ForeColor = System.Drawing.Color.Turquoise;
            //    }
            //    if (ctr.AccessibleName != "SetStyle2" && ctr.AccessibleName != "SetStyle1" && ctr.AccessibleName != "SetStyle3")
            //    {
            //        ctr.ForeColor = System.Drawing.Color.White;
            //    }

            //}
            //#endregion

















            //#region GroupBox style
            //if (ctr.GetType().Equals(typeof(GroupBox)))
            //{
            //    ctr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //    ctr.ForeColor = System.Drawing.Color.DarkBlue;
            //    ctr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));

            //    if (ctr.AccessibleName == "SetStyle1")
            //    {
            //        ctr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        ctr.ForeColor = System.Drawing.Color.White;
            //        ctr.BackColor = System.Drawing.Color.LightSlateGray;
            //    }
            //}
            //#endregion
            //#region RadioButton style
            //if (ctr.GetType().Equals(typeof(RadioButton)))
            //{
            //    ctr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //    ctr.ForeColor = System.Drawing.Color.Black;

            //    if (ctr.AccessibleName == "NoStyle")
            //    {

            //    }
            //}
            //#endregion
            //#region CheckBox style
            //if (ctr.GetType().Equals(typeof(CheckBox)))
            //{
            //    ctr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //    ctr.ForeColor = System.Drawing.Color.Black;

            //    if (ctr.AccessibleName == "NoStyle")
            //    {

            //    }
            //}
            //#endregion
            //#region Panel Style
            //if (ctr.GetType().Equals(typeof(Panel)))
            //{
            //    ctr.BackColor = System.Drawing.Color.LightSlateGray;
            //    if (ctr.AccessibleName == "SetStyle1")
            //    {
            //        ctr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            //    }
            //    if (ctr.AccessibleName == "StyleWhite")
            //    {
            //        ctr.BackColor = System.Drawing.Color.White;
            //    }
            //}
            //#endregion               
            //#region Button Style
            //if (ctr.GetType().Equals(typeof(Button)))
            //{
            //    if (ctr.AccessibleName == "SetStyle1")
            //    {
            //        ctr.Font = new System.Drawing.Font("Arial", 10F); 
            //        ctr.BackColor = System.Drawing.Color.SteelBlue;
            //        ctr.ForeColor = System.Drawing.Color.White;
            //        ctr.Margin = new System.Windows.Forms.Padding(2);
            //        //ctr.Size = new System.Drawing.Size(75, 28);
            //    }
            //    if (ctr.AccessibleName == "SetStyle2")
            //    {
            //        ctr.Font = new System.Drawing.Font("Arial", 10F);
            //        ctr.BackColor = System.Drawing.Color.Teal;
            //        ctr.ForeColor = System.Drawing.Color.White;
            //        ctr.Margin = new System.Windows.Forms.Padding(2);
            //        //ctr.Size = new System.Drawing.Size(75, 28);
            //    }
            //}
            //#endregion 
            //#region ComboBox Style
            //if (ctr.GetType().Equals(typeof(ComboBox)))
            //{
            //    ComboBox combo = ctr as ComboBox;

            //    combo.DropDownStyle = ComboBoxStyle.DropDownList;
            //    combo.AutoCompleteSource = AutoCompleteSource.ListItems;
            //    combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            //    if (ctr.AccessibleName == "SetStyle1")
            //    {
            //        ctr.BackColor = System.Drawing.SystemColors.WindowFrame;
            //        ctr.ForeColor = System.Drawing.Color.Transparent;
            //        ctr.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        ctr.Margin = new System.Windows.Forms.Padding(2);
            //    }
            //    if (ctr.AccessibleName == "SetStyle2")
            //    {
            //        ctr.BackColor = System.Drawing.Color.Teal;
            //        ctr.ForeColor = System.Drawing.Color.White;
            //        ctr.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        ctr.Margin = new System.Windows.Forms.Padding(2);
            //        //ctr.Size = new System.Drawing.Size(80, 28);
            //    }
            //}
            //#endregion 
            //#region Datagridview Style 
            //if (ctr.GetType().Equals(typeof(DataGridView)))
            //{
            //    if (ctr.AccessibleName == "SetStyle1")
            //    {
            //        DataGridView ctr1 = (DataGridView)ctr;
            //        ctr1.AllowUserToAddRows = false;
            //        ctr1.AllowUserToDeleteRows = false;
            //        ctr1.AllowUserToOrderColumns = true;
            //        ctr1.BackgroundColor = System.Drawing.Color.DarkGray;
            //        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            //        ctr1.ColumnHeadersHeight = 60;
            //        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
            //        ctr1.GridColor = System.Drawing.Color.Black;
            //        ctr1.MultiSelect = false;
            //        ctr1.ReadOnly = true;
            //        ctr1.RowHeadersVisible = false;
            //        //ctr1.RowTemplate.ReadOnly = true;
            //        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            //        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            //        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();

            //        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //        dataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson;
            //        dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            //        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BlueViolet;
            //        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.NotSet;
            //        ctr1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            //        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //        dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;

            //        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon;
            //        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            //        dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
            //        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon;
            //        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            //    }
            //    if (ctr.AccessibleName == "WeekEndStyle")
            //    {
            //        DataGridView ctr1 = (DataGridView)ctr;
            //        ctr1.AllowUserToAddRows = false;
            //        ctr1.AllowUserToDeleteRows = false;
            //        ctr1.AllowUserToOrderColumns = true;
            //        ctr1.BackgroundColor = System.Drawing.Color.DarkGray;
            //        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            //        ctr1.ColumnHeadersHeight = 60;
            //        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
            //        ctr1.GridColor = System.Drawing.Color.DarkCyan;
            //        ctr1.MultiSelect = false;
            //        ctr1.ReadOnly = false;
            //        ctr1.RowHeadersVisible = false;
            //        //ctr1.RowTemplate.ReadOnly = true;
            //        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.SelectionMode = DataGridViewSelectionMode.CellSelect;

            //        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            //        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            //        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();

            //        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //        dataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson;
            //        dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            //        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BlueViolet;
            //        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.NotSet;
            //        ctr1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            //        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //        dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;

            //        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGreen;
            //        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            //        dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
            //        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon;
            //        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            //    }
            //    if (ctr.AccessibleName == "SetStyle2")
            //    {
            //        DataGridView ctr1 = (DataGridView)ctr;
            //        ctr1.AllowUserToAddRows = false;
            //        ctr1.AllowUserToDeleteRows = false;
            //        ctr1.AllowUserToOrderColumns = true;
            //        ctr1.BackgroundColor = System.Drawing.Color.DarkGray;
            //        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            //        ctr1.ColumnHeadersHeight = 100;
            //        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
            //        ctr1.GridColor = System.Drawing.Color.Black;
            //        ctr1.MultiSelect = false;
            //        ctr1.ReadOnly = false;
            //        ctr1.RowHeadersVisible = false;
            //        //ctr1.RowTemplate.ReadOnly = true;
            //        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.SelectionMode = DataGridViewSelectionMode.CellSelect;

            //        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            //        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            //        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();

            //        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //        dataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson;
            //        dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            //        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BlueViolet;
            //        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.NotSet;
            //        //dataGridViewCellStyle1.hei
            //        ctr1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            //        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //        dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;

            //        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon;
            //        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            //        dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
            //        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon;
            //        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            //    }
            //    if (ctr.AccessibleName == "rowSelection1")
            //    {
            //        DataGridView ctr1 = (DataGridView)ctr;
            //        ctr1.AllowUserToAddRows = false;
            //        ctr1.AllowUserToDeleteRows = false;
            //        ctr1.AllowUserToOrderColumns = true;
            //        ctr1.BackgroundColor = System.Drawing.Color.DarkGray;
            //        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            //        ctr1.ColumnHeadersHeight = 60;
            //        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
            //        ctr1.GridColor = System.Drawing.Color.Black;
            //        ctr1.MultiSelect = false;
            //        ctr1.ReadOnly = true;
            //        ctr1.RowHeadersVisible = false;
            //        //ctr1.RowTemplate.ReadOnly = true;
            //        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //        ctr1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            //        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Purple;
            //        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            //    }
            //    if (ctr.AccessibleName == "CellSelection1")
            //    {
            //        DataGridView ctr1 = (DataGridView)ctr;
            //        ctr1.AllowUserToAddRows = false;
            //        ctr1.AllowUserToDeleteRows = false;
            //        ctr1.AllowUserToOrderColumns = true;
            //        ctr1.BackgroundColor = System.Drawing.Color.DarkGray;
            //        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            //        ctr1.ColumnHeadersHeight = 60;
            //        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
            //        ctr1.GridColor = System.Drawing.Color.Black;
            //        ctr1.MultiSelect = false;
            //        //ctr1.ReadOnly = true;
            //        ctr1.RowHeadersVisible = false;
            //        //ctr1.RowTemplate.ReadOnly = true;
            //        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            //        ctr1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //        ctr1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            //        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Purple;
            //        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            //    }
            //    if (ctr.AccessibleName == "DefaultStyle2")
            //    {
            //        DataGridView ctr1 = (DataGridView)ctr;
            //        ctr1.AllowUserToAddRows = false;
            //        ctr1.AllowUserToDeleteRows = false;
            //        ctr1.AllowUserToOrderColumns = true;
            //        ctr1.BackgroundColor = System.Drawing.Color.AliceBlue;
            //        ctr1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            //        ctr1.ColumnHeadersHeight = 30;
            //        ctr1.Cursor = System.Windows.Forms.Cursors.Default;
            //        ctr1.GridColor = System.Drawing.Color.Black;
            //        ctr1.MultiSelect = false;
            //        ctr1.ReadOnly = true;
            //        ctr1.RowHeadersVisible = false;
            //        //ctr1.RowTemplate.ReadOnly = true;
            //        ctr1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            //        ctr1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //        ctr1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            //        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            //        dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            //        ctr1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            //    }


            //}
            //#endregion                             
            //#region Label Style
            //if (ctr.GetType().Equals(typeof(Label)))
            //{
            //    ctr.ForeColor = System.Drawing.Color.Black;

            //    if (ctr.AccessibleName == "GoldColor")
            //    {
            //        ctr.ForeColor = System.Drawing.Color.Gold;
            //    }
            //    if (ctr.AccessibleName == "MaroonColor")
            //    {
            //        ctr.ForeColor = System.Drawing.Color.Maroon;
            //    }
            //    if (ctr.AccessibleName == "LightSalmonColor")
            //    {
            //        ctr.ForeColor = System.Drawing.Color.LightSalmon;
            //    }
            //    if (ctr.AccessibleName == "WhiteColor")
            //    {
            //        ctr.ForeColor = System.Drawing.Color.White;
            //    }
            //    if (ctr.AccessibleName == "heading")
            //    {
            //        ctr.ForeColor = System.Drawing.Color.White;
            //        ctr.Size = new System.Drawing.Size(58, 22);
            //    } 

            //}
            //#endregion                

        }
        #endregion

        #region control clear

        public  void ClearControl(Control ParentControl)
        {
            foreach (Control ctr in ParentControl.Controls)
            {
                #region TextBox
                if (ctr.GetType().Equals(typeof(TextBox)))
                {
                    ctr.Text = "";
                }
                #endregion
                #region Combo Box
                if (ctr.GetType().Equals(typeof(ComboBox)))
                {
                    ComboBox ctr1 = (ComboBox)ctr;
                    if (ctr1.Items.Count > 0)
                    {
                        //ctr1.SelectedIndex = 0;
                    }
                }
                #endregion    
                #region PictureBox
                if (ctr.GetType().Equals(typeof(PictureBox)))
                {
                    PictureBox ctr1 = (PictureBox)ctr;
                    ctr1.Image = null;                    
                }
                #endregion    
                #region Children Style
                if (ctr.HasChildren)
                {
                    ClearControl(ctr);
                }
                #endregion

            }
        }

        #endregion 
      
        #region Excel Export
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        public void ExcelExport(int startColumnIndex, DataGridView dataGridView1, SaveFileDialog saveFileDialog1, string SuperHeading, string Heading, string SubHeading)
        {
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0;

                xlWorkSheet.Cells[1, 6] = SuperHeading;
                xlWorkSheet.Cells[2, 6] = Heading;
                xlWorkSheet.Cells[3, 6] = SubHeading;

                #region Excel Style formating
                //formate excel file cell header style
                Excel.Range rg = (Excel.Range)xlWorkSheet.Rows[6, Type.Missing];
                rg.HorizontalAlignment = Excel.Constants.xlCenter;
                rg.Font.Name = "Aerial";
                rg.Font.Size = 10;
                rg.WrapText = true;
                rg.Font.Bold = true;

                //formate excel SuperHeading Style
                rg = (Excel.Range)xlWorkSheet.Cells[1, 6];
                rg.Font.Bold = true;
                rg.Font.Size = 20;

                //formate excel Heading Style
                rg = (Excel.Range)xlWorkSheet.Cells[2, 6];
                rg.Font.Bold = true;
                rg.Font.Size = 15;

                //formate excel Heading Style
                rg = (Excel.Range)xlWorkSheet.Cells[3, 6];
                rg.Font.Size = 12;



                //formate excel file cell header width
                rg = (Excel.Range)xlWorkSheet.Cells[6, 1];
                rg.Cells.ColumnWidth = 25;

                rg = (Excel.Range)xlWorkSheet.Cells[6, 2];
                rg.Cells.ColumnWidth = 11;

                rg = (Excel.Range)xlWorkSheet.Cells[6, 3];
                rg.Cells.ColumnWidth = 11;

                rg = (Excel.Range)xlWorkSheet.Cells[6, 4];
                rg.Cells.ColumnWidth = 8;

                rg = (Excel.Range)xlWorkSheet.Cells[6, 5];
                rg.Cells.ColumnWidth = 10;

                rg = (Excel.Range)xlWorkSheet.Cells[6, 6];
                rg.Cells.ColumnWidth = 8;

                rg = (Excel.Range)xlWorkSheet.Cells[6, 7];
                rg.Cells.ColumnWidth = 13;
                rg = (Excel.Range)xlWorkSheet.Cells[6, 8];
                rg.Cells.ColumnWidth = 8;

                rg = (Excel.Range)xlWorkSheet.Cells[6, 9];
                rg.Cells.ColumnWidth = 12;

                rg = (Excel.Range)xlWorkSheet.Cells[6, 10];
                rg.Cells.ColumnWidth = 9;

                rg = (Excel.Range)xlWorkSheet.Cells[6, 11];
                rg.Cells.ColumnWidth = 10;

                rg = (Excel.Range)xlWorkSheet.Cells[6, 12];
                rg.Cells.ColumnWidth = 13;

                rg = (Excel.Range)xlWorkSheet.Cells[6, 13];
                rg.Cells.ColumnWidth = 11;

                rg = (Excel.Range)xlWorkSheet.Cells[6, 14];
                rg.Cells.ColumnWidth = 20;
                rg.HorizontalAlignment = HorizontalAlignment.Right;


                #endregion


                for (j = startColumnIndex; j < dataGridView1.ColumnCount; j++)
                {
                    xlWorkSheet.Cells[6, j + 1] = dataGridView1.Columns[j].HeaderText;

                    //Boder line
                    rg = (Excel.Range)xlWorkSheet.Cells[6, j + 1];
                    rg.Borders.Weight = Excel.XlBorderWeight.xlMedium;

                }


                for (i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (j = startColumnIndex; j < dataGridView1.ColumnCount; j++)
                    {
                        DataGridViewCell cell = dataGridView1[j, i];
                        xlWorkSheet.Cells[i + 7, j + 1] = cell.Value;


                        //Boder line
                        rg = (Excel.Range)xlWorkSheet.Cells[i + 7, j + 1];
                        rg.Borders.Weight = Excel.XlBorderWeight.xlMedium;
                    }
                }

                DialogResult result = saveFileDialog1.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {

                    xlWorkBook.SaveAs(saveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    MessageBox.Show("Excel file created , you can find the file " + saveFileDialog1.FileName);//c:\\csharp.net-informations.xls");
                }
            }
            catch
            { }
        }

        public void ExcelExport(DataGridView dataGridView1, SaveFileDialog saveFileDialog1, string Heading, string SubHeading)
        {
            try
            {
                Excel.Range rg = null;
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0;

                xlWorkSheet.Cells[2, 2] = Heading;
                xlWorkSheet.Cells[3, 2] = SubHeading;


                for (j = 1; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    xlWorkSheet.Cells[6, j] = dataGridView1.Columns[j].HeaderText;
                    rg = (Excel.Range)xlWorkSheet.Cells[6, j];
                    rg.Cells.ColumnWidth = (dataGridView1.Columns[j].Width)/10 +4;
                    rg.Cells.WrapText = true;
                }


                for (i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    for (j = 1; j <= dataGridView1.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = dataGridView1[j, i];
                        xlWorkSheet.Cells[i + 7, j] = cell.Value;
                        rg = (Excel.Range)xlWorkSheet.Cells[i + 7, j];
                        rg.Cells.WrapText = true;
                    }
                }

                #region Excel Style formating
                //formate excel file cell header style
                rg = (Excel.Range)xlWorkSheet.Rows[6, Type.Missing];
                rg.HorizontalAlignment = Excel.Constants.xlCenter;
                rg.Font.Name = "Aerial";
                rg.Font.Size = 10;
                rg.WrapText = true;
                rg.Font.Bold = true;

                //formate excel Heading Style
                rg = (Excel.Range)xlWorkSheet.Cells[2, 6];
                rg.Font.Bold = true;
                rg.Font.Size = 15;

                //formate excel sub Heading Style
                rg = (Excel.Range)xlWorkSheet.Cells[3, 6];
                rg.Font.Size = 12;



                //formate excel file cell header width
                //rg = (Excel.Range)xlWorkSheet.Cells[6, 1];
                //rg.Cells.ColumnWidth = 25;

                //rg = (Excel.Range)xlWorkSheet.Cells[6, 2];
                //rg.Cells.ColumnWidth = 11;

                //rg = (Excel.Range)xlWorkSheet.Cells[6, 3];
                //rg.Cells.ColumnWidth = 11;

                //rg = (Excel.Range)xlWorkSheet.Cells[6, 4];
                //rg.Cells.ColumnWidth = 8;

                //rg = (Excel.Range)xlWorkSheet.Cells[6, 5];
                //rg.Cells.ColumnWidth = 10;

                //rg = (Excel.Range)xlWorkSheet.Cells[6, 6];
                //rg.Cells.ColumnWidth = 8;

                //rg = (Excel.Range)xlWorkSheet.Cells[6, 7];
                //rg.Cells.ColumnWidth = 13;
                //rg = (Excel.Range)xlWorkSheet.Cells[6, 8];
                //rg.Cells.ColumnWidth = 8;

                //rg = (Excel.Range)xlWorkSheet.Cells[6, 9];
                //rg.Cells.ColumnWidth = 12;

                //rg = (Excel.Range)xlWorkSheet.Cells[6, 10];
                //rg.Cells.ColumnWidth = 9;

                //rg = (Excel.Range)xlWorkSheet.Cells[6, 11];
                //rg.Cells.ColumnWidth = 10;

                //rg = (Excel.Range)xlWorkSheet.Cells[6, 12];
                //rg.Cells.ColumnWidth = 13;

                //rg = (Excel.Range)xlWorkSheet.Cells[6, 13];
                //rg.Cells.ColumnWidth = 11;

                //rg = (Excel.Range)xlWorkSheet.Cells[6, 14];
                //rg.Cells.ColumnWidth = 20;
                //rg.HorizontalAlignment = HorizontalAlignment.Right;


                #endregion

                DialogResult result = saveFileDialog1.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {

                    xlWorkBook.SaveAs(saveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    MessageBox.Show("Excel file created , you can find the file " + saveFileDialog1.FileName);//c:\\csharp.net-informations.xls");
                }
            }
            catch
            { }
        }

        public void PurchasesOrderExcelExport(DataGridView dataGridView1, SaveFileDialog saveFileDialog1
            , string filePath
            , string PurcasesOrderNo, string PurchasesOrderDate, string CompanyName, string CompanyAddress
            , string CompanyCity, string CompanyState, string companyPincode, bool isExcel)
        {
            try
            {

                Excel.Range rg = null;
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                //xlWorkBook = xlApp.Workbooks.Open(filePath, true, false,
                //                                      Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                //                                      Type.Missing, Type.Missing, true, Type.Missing,
                //                                      Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                Excel.Range workSheet_range = xlWorkSheet.get_Range("A1", "F1");
                //workSheet_range.Font.Color = System.Drawing.Color.SteelBlue;
                workSheet_range.Cells.Font.Size = 20;
                workSheet_range.Merge(4);
                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                xlWorkSheet.Cells[1, 1] = "PURCHASE ORDER";


                workSheet_range = xlWorkSheet.get_Range("G2", "G3");
                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;


                xlWorkSheet.Cells[2, 7] = "Date   " + PurchasesOrderDate;
                ((Excel.Range)xlWorkSheet.Cells[2, 7]).Cells.Font.Bold = true;
                xlWorkSheet.Cells[3, 7] = "PO NO  "+ PurcasesOrderNo;
                ((Excel.Range)xlWorkSheet.Cells[3, 7]).Cells.Font.Bold = true;

                xlWorkSheet.Cells[2, 1] = "R P Printers";
                xlWorkSheet.Cells[3, 1] = "G-68, Sector-6 Noida 201301 (UP)";
                xlWorkSheet.Cells[4, 1] = "Phone: (0120) 4333367/68/69";
                xlWorkSheet.Cells[5, 1] = "E-mail : rpprinters68@gmail.com ";
                xlWorkSheet.Cells[6, 1] = "Tin No : 09165703716";
                xlWorkSheet.Cells[7, 1] = "Pan No : AAAFR4897C";

                xlWorkSheet.Cells[9, 1] = "VENDOR";              
                workSheet_range = xlWorkSheet.get_Range("A9", "A9");
                //workSheet_range.Interior.Color = System.Drawing.Color.SteelBlue;
                //workSheet_range.Font.Color = System.Drawing.Color.White;
                                            

                xlWorkSheet.Cells[10, 1] = CompanyName;
                xlWorkSheet.Cells[11, 1] = CompanyAddress.Trim();
                xlWorkSheet.Cells[12, 1] = CompanyCity + " " + CompanyState + " " + companyPincode;
                xlWorkSheet.Cells[13, 1] = "Phone: ";
                xlWorkSheet.Cells[14, 1] = "Email: ";


                workSheet_range = xlWorkSheet.get_Range("G9", "G12");
                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                workSheet_range = xlWorkSheet.get_Range("G9", "G9");
                //workSheet_range.Interior.Color = System.Drawing.Color.SteelBlue;
                //workSheet_range.Font.Color = System.Drawing.Color.White;

                xlWorkSheet.Cells[9,  7] = "Deliver To";
                xlWorkSheet.Cells[10, 7] = "R P Printers";
                xlWorkSheet.Cells[11, 7] = "G-68, Sector-6 Noida 201301 (UP)";
                xlWorkSheet.Cells[12, 7] = "Phone: (0120) 4333367/68";

                rg = (Excel.Range)xlWorkSheet.Cells[1, 1];
                rg.Cells.ColumnWidth = 35;

                int i = 0;
                int j = 0;

                //set table heder
                for (j = 1; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    xlWorkSheet.Cells[18, j + 0] = dataGridView1.Columns[j].HeaderText;                
                }

                rg = xlWorkSheet.get_Range("A18", "D18");
                rg.Cells.WrapText = true;
                rg.Cells.Font.Bold = true;
                rg.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            
                for (i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    for (j = 1; j <= dataGridView1.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = dataGridView1[j, i];
                        xlWorkSheet.Cells[i + 19, j + 0] = j != 1 ? cell.Value : cell.FormattedValue;
                        rg = (Excel.Range)xlWorkSheet.Cells[i + 19, j + 0];
                        rg.Cells.WrapText = true;
                        rg.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;  
                    }
                }

                decimal total = 0;
                for (int k = 0; k < dataGridView1.RowCount - 1; k++)
                {
                    total = total + Convert.ToDecimal(dataGridView1[4, k].Value);
                }

                rg = xlWorkSheet.get_Range("C" + (i + 19), "D" + (i + 19));
                rg.Cells.WrapText = true;
                rg.Cells.Font.Bold = true;
                rg.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;



                xlWorkSheet.Cells[i + 19, 3] = "Total";
                xlWorkSheet.Cells[i + 19, 4] = total;

                xlWorkSheet.Cells[i + 22, 1] = " ( Signature, Store Incharge  )";
                xlWorkSheet.Cells[i + 22, 5] = "( Signature , Manager )   ";
                xlWorkSheet.Cells[i + 24, 1] = "If you have any questions about this purchase order, please contact";
                xlWorkSheet.Cells[i + 25, 1] = "Gautam, Store Incharge 7042249843 or Raj Bahadur Yadav, Manager, 9871972662";
                //xlWorkSheet.Cells[i + 30, 2] = "Raj Bahadur Yadav";
                //xlWorkSheet.Cells[i + 31, 2] = "(Manager)";
                //xlWorkSheet.Cells[i + 32, 2] = "9871972662";
                //#region Excel Style formating
                ////formate excel file cell header style
                //rg = (Excel.Range)xlWorkSheet.Rows[6, Type.Missing];
                //rg.HorizontalAlignment = Excel.Constants.xlCenter;
                //rg.Font.Name = "Aerial";
                //rg.Font.Size = 10;
                //rg.WrapText = true;
                //rg.Font.Bold = true;

                ////formate excel Heading Style
                //rg = (Excel.Range)xlWorkSheet.Cells[2, 6];
                //rg.Font.Bold = true;
                //rg.Font.Size = 15;

                ////formate excel sub Heading Style
                //rg = (Excel.Range)xlWorkSheet.Cells[3, 6];
                //rg.Font.Size = 12;



                ////formate excel file cell header width
                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 1];
                ////rg.Cells.ColumnWidth = 25;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 2];
                ////rg.Cells.ColumnWidth = 11;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 3];
                ////rg.Cells.ColumnWidth = 11;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 4];
                ////rg.Cells.ColumnWidth = 8;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 5];
                ////rg.Cells.ColumnWidth = 10;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 6];
                ////rg.Cells.ColumnWidth = 8;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 7];
                ////rg.Cells.ColumnWidth = 13;
                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 8];
                ////rg.Cells.ColumnWidth = 8;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 9];
                ////rg.Cells.ColumnWidth = 12;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 10];
                ////rg.Cells.ColumnWidth = 9;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 11];
                ////rg.Cells.ColumnWidth = 10;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 12];
                ////rg.Cells.ColumnWidth = 13;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 13];
                ////rg.Cells.ColumnWidth = 11;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 14];
                ////rg.Cells.ColumnWidth = 20;
                ////rg.HorizontalAlignment = HorizontalAlignment.Right;


                //#endregion

                DialogResult result = saveFileDialog1.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    if (isExcel)
                    {
                        xlWorkBook.SaveAs(saveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    }
                    else
                    {
                        xlWorkBook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, saveFileDialog1.FileName, 0, true, false, Type.Missing, Type.Missing, true, Type.Missing);
                    }

                    xlWorkBook.Close(false, Type.Missing, Type.Missing);
                    xlApp.Quit();
                    //releaseObject(xlWorkSheet);
                    //releaseObject(xlWorkBook);
                    //releaseObject(xlApp);

                    MessageBox.Show("Excel file created , you can find the file " + saveFileDialog1.FileName);//c:\\csharp.net-informations.xls");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void PurchasesOrderExcelExport1(DataGridView dataGridView1, SaveFileDialog saveFileDialog1
            , string filePath
            , string PurcasesOrderNo, string PurchasesOrderDate, string CompanyName, string CompanyAddress
            , string CompanyCity, string CompanyState, string companyPincode)
        {
            try
            {

                Excel.Range rg = null;
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                //xlWorkBook = xlApp.Workbooks.Open(filePath, true, false,
                //                                      Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                //                                      Type.Missing, Type.Missing, true, Type.Missing,
                //                                      Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                //xlWorkSheet.Shapes.AddPicture("F:\rpPrinter", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 50, 50, 300, 45); 

                xlWorkSheet.Cells[11, 2] = PurcasesOrderNo;
                xlWorkSheet.Cells[11, 6] = PurchasesOrderDate;

                xlWorkSheet.Cells[14, 2] = CompanyName;
                xlWorkSheet.Cells[15, 2] = CompanyAddress + " ";
                xlWorkSheet.Cells[16, 2] = CompanyCity + " " + CompanyState + " " + companyPincode;
                xlWorkSheet.Cells[20, 2] = "Sir";
                xlWorkSheet.Cells[22, 2] = "Please provide the material as mentioned below:-";
                rg = (Excel.Range)xlWorkSheet.Cells[1, 2];
                rg.Cells.ColumnWidth = 35;

                int i = 0;
                int j = 0;


                for (j = 1; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    xlWorkSheet.Cells[24, j + 1] = dataGridView1.Columns[j].HeaderText;
                    rg = (Excel.Range)xlWorkSheet.Cells[24, j + 1];
                    rg.Cells.WrapText = true;
                    rg.Cells.Font.Bold = true;

                }


                for (i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    for (j = 1; j <= dataGridView1.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = dataGridView1[j, i];
                        xlWorkSheet.Cells[i + 25, j + 1] = j != 1 ? cell.Value : cell.FormattedValue;
                        rg = (Excel.Range)xlWorkSheet.Cells[i + 25, j + 1];
                        rg.Cells.WrapText = true;
                    }
                }

                decimal total = 0;
                for (int k = 0; k < dataGridView1.RowCount - 1; k++)
                {
                    total = total + Convert.ToDecimal(dataGridView1[4, k].Value);
                }

                xlWorkSheet.Cells[i + 24, 4] = "Total";
                xlWorkSheet.Cells[i + 24, 5] = total;

                xlWorkSheet.Cells[i + 27, 2] = "Note: Plz enclose the work order with the bills/Challan ";
                xlWorkSheet.Cells[i + 28, 2] = "Thanking You";
                xlWorkSheet.Cells[i + 29, 2] = "Yours Truly";
                xlWorkSheet.Cells[i + 30, 2] = "Raj Bahadur Yadav";
                xlWorkSheet.Cells[i + 31, 2] = "(Manager)";
                xlWorkSheet.Cells[i + 32, 2] = "9871972662";
                //#region Excel Style formating
                ////formate excel file cell header style
                //rg = (Excel.Range)xlWorkSheet.Rows[6, Type.Missing];
                //rg.HorizontalAlignment = Excel.Constants.xlCenter;
                //rg.Font.Name = "Aerial";
                //rg.Font.Size = 10;
                //rg.WrapText = true;
                //rg.Font.Bold = true;

                ////formate excel Heading Style
                //rg = (Excel.Range)xlWorkSheet.Cells[2, 6];
                //rg.Font.Bold = true;
                //rg.Font.Size = 15;

                ////formate excel sub Heading Style
                //rg = (Excel.Range)xlWorkSheet.Cells[3, 6];
                //rg.Font.Size = 12;



                ////formate excel file cell header width
                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 1];
                ////rg.Cells.ColumnWidth = 25;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 2];
                ////rg.Cells.ColumnWidth = 11;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 3];
                ////rg.Cells.ColumnWidth = 11;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 4];
                ////rg.Cells.ColumnWidth = 8;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 5];
                ////rg.Cells.ColumnWidth = 10;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 6];
                ////rg.Cells.ColumnWidth = 8;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 7];
                ////rg.Cells.ColumnWidth = 13;
                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 8];
                ////rg.Cells.ColumnWidth = 8;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 9];
                ////rg.Cells.ColumnWidth = 12;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 10];
                ////rg.Cells.ColumnWidth = 9;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 11];
                ////rg.Cells.ColumnWidth = 10;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 12];
                ////rg.Cells.ColumnWidth = 13;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 13];
                ////rg.Cells.ColumnWidth = 11;

                ////rg = (Excel.Range)xlWorkSheet.Cells[6, 14];
                ////rg.Cells.ColumnWidth = 20;
                ////rg.HorizontalAlignment = HorizontalAlignment.Right;


                //#endregion

                DialogResult result = saveFileDialog1.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {

                    xlWorkBook.SaveAs(saveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    MessageBox.Show("Excel file created , you can find the file " + saveFileDialog1.FileName);//c:\\csharp.net-informations.xls");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        


        #endregion
        public void Clearcontrol(Form form1)
        {
            form1.Controls.OfType<TextBox>().ToList().ForEach(row => row.Text = "");

        }

    }
}




      
                