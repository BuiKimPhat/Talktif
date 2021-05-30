namespace Talktif.Models
{
    public class WaitUser
    {
        public string ConnectionID { get; set; }
        public string Filter { get; set; }
        public string SkipID { get; set; }
        public User_Infor info { get; set; }
    }
}