using System.Collections.Generic;

namespace Talktif.Models
{
    public class RandomRoom
    {
        public string ID { get; set; }
        public WaitUser[] Members { get; set; }
    }
}