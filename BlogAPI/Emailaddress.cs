namespace BlogAPI
{
    internal class Emailaddress
    {
        private string email;

        public Emailaddress(string email)
        {
            this.email = email;
        }

        public string Address { get; internal set; }
    }
}
