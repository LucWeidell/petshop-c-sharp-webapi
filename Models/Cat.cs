using System.ComponentModel.DataAnnotations;
namespace petshop.Models
{
    public class Cat
    {

    // FIXME faking ids for now
    public string Id { get; set; }
    // Data attributes apply to the value below them
    [Required]
    [MinLength(3)]
    [MaxLength(15)]
    public string Name { get; set; }

    [Range(0, int.MaxValue)]
    public int Age { get; set; }
    public string Mood { get; set; }

    public Cat(string name, int age, string mood)
    {
      Name = name;
      Age = age;
      Mood = mood;

      // NOTE global id creation but nly used cause fakeDb
      Id = Guid.NewGuid().ToString();

    }
    }
}