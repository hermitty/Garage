using Infrastructure.Command;

namespace CustomerManagement.Command
{
    public  class AddCustomer : ICommand
    {
        public string Name { get; set; }

        public string Surname { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
