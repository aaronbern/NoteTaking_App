using System.Data;

namespace NoteTaking_App
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        
    public NoteTaker()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");
            dataGridView1.DataSource = notes;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            noteBox.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (editing && dataGridView1.CurrentCell != null)
            {
                notes.Rows[dataGridView1.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                notes.Rows[dataGridView1.CurrentCell.RowIndex]["Note"] = noteBox.Text;
            }
            else
            {
                notes.Rows.Add(titleBox.Text, noteBox.Text);
            }
            titleBox.Text = "";
            noteBox.Text = "";
            editing = false;
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[dataGridView1.CurrentCell.RowIndex].Delete();
                titleBox.Text = "";
                noteBox.Text = "";
            }
            catch (Exception ex) { Console.WriteLine("Not a valid note"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null &&
               notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0] != null)
            {
                titleBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
                noteBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();
                editing = true;
            }
        }

        private void Note_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell != null &&
                notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0] != null)
            {
                titleBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
                noteBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();
                editing = true;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                            editing = true;
            if (dataGridView1.CurrentCell != null &&
                notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0] != null)
            {
                titleBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
                noteBox.Text = notes.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();
                editing = true;
            }
        }
    }
}