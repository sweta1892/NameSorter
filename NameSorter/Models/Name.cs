namespace NameSorter.Models
{
    class Name
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public override string ToString()
        {
            return this.firstName + ' ' + this.lastName;
        }

        public override bool Equals(object obj)
        {
            var nameObj = obj as Name;

            if (nameObj == null)
            {
                return false;
            }

            return (this.firstName.Equals(nameObj.firstName) && this.lastName.Equals(nameObj.lastName));
        }
    }
}
