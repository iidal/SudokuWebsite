using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuWebsite.Models
{
    public class BoardSlot
    {
        public int Id { get; set; }
        public int[] Slot {get; set;}
        public int Value { get; set; }
        public bool Selected { get; set; }

        public BoardSlot(int id, int[] slot, int value, bool selected) {
            Id = id;
            Slot = new int[] { slot[0], slot[1] };
            Value = value;
            Selected = selected;
        }
    }

}
