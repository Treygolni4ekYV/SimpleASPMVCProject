using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace project.Model.ViewModel;

public class NewCommentView
{
    [BindRequired]
    public string login {get;set;} = "";
    [BindRequired]
    public string password {get;set;} = "";
    
    public string comment {get;set;} = "";



}
