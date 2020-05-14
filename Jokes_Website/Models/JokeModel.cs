/*====================================================================================
Klasa JokeModel. Jest to klasa, która posiada takie atrybuty jak Joke, czyli żart    |
oraz status. Joke zawiera w sobie dany tekst - dowcip. Status będzie potrzebny do    |
stwierdzenia, czy żarty załadowały się w sposób prawidłowy.                          |
 ====================================================================================*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jokes_Website.Models
{
    public class JokeModel
    {
        public string Joke { get; set; }
        public string Status { get; set; }
    }
}
