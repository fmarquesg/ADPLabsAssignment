using ADPLabsAssignment.Domain;
using ADPLabsAssignment.Interfaces.Services;
using ADPLabsAssignment.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ADPLabsAssignment.Services
{
    public class ADPTaskSolverService : IADPTaskSolver
    {
        public ADPTaskSolverService()
        {
            httpClient = new();
        }

        private static HttpClient httpClient;

        public async Task<ADPTaskInformation> GetADPTask()
        {
            var response = await httpClient.GetAsync("https://interview.adpeai.com/api/v1/get-task");
            return JsonSerializer.Deserialize<ADPTaskInformation>(await response.Content.ReadAsStringAsync());
        }

        private double CalculateResultValue(ADPTaskInformation ADPTask)
        {
            return ADPTask.operation switch
            {
                "subtraction" => ADPTask.left - ADPTask.right,
                "division" => ADPTask.left / ADPTask.right,
                "multiplication" => ADPTask.left * ADPTask.right,
                "addition" => ADPTask.left + ADPTask.right,
                _ => throw new NotImplementedException()
            };
        }

        private ADPTaskResult ConvertTask(ADPTaskInformation ADPTask) =>
            new ADPTaskResult(ADPTask.id, CalculateResultValue(ADPTask));

        public async Task<ResultMessage> PostSolvedTask(ADPTaskInformation aDPTaskInformation)
        {
            var jsonADPTaskResult = JsonSerializer.Serialize(ConvertTask(aDPTaskInformation));
            var requestContent = new StringContent(jsonADPTaskResult, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://interview.adpeai.com/api/v1/submit-task", requestContent);

            var message = response.IsSuccessStatusCode ? "Success" : await response.Content.ReadAsStringAsync();

            return new ResultMessage() { statusCode = (int)response.StatusCode, message = message };
        }


    }
}
