
using System.ComponentModel;

namespace Almuerzo
{
  internal class Food
  {
    [DisplayName("Company Name")]
    public string Company { get; set; }
    [DisplayName("Food Name")]
    public string Name { get; set; }
    [DisplayName("Price")]
    public int Price { get; set; }
    [Browsable(false)]
    public FoodType Type { get; set; }
    [Browsable(false)]
    public int Chance { get; set; }
  }
}