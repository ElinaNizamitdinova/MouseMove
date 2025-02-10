using MouseMovementContext.Models;
using MouseMovementDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MouseMovementContext.infrastructure
{
    public class CoordinateRepository : ICoordinateRepository
    {
        private readonly mousemovementContext _context;

        public CoordinateRepository(mousemovementContext context)
        {
            _context = context;
        }

        public async Task AddCoordinateAsync(MouseDataDto mouseData)
        {


            var jsonData = JsonSerializer.Serialize(mouseData.Coordinates);
            _context.Coordinates.Add(new Coordinate { Data = jsonData });
            await _context.SaveChangesAsync();
        }
    }
}
