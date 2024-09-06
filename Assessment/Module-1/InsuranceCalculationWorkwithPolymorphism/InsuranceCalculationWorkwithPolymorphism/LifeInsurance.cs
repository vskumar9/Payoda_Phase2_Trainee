using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCalculationWorkwithPolymorphism
{
    internal class LifeInsurance : Insurance
    {
        int policyTerm;
        float benefitPercent;

        public int PolicyTerm
        {
            set
            {
                this.policyTerm = value;
            }
            get
            {
                return this.policyTerm;
            }
        }

        public float BenefitPercent
        {
            set
            {
                this.benefitPercent = value;
            }
            get
            {
                return this.benefitPercent;
            }
        }

        public double calculatePremium()
        {
            return (AmountCovered - ((AmountCovered * BenefitPercent) / 100)) / PolicyTerm;
        }
    }
}
