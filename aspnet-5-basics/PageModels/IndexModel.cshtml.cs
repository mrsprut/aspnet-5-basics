using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet5basics.PageModels
{
    public class IndexModel : PageModel
    {
        private readonly MyDependency _dependency = new MyDependency();

        public void OnGet(int? id)
        {
            _dependency.WriteMessage("IndexModel.OnGet created this message.");
            if (id != null)
            {
                _dependency.WriteMessage($"id = {id}");
            }
        }
    }
}