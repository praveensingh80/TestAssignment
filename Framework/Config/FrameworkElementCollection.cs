using System.Configuration;

namespace Framework.Config
{
    [ConfigurationCollection(typeof(FrameworkElement), AddItemName = "testSetting", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class FrameworkElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FrameworkElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as FrameworkElement).Name;
        }

        public new FrameworkElement this[string type]
        {
            get
            {
                return (FrameworkElement)base.BaseGet(type);
            }
        }
    }
}
