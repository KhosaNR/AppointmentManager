using Domain.Enums;
using System.Runtime.CompilerServices;

namespace BlazorserverApp.Pages
{
    public static class AppointmentStatuses
    {
        private static  List<string>  _values;
        public static  List<string> Values 
        { get
            {
                if(_values == null)
                {
                    PopulateStatusList();
                }
                return _values;
            }
        }

        private static void PopulateStatusList()
        {
            _values = new();
            foreach (string name in Enum.GetNames(typeof(AppointmentStatus)))
            {
                _values.Add(name);
            }
        }
    }
}
