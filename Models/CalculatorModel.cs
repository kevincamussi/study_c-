using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraApp.Models
{
    public class CalculatorModel
    {
        public double Result { get; set; }
        public string Operation { get; set; }
        public bool IsOperationPerformed { get; set; }

        public CalculatorModel()
        {
            Result = 0;
            Operation = string.Empty;
            IsOperationPerformed = false;
        }








    }
}
