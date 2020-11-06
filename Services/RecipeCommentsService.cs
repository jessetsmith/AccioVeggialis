using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class RecipeCommentsService
    {
        private readonly Guid _userID;

        public RecipeCommentsService(Guid userID)
        {
            _userID = userID;
        }
    }
}
