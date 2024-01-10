using api.Models.EntityModel.Times;
using api.Validations;
using Newtonsoft.Json;

namespace api.Models.ViewModel.Times
{
    public class TimeModel
    {
        [JsonProperty("job_id"), JsonRequiredValidate]
        public int JobId { get; set; }

        [JsonProperty("started_at"), JsonRequiredValidate]
        public DateTime StartedAt { get; set; }

        [JsonProperty("ended_at"), JsonRequiredValidate]
        public DateTime EndedAt { get; set; }

        [JsonValidIf(ErrorMessage = "ended_at cannot be less than or equal to started_at")]
        public bool EndedAtIsValid => !(EndedAt <= StartedAt);

        public Time Map()
        {
            return new Time
            {
                JobId = JobId,
                StartedAt = StartedAt,
                EndedAt = EndedAt
            };
        }

        public Time Map(Time time)
        {
            time.JobId = JobId;
            time.StartedAt = StartedAt;
            time.EndedAt = EndedAt;

            return time;
        }
    }
}