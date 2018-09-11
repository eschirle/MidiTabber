using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiTabber
{
    //to choose which string to play the note...
    enum _String { E, A, D, G, X };
    //currently works for 4 string bass... will possibly need to tweak this system for more strings / different tunings, etc. 

    //Represents a single musical note
    class Note
    {
        public int Time;
        public int Pitch;
        public int Fret;
        public _String Str;

        public Note(int time, int pitch, int fret = -1)
        {
            this.Time = time;
            this.Pitch = pitch;
            this.Fret = fret;
        }

        //Notes with same pitch&time are equal no matter where they are played on the neck. 
        public override bool Equals(object obj)
        {
            var note = obj as Note;
            return note != null &&
                   Time == note.Time &&
                   Pitch == note.Pitch;
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = (hash * 5) + Time.GetHashCode();
            hash = (hash * 5) + Pitch.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", Time, Pitch);
        }

    }
}
