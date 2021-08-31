using System.Collections.Generic;
using petshop.Models;

namespace petshop
{
    public class fakeDB
    {
        public static List<Cat> Cats { get; set; } = new List<Cat>() { new Cat("Garfield", 12, "hungry")};
    }
}