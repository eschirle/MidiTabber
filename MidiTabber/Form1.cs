using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiTabber
{
    public partial class Form1 : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();

        string midi_filename;
        string midi_filepath;
        string tab_filepath;

        public Form1()
        {
            InitializeComponent();

            ofd.Title = "Select a MIDI file to tab";
            sfd.Filter = "Text File|*.txt";
            sfd.Title = "Save the tabs as Text";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void SelectMidiFileButton_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                midi_filename = ofd.SafeFileName;

                if (midi_filename == "")
                    return;

                midi_filename = midi_filename.Substring(0, midi_filename.LastIndexOf(".mid"));  //remove the file extension
                midi_filepath = ofd.FileName;

                SelectFileTextBox.Text = midi_filepath;
            }

            //MessageBox.Show("You chose " + midi_filename + ".  The location is: \n" + midi_filepath);
        }

        private void WriteTabButton_Click(object sender, EventArgs e)
        {
            //Call midicsv.exe - creates a readable CSV .txt file
            TabWriter.MidiCsv(midi_filepath + " " + midi_filename + ".txt");
            System.Threading.Thread.Sleep(200);

            //Open SaveFileDialog to save the tabs
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                tab_filepath = sfd.FileName;
            }

            //Write the Tabs
            TabWriter.Tab(midi_filename, tab_filepath);
            System.Threading.Thread.Sleep(200);

            System.IO.File.Delete(midi_filename + ".txt");
        }
    }
}
