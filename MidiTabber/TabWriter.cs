using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.Diagnostics;

namespace MidiTabber
{
    static class TabWriter
    {
        const int MaxStaffLength = 88;

        static string filename;

        //Create a list of note objects before tabbing out the part
        static LinkedList<Note> notes = new LinkedList<Note>();

        //Return the corresponding fret to play the given pitch on the given string. 
        static int FindFret(_String s, int pitch)
        {
            int fret = -1;
            switch (s)
            {
                case _String.E:
                    fret = pitch - 40;
                    break;
                case _String.A:
                    fret = pitch - 45;
                    break;
                case _String.D:
                    fret = pitch - 50;
                    break;
                case _String.G:
                    fret = pitch - 55;
                    break;
            }
            return fret;
        }

        //Return the string on the instrument used to play the given pitch at the given fret
        static _String FindString(int fret, int pitch)
        {
            int x = pitch - fret;
            if (x == 40) return _String.E;
            if (x == 45) return _String.A;
            if (x == 50) return _String.D;
            if (x == 55) return _String.G;
            return _String.X;
        }

        //Call midicsv.exe using the given arguments as a single string
        public static void MidiCsv(string args)
        {
            // midicsv.exe C:/.../midiFile.mid midiCsv.txt

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "midicsv"; //file to run
            startInfo.Arguments = args;

            process.StartInfo = startInfo;
            process.Start();

            //REALLY BAD CODING below... need a fix for this function to wait for the CSV file to write. 
            while (!process.HasExited) { }
        }

        //Read the csv file and captures the time and note values into a list of notes
        static void ReadMidiTxt(String csvFile)
        {
            string line;
            StreamReader midiFile = new StreamReader(csvFile);

            while (midiFile.EndOfStream == false)
            {
                line = midiFile.ReadLine();

                if (line.Contains("Note_on_c"))
                {     //if the midi line is a Note_on, get the time and note values 
                    string[] NoteLine = line.Split(',');
                    notes.AddLast(new Note(Int32.Parse(NoteLine[1]) / 80, Int32.Parse(NoteLine[4])));
                }
            }

            midiFile.Close();

        }

        //Write the captured list of notes out as a TabStaff object, and then write to file
        static void WriteTabs(string out_path)
        {
            StreamWriter sw = new StreamWriter(out_path);

            Note prevNote = notes.First();
            TabStaff tab = new TabStaff();

            foreach (Note note in notes)
            {
                //write note into the tab.
                int restSpace = (note.Time - prevNote.Time) / 3 - 2;

                if (tab.E.Length + restSpace > MaxStaffLength)
                {
                    tab.EndStaff();
                    sw.Write(tab.ToString());
                    tab = new TabStaff();
                }
                tab.AddRest(restSpace);

                //ChooseStringBasic(tab, note);
                ThreeFretSameString(tab, note, prevNote);

                prevNote = note;
            }

            tab.EndStaff();
            sw.WriteLine(tab.ToString());
            sw.Close();
        }

        //Chooses the string based off nothing but pitch, prefers higher string
        static void ChooseStringBasic(TabStaff tab, Note note)
        {
            int pitch = note.Pitch;
            if (pitch < 40)
            //unplayable on a 4-string bass
            {
                tab.AddNote("#", "#", "#", "#");
            }
            else if (pitch <= 45)
            {
                note.Fret = pitch - 40;
                note.Str = _String.E;
            }
            else if (pitch <= 51)
            {
                note.Fret = pitch - 45;
                note.Str = _String.A;
            }
            else if (pitch <= 57)
            {
                note.Fret = pitch - 50;
                note.Str = _String.D;
            }
            else
            {
                note.Fret = pitch - 55;
                note.Str = _String.G;
            }
            tab.AddNote(note);
        }

        //More than 3 fret difference forces change of string (returning the fret used)
        static void ThreeFretSameString(TabStaff tab, Note curNote, Note prevNote)
        {
            //choose the string / fret combination based off the prevNote's string / fret. 
            if (curNote.Pitch == 40)
            {
                curNote.Fret = 0;
                curNote.Str = _String.E;
            }
            else if (curNote.Pitch < prevNote.Pitch && curNote.Pitch == 45)
            {
                curNote.Fret = 0;
                curNote.Str = _String.A;
            }
            else if (Math.Abs(curNote.Pitch - prevNote.Pitch) < 3)
            {
                curNote.Str = prevNote.Str;
                curNote.Fret = FindFret(curNote.Str, curNote.Pitch);
                tab.AddNote(curNote);
            }
            else
            {
                ChooseStringBasic(tab, curNote);
            }

        }

        //Writes the tabs to a txt file given the csv file name and output path
        public static void Tab(string csv_name, string writepath)
        {
            //the csv file to read 
            filename = csv_name;
            ReadMidiTxt(filename + ".txt");

            WriteTabs(writepath);
        }
    }
}
