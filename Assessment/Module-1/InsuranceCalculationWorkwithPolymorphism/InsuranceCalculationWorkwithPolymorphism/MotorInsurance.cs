using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCalculationWorkwithPolymorphism
{
    internal class MotorInsurance : Insurance
    {
        double idv;
        float depPercent;

        public double Idv
        {
            get { return idv; }
            set { idv = value; }
        }
        public float DepPercent
        {
            get { return depPercent; }
            set { depPercent = value; }
        }

        public double calculatePremium()
        {
            Idv = AmountCovered - ((AmountCovered * DepPercent) / 100);
            return Idv * 0.03;
        }
    }
}
