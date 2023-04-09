﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetManufacturers
{
    public class GetManufacturersQuery : IRequest<IList<GetManufacturerDto>>
    {
    }
}
