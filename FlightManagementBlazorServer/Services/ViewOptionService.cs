using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementBlazorServer.Services
{
    public class ViewOptionService
    {
        private bool _navBarVisible = false;

        public Action OnChanged { get; set; }

        //Change state by click on the button
        public void Toggle()
        {
            _navBarVisible = !_navBarVisible;//Change
            if (OnChanged != null) OnChanged();//Callback for reload
        }

        public void Hide()
        {
            _navBarVisible = false;
        }

        //get additional css class for nav bar div
        public string NavBarClass
        {
            get
            {
                if (_navBarVisible) return String.Empty;//No additional css class for show nav bar
                return "d-none";//d-none class will hide the div
            }
        }
    }
}
