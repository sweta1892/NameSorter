using System;

namespace NameSorter.Models
{
    class CreateNameObjects
    {
        public Name CreateNameObjectFromString(string nameLineItem)
        {
            //get the Last Name and Given Names ignoring the empty spaces
            string[] words = nameLineItem.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            string givenName = words[0];

            for (int index = 1; index < words.Length - 1; index++)
                {
                    givenName += ' ' + words[index];
                }
            string lastName = words[words.Length - 1];

            return CreateNameObjectFromProperties(givenName, lastName);
        }

        public Name CreateNameObjectFromProperties(string givenName, string lastName)
        {
            Name name = new Name
            {
                GivenName = givenName,
                LastName = lastName
            };
            return name;
        }
    }
}
