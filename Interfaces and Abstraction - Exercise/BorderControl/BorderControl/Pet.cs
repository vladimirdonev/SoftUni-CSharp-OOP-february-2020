using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : Ibirthable
    {
		private string name;
		private string birthday;

		public Pet(string name,string birthday)
		{
			this.Name = name;
			this.Birthday = birthday;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Birthday
		{
			get { return this.birthday; }
			set { this.birthday = value; }
		}
    }
}
