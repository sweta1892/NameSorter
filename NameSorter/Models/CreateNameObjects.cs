using System;

namespace NameSorter.Models
{
    class CreateNameObjects
    {
        public Name CreateNameObjectFromString(string nameLineItem)
        {
            string[] words = nameLineItem.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = words[0];

                for (int index = 1; index < words.Length - 1; index++)
                {
                    firstName += ' ' + words[index];
                }
                string lastName = words[words.Length - 1];
                return CreateNameObjectFromProperties(firstName, lastName);
        }

        public Name CreateNameObjectFromProperties(string firstName, string lastName)
        {
            Name name = new Name();
            name.firstName = firstName;
            name.lastName = lastName;
            return name;
        }
    }
}
