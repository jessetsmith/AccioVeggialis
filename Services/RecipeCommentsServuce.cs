using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class RecipeCommentsServuce
    {
        private readonly Guid _userID;

        public RecipeCommentsServuce(Guid userID)
        {
            _userID = userID;
        }
    }
}
