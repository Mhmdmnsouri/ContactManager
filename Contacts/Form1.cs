using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contacts.Services;

namespace Contacts
{
        public partial class Form1 : Form
    {
        IContactsRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new ContactsRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid() 
        {
            dgContacts.AutoGenerateColumns = false;
            dgContacts.DataSource = repository.SelectAll();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BtnNewContact_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                BindGrid();
                if(frm.DialogResult == DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(dgContacts.CurrentRow != null)
            {
                string name = dgContacts.CurrentRow.Cells[1].Value.ToString();
                string family = dgContacts.CurrentRow.Cells[2].Value.ToString();
                string fullname = name +" "+family;
                if (MessageBox.Show($"آیا از حذف {fullname} مطمئن هستید؟","توجه",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int contactId = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString());
                    repository.Delete(contactId);
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک شخص را از لیست انتخاب کنید");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if(dgContacts.CurrentRow != null)
            {
                int contactId = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString()); 
                frmAddOrEdit frm = new frmAddOrEdit();
                frm.contactId = contactId;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }

            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dgContacts.DataSource = repository.Search(txtsearch.Text);
        }
    }
}
