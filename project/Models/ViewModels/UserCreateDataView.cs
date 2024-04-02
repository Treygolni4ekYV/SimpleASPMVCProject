using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace project.Model.ViewModel;

public class UserCreateDataView
{
    [BindRequired]
    public string login{get; set;} = "";
    [BindRequired]
    public string userName{get;set;} = "";
    [BindRequired]
    public string password {get;set;} = "";
}
