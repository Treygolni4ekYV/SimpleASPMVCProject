using System.ComponentModel.DataAnnotations;

namespace project.Model;

public class User
{
    [Key]
    public int id { get; set; }
    public string name { get; set; } = "";
    public string login { get; set; } = "";
    public string password { get; set; } = "";
    public List<Comment> comments {get;set;} = new();
}
