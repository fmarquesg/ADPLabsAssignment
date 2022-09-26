using ADPLabsAssignment.Domain;
using ADPLabsAssignment.Interfaces.Services;
using ADPLabsAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ADPLabsAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ADPTaskController : Controller
    {
        readonly IADPTaskSolver _aDPTaskSolver;

        public ADPTaskController(IADPTaskSolver aDPTaskSolver)
        {
            _aDPTaskSolver = aDPTaskSolver;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetADPTask()
        {
            return Ok(await _aDPTaskSolver.GetADPTask());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultMessage))]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(ResultMessage))]
        public async Task<ActionResult> PostSolvedTask(ADPTaskInformation aDPTaskInformation)
        {
            var response = await _aDPTaskSolver.PostSolvedTask(aDPTaskInformation);

            return StatusCode(response.statusCode, response.message);
        }


    }
}
