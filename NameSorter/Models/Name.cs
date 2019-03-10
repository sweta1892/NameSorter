namespace NameSorter.Models
{
    class Name
    {
        public string GivenName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return this.GivenName + ' ' + this.LastName;
        }

        public override bool Equals(object obj)
        {

            if (!(obj is Name nameObj))
            {
                return false;
            }

            return (this.GivenName.Equals(nameObj.GivenName) && this.LastName.Equals(nameObj.LastName));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
