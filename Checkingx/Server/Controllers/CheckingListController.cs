﻿using AutoMapper;
using Checkingx.Server.Data;
using Checkingx.Shared;
using Checkingx.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Checkingx.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckingListController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CheckingListController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [SwaggerOperation(Summary = "Return all checkings.")]
        [HttpGet("all")]
        public async Task<ActionResult<List<Checking>>> GetAllCheckings()
        {
            return Ok(await _context.Checking.ToListAsync());
        }
        [SwaggerOperation(Summary = "Return all checkings by project Id.")]
        [HttpGet("all/project/{projectId}")]
        public async Task<ActionResult<List<Checking>>> GetAllCheckingsByProjectId(int projectId)
        {
            var findCheckings = await _context.Checking.Where(x => x.ProjectId == projectId).Include(x => x.CheckItem).ToListAsync();

            return Ok(findCheckings);
        }

        [SwaggerOperation(Summary = "Return single checking entry by checking Id.")]
        [HttpGet("single/{checkingId}")]
        public async Task<ActionResult<Checking>> GetSingleCheckingById(int checkingId)
        {
            var findChecking = await _context.Checking.Include(x => x.CheckItem).FirstOrDefaultAsync(x => x.CheckingId == checkingId);
            if (findChecking == null) return NotFound("Checking not found.");

            return Ok(findChecking);
        }

        [SwaggerOperation(Summary = "Create new checking entry.")]
        [HttpPost("create")]
        public async Task<ActionResult<Checking>> PostChecking(CheckingCreateDTO modelDto)
        {
            var newChecking = _mapper.Map<Checking>(modelDto);
            _context.Checking.Add(newChecking);
            await _context.SaveChangesAsync();

            return Ok(newChecking);
        }

        [SwaggerOperation(Summary = "Mark as Correct, single checking entry. [IsCorrected] prop update.")]
        [HttpPut("single/correct/{checkingId}")]
        public async Task<ActionResult<Checking>> CorrectError(CheckingCorrectDTO checking, int checkingId)
        {
            var findChecking = await _context.Checking.FirstOrDefaultAsync(x => x.CheckingId == checkingId);
            if (findChecking == null)
                return NotFound("Checking not found.");

            findChecking.IsCorrected = checking.IsCorrected;

            await _context.SaveChangesAsync();

            return Ok(findChecking);
        }
    }
}