using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string isim { get; set; }
        public int puan { get; set; }
    }
}