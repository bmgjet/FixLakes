using System;
using System.IO;
using System.Windows.Forms;
using ProtoBuf;

namespace FixLakes
{
    public partial class FixlakesGUI : Form
    {
        public FixlakesGUI()
        {
            InitializeComponent();
        }

        private void Fixbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Map Files",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "map",
                Filter = "map files (*.map)|*.map",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                WorldSerialization worldData = new WorldSerialization();
                worldData.Load(openFileDialog1.FileName);
                int found = 0;
                foreach (PrefabData prefabData in worldData.world.prefabs)
                {
                    if(prefabData.id == 2666567578)
                    {
                        found++;
                        prefabData.id = 3698016822;
                    }
                }
                MessageBox.Show("Fixed " + found + " Lake IDs", "Fixed");
                worldData.Save(openFileDialog1.FileName.Replace(".map", "-Fixed.map"));
            }
        }
    }
}
