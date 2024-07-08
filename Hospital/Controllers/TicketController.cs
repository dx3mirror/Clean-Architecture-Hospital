using API.Core.Query;
using API.Core.Repository;
using API.Core.Service;
using API.Domain.EntityProcedure;
using API.UseCase.Command;
using Application.DTOs.Inpuct;
using Application.Interface.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Hospital.Controllers
{
    public class TicketController : Controller
    {
        private readonly IMediator _mediator;
        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("tickets")]
        [ProducesResponseType(typeof(IEnumerable<Ticket>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetTicketsByDate([FromQuery] DateTime date)
        {
            if (date == default)
            {
                return BadRequest("Invalid date parameter.");
            }

            var query = new GetTicketsByDateQuery(date);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("patients")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> AddPatient(string firstName, string lastName, DateTime dateOfBirth, string phone, string email)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                    return BadRequest("Validation errors: " + string.Join(", ", errors));
                }

                var query = new AddPatientCommand(firstName, lastName, dateOfBirth, phone, email);
                var result = await _mediator.Send(query);

                
                    return Ok();
                
            }
            catch (Exception ex)
            {
                // Log the exception
                // Optionally return a more generic error message to the client
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet("patients/{patientId}/tickets")]
        [ProducesResponseType(typeof(IEnumerable<Ticket>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetTicketsByPatient(int patientId)
        {
            if (patientId <= 0)
            {
                return BadRequest("Invalid patient ID.");
            }

            var query = new GetTicketsByPatientQuery(patientId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("doctors/{doctorId}/tickets")]
        [ProducesResponseType(typeof(IEnumerable<Ticket>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> GetTicketsByDoctor(int doctorId)
        {
            if (doctorId <= 0)
            {
                return BadRequest("Invalid doctor ID.");
            }

            var query = new GetTicketsByDoctorQuery(new TicketDoctorResult { doctorId = doctorId });
            var result = await _mediator.Send(query);

            if (result == null || result.Count == 0)
            {
                return NotFound("No tickets found for the specified doctor.");
            }

            return Ok(result);
        }

        [HttpGet("doctors/{doctorId}/schedule")]
        [ProducesResponseType(typeof(DoctorSchedule), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetDoctorSchedule(int doctorId)
        {
            if (doctorId <= 0)
            {
                return BadRequest("Invalid doctor ID.");
            }

            var query = new GetDoctorScheduleQuery(doctorId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("doctors/specializations")]
        [ProducesResponseType(typeof(IEnumerable<DoctorSpecialization>), 200)]
        public async Task<IActionResult> GetDoctorSpecializations()
        {
            var query = new GetAllDoctorsAndSpecializationsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
