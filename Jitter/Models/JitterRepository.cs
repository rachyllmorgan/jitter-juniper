using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jitter.Models
{
    public class JitterRepository
    {
        private JitterContext _context;
        public JitterContext Context{ get {return _context;}}

        public JitterRepository()
        {
            _context = new JitterContext();
        }
        // construstor that allows us to inject context
        public JitterRepository(JitterContext a_content)
        {
            _context = a_content;
        }

        public List<JitterUser> GetAllUsers()
        {
            return null;
        }
    }
}