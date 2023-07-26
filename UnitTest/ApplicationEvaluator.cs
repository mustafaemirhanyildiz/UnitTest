using JobApplicationLibrary.UnitTest.Services;
using UnitTest.Models;

namespace UnitTest
{
    public class ApplicationEvaluator
    {
        private int minAge = 18;
        private int maxAge = 65;

        private List<string> skills = new List<string> { "C#", "ASP.NET", "MVC", "SQL" }; 

        private IIdentityValidator _identityValidator;

        public ApplicationEvaluator(IIdentityValidator ıdentityValidator)
        {
            _identityValidator = ıdentityValidator;
        
        }


        public ApplicationResult Evaluate(JobApplication form)
        {
            
            if (form.applicant.age < minAge || form.applicant.age > maxAge)
                return ApplicationResult.AutoRejected;

            if(form.YearsOfExperience < 3)
                return ApplicationResult.AutoRejected;

            if(form.YearsOfExperience>=10)
                return ApplicationResult.AutoAccepted;

            var isValid = _identityValidator.IsValid(form.applicant.identityNumber);
            var isFake = _identityValidator.IsFake(form.applicant.identityNumber);

            if (!isValid && !isFake)
                return ApplicationResult.AutoRejected;



            if (GetSimilarityTwoLists(form.skills) <= 25)
                return ApplicationResult.AutoRejected;
            if(GetSimilarityTwoLists(form.skills)>=75)
                return ApplicationResult.AutoAccepted;

            return ApplicationResult.AutoAccepted;
        }

        public int GetSimilarityTwoLists(List<string> list1)
        {
            int similarity = 0;
            foreach (var item in list1)
            {
                if (skills.Contains(item))
                    similarity++;
            }
            var percent = similarity / skills.Count;
            return percent*100;
            
        }
    }

    public enum ApplicationResult
    {
        AutoRejected,
        TransferredToHR,
        TransferredToLead,
        TransferredToCTO,
        AutoAccepted
    }
}
