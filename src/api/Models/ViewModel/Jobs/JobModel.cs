using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel.Jobs;
using api.Validations;
using Newtonsoft.Json;

namespace api.Models.ViewModel.Jobs
{
    public class JobModel
    {
        [JsonProperty("title"), JsonRequiredValidate, JsonMaxLength(45)]
        public string? Title { get; set; }

        [JsonProperty("project_id"), JsonRequiredValidate]
        public int ProjectId { get; set; }

        [JsonProperty("description"), JsonRequiredValidate, JsonMaxLength(150)]
        public string? Description { get; set; }


        public Job Map(int userId)
        {
            var job = new Job
            {
                Title = Title,
                Description = Description,
                UserId = userId,
                ProjectId = ProjectId

            };

            return job;
        }
    }
}