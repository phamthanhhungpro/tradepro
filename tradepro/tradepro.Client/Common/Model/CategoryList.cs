﻿namespace tradepro.Client.Common.Model
{
    public class CategoryList
    {
        public  string Name;
        public  Guid Id;


        // Note: this is important so the MudSelect can compare pizzas
        public override bool Equals(object o)
        {
            var other = o as CategoryList;
            return other?.Name == Name;
        }

        // Note: this is important too!
        public override int GetHashCode() => Name?.GetHashCode() ?? 0;

        // Implement this for the Pizza to display correctly in MudSelect
        public override string ToString() => Name;
    }
}
