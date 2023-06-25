using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;

namespace Client
{
    public static class SessionManager
    {
        public static User loggedInUser { get; set; }
    }
}
