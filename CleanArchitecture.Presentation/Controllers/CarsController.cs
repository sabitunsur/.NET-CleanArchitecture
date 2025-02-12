﻿using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Authorization;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Presentation.Controllers
{
    public sealed class CarsController : ApiController
    {
        public CarsController(IMediator mediator) : base(mediator){}

        [RoleFilter("Create")]
        [HttpPost("[action]")] // POST: api/Cars/Create
        public async Task<IActionResult> Create(CreateCarCommand request,CancellationToken cancellationToken)
        {
            MessageResponse response =  await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [RoleFilter("GetAll")]
        [HttpPost("[action]")] // POST: api/Cars/GetAll
        public async Task<IActionResult> GetAll(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            PaginationResult<Car> response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
 