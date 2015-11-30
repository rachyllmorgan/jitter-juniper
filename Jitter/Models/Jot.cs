using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jitter.Models
{
    public class Jot : IComparable
    {
        public JitterUser Author { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        [Key]
        public int JotId { get; set; }
        public string Picture { get; set; }

        public int CompareTo(object obj)
        {
            // Sort jots based on dates
            // We need to explicitly cast from object type to Jot Type
            Jot other_jot = obj as Jot;
            //CompareTo sorts Ascendingly by default
            //Mulitply by -1 to reverse sort order
            return -1 * (this.Date.CompareTo(other_jot.Date));
        }
    }
}