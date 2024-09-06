using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCalculationWorkwithPolymorphism
{
    internal class Insurance
    {
        string insuranceNo;
        string insuranceName;
        double amountCovered;

        public string InsuranceNo
        {
            set
            {
                this.insuranceNo = value;
            }
            get
            {
                return this.insuranceNo;
            }
        }

        public string InsuranceName
        {
            set
            {
                this.insuranceName = value;
            }
            get
            {
                return this.insuranceName;
            }
        }

        public double AmountCovered
        {
            set
            {
                this.amountCovered = value;
            }
            get
            {
                return this.amountCovered;
            }
        }


    }
}
