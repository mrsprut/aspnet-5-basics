using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet5basics.PageModels
{
    public class Index2Model : PageModel
    {
        private readonly IMyDependency _myDependency;

        public Index2Model(IMyDependency myDependency)
        {
            _myDependency = myDependency;            
        }

        public void OnGet()
        {
            _myDependency.WriteMessage("Index2Model.OnGet");
        }
    }
}