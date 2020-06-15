using Logger.Models.Contracts;
using Logger.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class LayoutFactory
    {

        public ILayout ProduceLayout(string type)
        {
            ILayout layout = null;
            if(type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if(type == "XmlLayout")
            {
                layout = new XMLLayout();
            }
            return layout;
        }
    }
}
