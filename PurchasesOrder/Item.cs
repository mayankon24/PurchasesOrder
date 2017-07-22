using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PurchasesOrder.DataLayer;
using PurchasesOrder.Entity;
using GlobleLibrary;

namespace PurchasesOrder
{
    public partial class Item : Form
    { 
        #region Property
        public ItemNameEL DataGridViewSelectedItem
        {
            get
            {
                ItemNameEL objItemNameEL = new ItemNameEL();
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    objItemNameEL.Item_id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Item_Id"].Value);
                    objItemNameEL.Item_name = dataGridView1.SelectedRows[0].Cells["Item_Name"].Value.ToString();
                }
                return objItemNameEL;
            }
        } 
        #endregion

        #region Constructor
        public Item()
        {
            InitializeComponent();
            Common objCommon = new Common();
            objCommon.SetStyle(this);
          
            ControlClear();
            
        }
        #endregion

        #region Event
        private void Item_Load(object sender, EventArgs e)
        {
            GridBind();
        }

        #region Functionality Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textItemName.Text))
                {
                    Common.MessageAlert("First Enter Item Name");
                }
                else
                {
                    ItemNameEL objItemEL = new ItemNameEL();
                    ItemNameDL objItemDL = new ItemNameDL();

                    objItemEL.Item_name = textItemName.Text;
                    int inserResult = objItemDL.Insert(objItemEL);

                    if (inserResult != 0)
                    {
                        if (inserResult == (int)DuplicateItem.Yes)
                        {
                            Common.MessageAlert("This item ia already present");
                        }
                        else
                        {
                            Common.MessageSave();
                            GridBind();
                            ControlClear();
                        }
                    }
                }
            }
            catch
            {

            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ControlClear();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textItemName.Text))
                {
                    Common.MessageAlert("First Enter Item Name");
                }
                else
                {
                    ItemNameEL objItemEL = new ItemNameEL();
                    ItemNameDL objItemDL = new ItemNameDL();

                  
                    objItemEL.Item_name = textItemName.Text;                                     
                    objItemEL.Item_id = DataGridViewSelectedItem.Item_id;
                    int updateResult = objItemDL.Update(objItemEL);


                    if (updateResult != 0)
                    {
                        if (updateResult == (int)DuplicateItem.Yes)
                        {
                             Common.MessageAlert("This item ia already present");
                        }                            
                        else
                        {
                            Common.MessageUpdate();
                            GridBind();
                            ControlClear();
                        }
                    }
                }

            }
            catch
            {

            }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Common.MessageConfim("Are You Want To Delete This "))
                {
                    ItemNameEL objItemEL = new ItemNameEL();
                    ItemNameDL objItemDL = new ItemNameDL();

                    objItemEL.Item_id = DataGridViewSelectedItem.Item_id;


                    if (objItemDL.Delete(objItemEL))
                    {
                        Common.MessageDelete();
                        GridBind();
                        ControlClear();
                    }
                    else
                    {

                    }
                }

            }
            catch
            {

            }

        }
       
        #endregion

      
        #endregion

        #region Private Method
        void ControlClear()
        {
            Common objCommon = new Common();
            objCommon.ClearControl(this);

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;                        
        }
        void BindControl()
        {
            try
            {
                ItemNameEL objItemEL = DataGridViewSelectedItem;             
                textItemName.Text = objItemEL.Item_name;
               
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
            }
            catch
            {
                ControlClear();
            }

        }
        
     
        #endregion        

        #region DataGrid operation
        void GridBind()
        {
            try
            {
                ItemNameDL objItemDL = new ItemNameDL();
                List<ItemNameEL> ItemList = objItemDL.GetItemNameAll();

                dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;
                dataGridView1.Click-= dataGridView1_Click;
                dataGridView1.DataSource = ItemList;
                dataGridView1.Columns["Item_id"].Visible = false;
                dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
                dataGridView1.Click += dataGridView1_Click;
            }
            catch
            {
            }
            ControlClear();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            BindControl();
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            BindControl();
        }

        #endregion        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

