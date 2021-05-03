using System;

namespace Program.Models
{
    public class SignUpRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set;}
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Hobbies { get; set; }
        public string Device { get; set; }
    }
}