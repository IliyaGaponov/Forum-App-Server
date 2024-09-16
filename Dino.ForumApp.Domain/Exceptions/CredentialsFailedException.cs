using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dino.ForumApp.Domain.Exceptions
{
    public class CredentialsFailedException : Exception
    {
        public CredentialsFailedException() : base("Credentials verification failed.") { }
    }
}
