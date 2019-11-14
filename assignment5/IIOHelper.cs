using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    public interface IIOHelper
    {
       public void AddEntry(ICalculation calculation);
       public  List<ICalculation> ReadAllEntries();

       public void ClearEntries(); 
    }
}
