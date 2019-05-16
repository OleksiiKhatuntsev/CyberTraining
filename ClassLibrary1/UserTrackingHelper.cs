using System;
using System.Collections.Generic;
using System.Text;
using BOL;

namespace UserTrackingService
{
    public class UserTrackingHelper
    {
        private readonly FakeRepository rep;

        public UserTrackingHelper(CyberTrainingContext context)
        {
            rep = new FakeRepository(context);
        }

        public void UpdateUserSettings()
        {
            rep.UpdateUserSettings();
        }

        public void SetUserSettings(int id)
        {
            rep.SetDataForUser(id);
        }
    }
}
