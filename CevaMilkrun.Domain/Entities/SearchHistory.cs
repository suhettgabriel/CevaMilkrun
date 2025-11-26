using CevaMilkrun.Domain.Common;

namespace CevaMilkrun.Domain.Entities
{
    public class SearchHistory : BaseEntity
    {
        public string PhoneNumber { get; private set; }
        public string JsonResult { get; private set; }
        public bool IsSuccess { get; private set; }
        public string? ErrorMessage { get; private set; }

        protected SearchHistory()
        {
            PhoneNumber = null!;
            JsonResult = null!;
        }

        public SearchHistory(string phoneNumber, string jsonResult, bool isSuccess, string? errorMessage = null)
        {
            PhoneNumber = phoneNumber;
            JsonResult = jsonResult;
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
    }
}