using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollutionMap.Model
{
    public class MasurareModel
    {
        public int IdHarta { get; set; } 
        public int PozitieX {  get; set; }
        public int PozitieY { get; set; }
        public int Valoare {  get; set; }
        public DateTime Data {  get; set; }

    }
}
