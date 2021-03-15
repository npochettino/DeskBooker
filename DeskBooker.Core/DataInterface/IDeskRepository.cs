using DeskBooker.Core.Domain;
using System;
using System.Collections.Generic;

namespace DeskBooker.Core.DataInterface
{
    public interface IDeskRepository
    {
        IEnumerable<Desk> GetAvailbleDesks(DateTime date);
    }
}
