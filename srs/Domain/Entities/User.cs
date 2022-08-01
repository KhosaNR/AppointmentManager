using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class User: BaseEntity
    {

        //public Guid ID{ get; set; }

        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,60}$",
         //ErrorMessage = "Characters are not allowed.")]
        public string FirstName { get; set; }

        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        // ErrorMessage = "Characters are not allowed.")]
        public string LastName { get; set; }

        //[RegularExpression(@"^[0-9]{10,15}$",
        // ErrorMessage = "Characters are not allowed.")]
        public string PhoneNo { get; set; }

        //public Person(string firstName, string lastName, string phoneNo)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    PhoneNo = phoneNo;
        //    base.ID = Guid.NewGuid();
        //}
    }
}