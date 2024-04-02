using System.ComponentModel.DataAnnotations;

namespace project.Model;

public class Comment
{
    [Key]
    public int id { get; set; }
    public int userid { get; set; }
    public User user { get; set; } = new();
    public string message { get; set; } = "";
    public string data { get; set; } = "";
}
