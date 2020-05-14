/*====================================================================================
Klasa JokeModels. Zawiera ona w sobie listę JokeModel - czyli lista                  |
stringów Joke (żartów).                                                              |
 ====================================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jokes_Website.Models
{
    public class JokesModel
    {
        public IList<JokeModel> Results { get; set; }
        public JokesModel()
        {
            Results = new List<JokeModel>();
        }
    }
}
