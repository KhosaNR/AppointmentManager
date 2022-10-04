using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorserverApp.Pages
{
    public partial class TestModel : PageModel
    {
        public void OnGet()
        {
        }
        public string mousePointerMessage { get; set; }

        public void TestChange(ChangeEventArgs e)
        {
            mousePointerMessage = e.Value.ToString();
        }

        public void ReportPointerLocation(MouseEventArgs e)
        {
            mousePointerMessage = $"Mouse coordinates: {e.ScreenX}:{e.ScreenY}";
        }

        public void TestMethod()
        {

        }
    }
}
