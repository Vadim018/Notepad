using System;
using System.IO;
using System.Windows.Forms;

namespace lab_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Items.Add(new ToolStripButton("Створити", null, CreateMenuItem_Click));
            toolStrip.Items.Add(new ToolStripButton("Відкрити", null, OpenMenuItem_Click));
            toolStrip.Items.Add(new ToolStripButton("Зберегти", null, SaveMenuItem_Click));
            toolStrip.Items.Add(new ToolStripButton("Вихід", null, ExitMenuItem_Click));

            Controls.Add(toolStrip);

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Вирізати", null, CutMenuItem_Click);
            contextMenu.Items.Add("Копіювати", null, CopyMenuItem_Click);
            contextMenu.Items.Add("Вставити", null, PasteMenuItem_Click);

            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Файл");
            ToolStripMenuItem editMenu = new ToolStripMenuItem("Редагування");

            fileMenu.DropDownItems.Add("Створити", null, CreateMenuItem_Click);
            fileMenu.DropDownItems.Add("Відкрити", null, OpenMenuItem_Click);
            fileMenu.DropDownItems.Add("Зберегти", null, SaveMenuItem_Click);
            fileMenu.DropDownItems.Add("Вихід", null, ExitMenuItem_Click);

            editMenu.DropDownItems.Add("Вирізати", null, CutMenuItem_Click);
            editMenu.DropDownItems.Add("Копіювати", null, CopyMenuItem_Click);
            editMenu.DropDownItems.Add("Вставити", null, PasteMenuItem_Click);

            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(editMenu);

            Controls.Add(menuStrip);

            richTextBox1.ContextMenuStrip = contextMenu;
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = "";
        }

        private void CreateMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void PasteMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void CutMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
    }
}