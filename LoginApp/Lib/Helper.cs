using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp.Lib
{
    public class Helper
    {
        public void ReloadGrid<T>(DataGridView gridName, List<T> dataSource) where T : class
        {
            try
            {
                gridName.DataSource = null;
                gridName.Columns.Clear();
                gridName.DataSource = dataSource;
            }
            catch { throw; }
        }
        public void ReloadGrid<T>(DataGridView gridName, List<T> dataSource, List<int> hideCollIdx = null, bool hasDeleteAction = false, bool hasUpdateAction = false) where T : class
        {
            try
            {
                gridName.DataSource = null;
                gridName.Columns.Clear();
                gridName.DataSource = dataSource;

                if (hideCollIdx != null && hideCollIdx.Count > 0)
                {
                    foreach (int idx in hideCollIdx)
                    {
                        gridName.Columns[idx].Visible = false;
                    }
                }

                if (hasDeleteAction)
                {
                    DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                    btnDelete.HeaderText = "Actions";
                    btnDelete.Name = "btnDelete";
                    btnDelete.Text = "Delete";
                    btnDelete.UseColumnTextForButtonValue = true;
                    gridName.Columns.Add(btnDelete);
                }
                if (hasUpdateAction)
                {
                    DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
                    btnUpdate.HeaderText = "Actions";
                    btnUpdate.Name = "btnUpdate";
                    btnUpdate.Text = "Update";
                    btnUpdate.UseColumnTextForButtonValue = true;
                    gridName.Columns.Add(btnUpdate);
                }
            }
            catch { throw; }
        }
        public void ReloadGrid<T>(DataGridView gridName, List<T> dataSource, List<int> hideCollIdx = null, List<GridAction> gridActions = null) where T : class
        {
            try
            {
                gridName.DataSource = null;
                gridName.Columns.Clear();
                gridName.DataSource = dataSource;

                if (hideCollIdx != null && hideCollIdx.Count > 0)
                {
                    foreach (int idx in hideCollIdx)
                    {
                        gridName.Columns[idx].Visible = false;
                    }
                }
                if (gridActions != null)
                {
                    foreach (GridAction action in gridActions)
                    {
                        DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn();
                        btnAction.HeaderText = "";
                        btnAction.Name = action.Name;
                        btnAction.Text = action.Text;
                        btnAction.UseColumnTextForButtonValue = true;
                        gridName.Columns.Add(btnAction);
                    }
                }
            }
            catch { throw; }
        }

        /// <summary>
        /// (this.Controls)
        /// </summary>
        /// <param name="controls"></param>
        public void ClearForm(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = 0;
                }
                else if (control is NumericUpDown)
                {
                    ((NumericUpDown)control).Value = 0;
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }
                else if (control is RichTextBox)
                {
                    ((RichTextBox)control).Clear();
                }
                if (control.HasChildren)
                {
                    ClearForm(control.Controls);
                }
            }
        }
        public string SaveFileDiolog(string filter = "All Files (*.*)|*.*", string defaultExt = "*.*")
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = filter;
                saveFileDialog.DefaultExt = defaultExt;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
            }
            return null;
        }
        public string OpenFileDialog(string filter = "All Files (*.*)|*.*", string defaultExt = "*.*")
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = filter;
                openFileDialog.DefaultExt = default;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }
            return null;
        }
    }

    public class GridAction
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
