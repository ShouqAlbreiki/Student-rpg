using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Student_rpg.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EducationLevel
    {
        PhD = 1,
        PostGraduate = 2,
        Graduate = 3,
        Diploma = 4
    }
}