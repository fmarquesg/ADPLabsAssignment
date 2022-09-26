using ADPLabsAssignment.Domain;
using ADPLabsAssignment.Models;
using System.Threading.Tasks;

namespace ADPLabsAssignment.Interfaces.Services
{
    public interface IADPTaskSolver
    {
        public Task<ADPTaskInformation> GetADPTask();

        public Task<ResultMessage> PostSolvedTask(ADPTaskInformation aDPTaskInformation);
    }
}
