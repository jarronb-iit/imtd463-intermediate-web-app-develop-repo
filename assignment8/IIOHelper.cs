using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment8
{
    public interface IIOHelper
    {
       void AddEntry(CalculationModel calculation);
       List<CalculationModel> ReadAllEntries();

       void ClearEntries(); 
    }
}
