///Copyright IAnswerable 2012 - 2013
///http://www.IAnswerable.com
namespace IAnswerable.Web.Core
{
    using System;

    /// <summary>
    /// Decorate your class with Key custom attribute
    /// </summary>
    public class Key : Attribute
    {
        string _name;
        public Key(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value; 
            }
        }
    }
}
