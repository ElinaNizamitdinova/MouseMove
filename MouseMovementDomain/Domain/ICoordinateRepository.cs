using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseMovementDomain.Domain
{
    public interface ICoordinateRepository
    {
        Task AddCoordinateAsync(MouseDataDto mouseData);
    }
}
