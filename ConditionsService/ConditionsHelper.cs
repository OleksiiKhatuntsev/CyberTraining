using System;
using System.Collections.Generic;
using System.Text;
using BOL;

namespace ConditionsService
{
    public class ConditionsHelper
    {
        private readonly FakeRepository rep;

        public ConditionsHelper(CyberTrainingContext context)
        {
            rep = new FakeRepository(context);
        }

        public void GetConditionsFromDevice()
        {
            rep.SetConditions();
        }
    }
}
