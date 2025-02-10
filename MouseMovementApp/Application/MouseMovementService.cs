using MouseMovementDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseMovementApp.Application
{
    public class MouseMovementService
    {
        private readonly ICoordinateRepository _repository;

        public MouseMovementService(ICoordinateRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> SaveMouseDataAsync(MouseDataDto mouseData)
        {
            if (mouseData == null || !mouseData.Coordinates.Any())
                throw new ArgumentException("Mouse data cannot be null or empty.");

            await _repository.AddCoordinateAsync(mouseData);
            return mouseData.Coordinates.Count;
        }
    }
}
