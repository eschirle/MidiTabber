using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiTabber
{
    //TabStaff class represents a bass tab staff
    class TabStaff
    {
        //For now each bass string is represented as a string
        internal string E;
        internal string A;
        internal string D;
        internal string G;

        internal TabStaff()
        {
            E = "E|-";
            A = "A|-";
            D = "D|-";
            G = "G|-";
        }

        //Writes the fret number on the predetermined string followed by a "-" on all strings
        internal void AddNote(Note note)
        {
            string rest = "-";
            if (note.Fret.ToString().Length > 1) rest = "--";
            switch (note.Str)
            {
                case _String.E:
                    this.E += note.Fret;
                    this.A += rest;
                    this.D += rest;
                    this.G += rest;
                    break;
                case _String.A:
                    this.E += rest;
                    this.A += note.Fret;
                    this.D += rest;
                    this.G += rest;
                    break;
                case _String.D:
                    this.E += rest;
                    this.A += rest;
                    this.D += note.Fret;
                    this.G += rest;
                    break;
                case _String.G:
                    this.E += rest;
                    this.A += rest;
                    this.D += rest;
                    this.G += note.Fret;
                    break;
                default:
                    this.E += note.Fret;
                    this.A += rest;
                    this.D += rest;
                    this.G += rest;
                    break;
            }
            AddRest();
        }

        //Writes the fret number on lowest string as default followed by a "-" on all strings
        internal void AddNote(string fret)
        {
            string rest = "-";
            if (fret.Length > 1) rest = "--";
            //default single value is to put on E string
            this.E += fret;
            this.A += rest;
            this.D += rest;
            this.G += rest;
            AddRest();
        }

        //Simply writes the given strings onto the tab
        internal void AddNote(string e, string a, string d, string g)
        {
            this.E += e;
            this.A += a;
            this.D += d;
            this.G += g;
            AddRest();
        }

        //Adds a rest "-" to each string 
        internal void AddRest(int n = 1)
        {
            if (n > 24) n = 24;
            for (int i = 0; i < n; i++)
            {
                this.E += "-";
                this.A += "-";
                this.D += "-";
                this.G += "-";
            }
        }

        //Writes the ending of the staff line
        internal void EndStaff()
        {
            E += "|";
            A += "|";
            D += "|";
            G += "|";
        }

        public override string ToString()
        {
            return G + "\n" + D + "\n" + A + "\n" + E + "\n\n";
        }
    }
}
