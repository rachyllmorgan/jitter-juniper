using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jitter.Models
{
    public class JitterRepository
    {
        private JitterContext _context;
        public JitterContext Context { get {return _context;}}

        public JitterRepository()
        {
            _context = new JitterContext();
        }

        public JitterRepository(JitterContext a_context)
        {
            _context = a_context;
        }

        public List<JitterUser> GetAllUsers()
        {
            var query = from users in _context.JitterUsers select users;
            return query.ToList();
        }

        public JitterUser GetUserByHandle(string handle)
        {
            // SQL: select * from JitterUser where JitterUser.Handle = handle;
            var query = from user in _context.JitterUsers where user.Handle == handle select user;
            return query.SingleOrDefault();
        }

        public bool IsHandleAvailable(string handle)
        {
            bool available = false;
            // try catch added to handle multiple users
            try
            {
                JitterUser some_user = GetUserByHandle(handle);
                if (some_user == null)
                {
                    available = true;
                }
            }
            catch (InvalidOperationException)
            {
            }
            return available;
        }

        public List<JitterUser> SearchByHandle(string handle)
        {
            //SQL: select * from JitterUsers AS users where users.Handle like %handle%;
            var query = from user in _context.JitterUsers select user;
            List<JitterUser> found_users = query.Where(users => users.Handle.Contains(handle)).ToList();
            found_users.Sort();
            return found_users;
        }
    }
}