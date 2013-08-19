using System.ComponentModel.DataAnnotations;

namespace uStorage.Web.ViewModels
{
    public class SqlManagerInfoModel
    {
        [StringLength(100)]
        public string ConnString
        {
            get;
            set;
        }

        public bool ConnectionTestResult
        {
            get;
            set;
        }

        [StringLength(100)]
        public string ErrorInfo
        {
            get;
            set;
        }
    }
}