using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApp.Pages;

public class Contact : PageModel
{
    public bool HasData { get; set; }
    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    public string Message{ get; set; }
    
    public void OnGet()
    {
        
    }

    public void OnPost()
    {
        HasData=true;
        FirstName = Request.Form["firstname"];
        LastName = Request.Form["lastname"];
        Message = Request.Form["message"];
    }
}