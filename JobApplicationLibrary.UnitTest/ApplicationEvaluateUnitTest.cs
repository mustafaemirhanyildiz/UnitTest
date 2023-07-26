using JobApplicationLibrary.UnitTest.Services;
using Moq;
using UnitTest;
using UnitTest.Models;

namespace JobApplicationLibrary.UnitTest
{
    public class ApplicationEvaluateUnitTest
    {


        [Test]
        public void Evaluate_WhenApplicantAge_LessThanMinAgeOr_BiggerThanMaxAge_ReturnsAutoRejected()
        {    
            
            var mockValidator = new Mock<IIdentityValidator>(MockBehavior.Loose);
            mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);


            var evaluator= new ApplicationEvaluator(mockValidator.Object);
            var application = new JobApplication
            {
                applicant = new Applicant { age = 45 },
                YearsOfExperience = 5,
                skills = new List<string> { "C#", "Java", "Python", "SQL" }

            };


            var result = evaluator.Evaluate(application);
              
            Assert.AreEqual(result,ApplicationResult.AutoRejected);
        }



        [Test]
        public void Evaluate_WhenYearsOfExperience_LessThanRequired_ReturnsAutoRejected()
        {
            var mockValidator = new Mock<IIdentityValidator>();
            mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);

            var evaluator = new ApplicationEvaluator(mockValidator.Object);
            var application = new JobApplication
            {
                applicant = new Applicant { age = 28 },
                YearsOfExperience = 2, 
                skills = new List<string> { "C#", "Java", "Python", "SQL" }
            };

            var result = evaluator.Evaluate(application);

            Assert.AreEqual(result, ApplicationResult.AutoRejected);
        }



        [Test]
        public void Evaluate_WhenSkills_DoNotMeetRequirements_ReturnsAutoRejected()
        {
            var mockValidator = new Mock<IIdentityValidator>();
            mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);

            var evaluator = new ApplicationEvaluator(mockValidator.Object);
            var application = new JobApplication
            {
                applicant = new Applicant { age = 35 },
                YearsOfExperience = 8,
                skills = new List<string> { "C#", "Java" } 
            };

            var result = evaluator.Evaluate(application);

            Assert.AreEqual(result, ApplicationResult.AutoRejected);
        }

    }
}