﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name { get; set; }
        private int age { get; set; }
        public Person(string name,int age)
        {
            this.name = name;
            this.age = age;
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(String.Format("Name: {0}, Age: {1}", this.Name, this.Age));
            return sb.ToString();
        }
    }
}
