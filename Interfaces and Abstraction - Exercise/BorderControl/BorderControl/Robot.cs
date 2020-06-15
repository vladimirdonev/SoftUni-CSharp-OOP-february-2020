using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : ICitizen
    {
		private string model;
		private string id;

		public Robot(string model,string id)
		{
			this.Model = model;
			this.id = id;
		}
		public string Model
		{
			get { return model; }
			set { model = value; }
		}

		public string Id 
		{
			get { return this.id; }
			set { this.id = value; } 
		}
	}
}
