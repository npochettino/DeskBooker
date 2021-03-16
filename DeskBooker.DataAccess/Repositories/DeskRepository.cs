﻿using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskBooker.DataAccess.Repositories
{
    public class DeskRepository : IDeskRepository
    {
        private readonly DeskBookerContext _context;

        public DeskRepository(DeskBookerContext context)
        {
            _context = context;
        }

        public IEnumerable<Desk> GetAll()
        {
            return _context.Desk.ToList();
        }

        public IEnumerable<Desk> GetAvailbleDesks(DateTime date)
        {
            var bookDeskIds = _context.DeskBooking
                .Where(x => x.Date == date)
                .Select(b => b.DeskId)
                .ToList();

            return _context.Desk
                .Where(x => !bookDeskIds.Contains(x.Id))
                .ToList();
        }
    }
}
