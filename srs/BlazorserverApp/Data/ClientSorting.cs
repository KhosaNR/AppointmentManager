using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlazorserverApp.Data
{
    public class ClientStyling
    {
        public Dictionary<string,string> Columns { get; private set; } = new Dictionary<string, string>();
        private string _descIconClass = "fa-solid fa-arrow-down-wide-short";
        private string _ascIconClass = "fa-solid fa-arrow-up-wide-short";
        public ClientStyling()
        {
            Columns.Add("FirstName", "");
            Columns.Add("LastName", "");
            Columns.Add("Email", "");
            Columns.Add("Phone", "");
            Columns.Add("AppointmentStatus", "");
            Columns.Add("AppointmentTime", "");
            Columns.Add("AppointmentDate", "");
            Columns.Add("AppointmentTimeOfWeek", "");

        }
        
        public void ChangeSortingColumn(string column, bool sortAscending)
        {
            foreach (var key in Columns.Keys.ToList())
            {
                Columns[key] = "";
            }
            Columns[column] = sortAscending ? _ascIconClass : _descIconClass;
        }

        public void ChangeStyling(string columnName, string styleClass)
        {
            Columns[columnName] = styleClass;
        }

    }
}
