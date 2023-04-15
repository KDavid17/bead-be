using BeadBE.Application.AuthenticationLogic.Commands.Register;

namespace BeadBE.Architecture.Tests
{
    public class ArchitectureTests
    {
        public const string ApiNamespace = "Api";
        public const string ApplicationNamespace = "Application";
        public const string ContractsNamepsace = "Contracts";
        public const string DomainNamespace = "Domain";
        public const string InfrastructureNamespace = "Infrastructure";

        [Fact]
        public void Register_Should_HaveDuplicateError()
        {
            //Arrange
            var registerCommand = new RegisterCommand("string", "string", "string", "string");
            //Act
            
            
            //Assert
        }
    }
}