using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneSignalApp.Models
{
    public interface IAppRestService
    {
        List<AppModel> Get();
        AppModel Update(AppModel app);
        AppModel Create(AppModel app);
        AppModel GetById(string id);
    }
}